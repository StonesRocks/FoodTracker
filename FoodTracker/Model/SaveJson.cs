using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Interface;
using Newtonsoft.Json;

namespace FoodTracker.Model
{
    public class SaveJson : IDatabase
    {
        private string _folderPath = "jsonFolder";
        private List<IIngredient> ingredients = new List<IIngredient>();
        private List<IRecipe> recipes = new List<IRecipe>();


        public SaveJson()
        {

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

        public void Save(List<string>? parameters)
        {
            ExportToJson(ingredients, "ingredients", _folderPath);
            ExportToJson(recipes, "recipes", _folderPath);
        }

        public void Load(List<string>? parameters)
        {
            if (File.Exists($"{_folderPath}/ingredients.json"))
            {
                ingredients = ImportFromJson<List<IIngredient>>($"{_folderPath}/ingredients.json");
            }
            if (File.Exists($"{_folderPath}/recipes.json"))
            {
                recipes = ImportFromJson<List<IRecipe>>($"{_folderPath}/recipes.json");
            }
        }
    }
}
