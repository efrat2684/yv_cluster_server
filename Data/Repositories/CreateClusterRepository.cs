using Data.Models;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CreateClusterRepository : ICreateClusterRepository
    {
        private string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));


        public SapirClusterModel GetCreateClusterData()
        {

            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getCreateClusterData.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found", filePath);

            string jsonContent = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<SapirClusterModel>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }

        public SapirClusterModel CreateNewCluster(SapirClusterModel sapirClusterModel)
        {
            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getCreateClusterData.json");

            // Serialize the model to JSON
            string jsonContent = JsonSerializer.Serialize(sapirClusterModel, new JsonSerializerOptions
            {
                WriteIndented = true // Optional: makes the JSON more readable
            });

            // Write the JSON to the file (overwrites existing file)
            File.WriteAllText(filePath, jsonContent);

            // Optionally, return the saved model
            return sapirClusterModel;
        }

    }
}
