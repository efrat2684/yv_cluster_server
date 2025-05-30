using Data.Repositories.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Data.Repositories
{
    public class SystemClusterRepository : ISystemClusterRepository
    {

        private string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));


        public SystemClusterRepository()
        {
            // עלייה מרמת bin\Debug\net8.0 לשורש הפרויקט
            //var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

 
        }

        public string GetMessage()
        {
             List<TestModel> _data;

        // בניית הנתיב לקובץ Test.json
             var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "Test.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"קובץ JSON לא נמצא בנתיב: {filePath}");
            }

            // קריאה של תוכן הקובץ כטקסט
            var jsonString = File.ReadAllText(filePath);

            // פענוח התוכן לרשימה של TestModel
            _data = JsonSerializer.Deserialize<List<TestModel>>(jsonString) ?? new List<TestModel>();
            return _data.FirstOrDefault()?.message ?? "אין נתונים";
        }




        //////////////////////////
        //private readonly string _jsonFilePath = "Data/cluster-data.json";


        public RootObjectOfClusterGroupDetails GetClusterGroupDetailsFromJson()
        {

            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getClusterGroupDetails.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found", filePath);

            string jsonContent = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<RootObjectOfClusterGroupDetails>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
    }
