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

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
