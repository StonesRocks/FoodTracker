using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Decorators;
using FoodTracker.Interface;
using Newtonsoft.Json;

namespace FoodTracker.Model
{
    public class SaveJson : IDatabase
    {
        // Singleton pattern
        private static SaveJson instance = null;
        private static readonly object padlock = new object();
        private int _id = int.MinValue;
        private int idCounter
        {
            get
            {
                _id++;
                return _id;
            }
            set
            {
                if (_id == int.MinValue)
                {
                    _id = value;
                }
            }
        }
        public static SaveJson Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SaveJson();
                        }
                    }
                }
                return instance;
            }
        }

        private string _folderPath = "jsonFolder";
        private List<IIngredient> ingredients = new List<IIngredient>();
        private List<string> storage = new List<string>();


        private SaveJson()
        {
            CreateFolder(_folderPath);
            if (FilePathExist($"{_folderPath}/ingredients.json"))
            {
                var ingredients = ImportBasicIngredientsFromJson($"{_folderPath}/ingredients.json");
                foreach (var ingredient in ingredients)
                {
                    this.ingredients.Add(ingredient);
                }
            }
            else
            {
                new TestAutoFiller(this);
            }
            if (FilePathExist($"{_folderPath}/storage.json"))
            {
                storage = ImportFromJson<List<string>>($"{_folderPath}/storage.json");
            }
            if (FilePathExist($"{_folderPath}/idCounter.json"))
            {
                idCounter = ImportFromJson<int>($"{_folderPath}/idCounter.json");
            }
            else
            {
                if (ingredients.Count > 0)
                {
                    idCounter = ingredients.Max(x => x.GetProperty("id"));
                }
                else { idCounter = 0; }
            }
        }
        public List<IIngredient> StorageSearch(string searchTerm)
        {
            List<IIngredient> foundIngredients = new List<IIngredient>();
            foreach(var ingredientId in storage)
            {
                foundIngredients.Add(ingredients.Find(x => x.GetProperty("id") == ingredientId));
            }
            return foundIngredients;
        }

        public void AddToStorage(IIngredient ingredient)
        {
            storage.Add(ingredient.GetProperty("id"));
        }

        public void RemoveFromStorage(IIngredient ingredient)
        {
            storage.Remove(ingredient.GetProperty("id"));
        }

        public void VerifyUnique(IIngredient ingredient)
        {
            if (ingredient.GetProperty("id") != null)
            {
                // Check if the id is unique
                string id = ingredient.GetProperty("id");
                if (ingredients.Any(x => x.GetProperty("id") == id))
                {
                    throw new IngredientNotUniqueException(ingredients.Find(x => x.GetProperty("id") == id));
                }
            }
            if (ingredient.GetProperty("EAN13") != null)
            {
                // Check if the EAN13 is unique
                string EAN13 = ingredient.GetProperty("EAN13");
                if (ingredients.Any(x => x.GetProperty("EAN13") == EAN13))
                {
                    throw new IngredientNotUniqueException(ingredients.Find(x => x.GetProperty("EAN13") == EAN13));
                }
            }
            if (ingredient.GetProperty("ProductName") != null)
            {
                // Check if the name is unique
                string name = ingredient.GetProperty("ProductName");
                if (ingredients.Any(x => x.GetProperty("ProductName") == name))
                {
                    throw new IngredientNotUniqueException(ingredients.Find(x => x.GetProperty("ProductName") == name));
                }
            }
        }

        public List<IIngredient> IngredientSearch(string searchTerm)
        {
            List<IIngredient> foundIngredients = new List<IIngredient>();
            string searchString = searchTerm.ToLower();
            int? searchInt = null;

            if (int.TryParse(searchString, out int _searchInt))
            {
                searchInt = _searchInt;
            }

            foreach(var ingredient in ingredients)
            {
                foreach(var property in ingredient.Properties)
                {
                    if (property.Value is string stringValue && stringValue.ToLower().Contains(searchString))
                    {
                        foundIngredients.Add(ingredient);
                        break;
                    }
                    if (searchInt != null && property.Value is int intValue && intValue == searchInt)
                    {
                        foundIngredients.Add(ingredient);
                        break;
                    }
                }
            }
            return foundIngredients;
        }

        public void AddIngredientToDatabase(IIngredient ingredient)
        {
            IdDecorator idDecorator = new IdDecorator();
            idDecorator.Decorate(ingredient, idCounter.ToString());
            ingredients.Add(ingredient);
        }

        public void RemoveIngredientFromDatabase(IIngredient ingredient)
        {
            ingredients.Remove(ingredient);
        }

        public void SaveIngredient(IIngredient ingredient)
        {
            if (!ingredients.Contains(ingredient))
            {
                ingredients.Add(ingredient);
            }
            Save();
        }

        public bool FilePathExist(string filePath)
        {
            if (File.Exists(filePath)) return true;
            return false;
        }
        public bool FolderPathExist(string folderPath)
        {
            if (Directory.Exists(folderPath)) return true;
            return false;
        }
        public T ImportFromJson<T>(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public List<BasicIngredient> ImportBasicIngredientsFromJson(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<BasicIngredient>>(jsonData);
        }

        public void ExportToJson<T>(T _object, string baseName, string folderPath = "jsonFolder")
        {
            folderPath = Path.GetFullPath(folderPath); // I think this does what i think it does
            var filePath = Path.Combine(folderPath, $"{baseName}.json");
            string jsonString = JsonConvert.SerializeObject(_object);
            CreateFolder(folderPath);
            // Write the JSON string to the file.
            File.WriteAllText(filePath, jsonString);
        }

        public void CreateFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public void Save()
        {
            ExportToJson(ingredients, "ingredients", _folderPath);
            SortStorage();

            ExportToJson(storage, "storage", _folderPath);
            ExportToJson(idCounter, "idCounter", _folderPath);
        }

        private void SortStorage()
        {
            int dataSize = storage.Count;

            // We add two different sorting algorithms, for individual users its going to use quicksort but if any organisation uses this it will use mergesort for faster sorting
            if (dataSize <= 1000)
            {
                QuickSort(storage, 0, storage.Count - 1);
            }
            else
            {
                MergeSort(storage, 0, storage.Count - 1);
            }
        }

        public void QuickSort(List<string> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(list, left, right);
                // recursively sort the two partitions
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }

        private int Partition(List<string> list, int left, int right)
        {
            string pivot = list[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (int.Parse(list[j]) <= int.Parse(pivot))
                {
                    i++;
                    Swap(list, i, j);
                }
            }

            Swap(list, i + 1, right);
            return i + 1;
        }
        private void Swap(List<string> list, int i, int j)
        {
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public void MergeSort(List<string> list, int left, int right)
        {
            // recursive function that splits until the size of left and right is 1 or 0
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(list, left, mid);
                MergeSort(list, mid + 1, right);
                // this remains incomplete until the parts are 0 or 1, it then starts merging from the newest to the oldest
                Merge(list, left, mid, right);
            }
        }
        private void Merge(List<string> list, int left, int mid, int right)
        {
            int leftsize = mid - left + 1;
            int rightsize = right - mid;

            List<string> leftArray = new List<string>();
            List<string> rightArray = new List<string>();

            for (int i = 0; i < leftsize; ++i)
            {
                leftArray.Add(list[left + i]);
            }

            for (int j = 0; j < rightsize; ++j)
            {
                rightArray.Add(list[mid + 1 + j]);
            }

            // the spot that we place the smallest value
            int mergedIndex = left;
            // index of leftArray
            int indexLeft = 0;
            // index of rightArray
            int indexRight = 0;

            while (indexLeft < leftsize && indexRight < rightsize)
            {
                if (int.Parse(leftArray[indexLeft]) <= int.Parse(rightArray[indexRight]))
                {
                    list[mergedIndex] = leftArray[indexLeft];
                    indexLeft++;
                }
                else
                {
                    list[mergedIndex] = rightArray[indexRight];
                    indexRight++;
                }
                mergedIndex++;
            }
            // if right side runs out then add remaining left array
            while (indexLeft < leftsize)
            {
                list[mergedIndex] = leftArray[indexLeft];
                indexLeft++;
                mergedIndex++;
            }
            // if left side runs out then add remaining right array
            while (indexRight < rightsize)
            {
                list[mergedIndex] = rightArray[indexRight];
                indexRight++;
                mergedIndex++;
            }
        }

    }
}
