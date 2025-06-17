using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AddBookIdOrClusterRepository : IAddBookIdOrClusterRepository
    {

        private string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

        public RootObject AddBookId(string bookId)
        {
            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getByBookId.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found", filePath);

            string jsonContent = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<RootObject>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // חיפוש הרשומה המתאימה
            var itemToAdd = result?.d?.FirstOrDefault(row => row.BookId == bookId);

            if (itemToAdd != null)
            {
                result.d.Add(itemToAdd);

                // כתיבה חזרה לקובץ
                string updatedJson = JsonSerializer.Serialize(result, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, updatedJson);
            }

            return result;
        }


        public RootObject AddBookIdsByClusterId(string clusterId)
        {
            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getByBookId.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found", filePath);

            string jsonContent = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<RootObject>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // חיפוש כל הרשומות המתאימות
            var itemsToAdd = result?.d?.Where(row => row.ExistsClusterId == clusterId).ToList();

            if (itemsToAdd != null && itemsToAdd.Count > 0)
            {
                foreach (var item in itemsToAdd)
                {
                    AddBookId(item.BookId);
                }

                // קריאה מחודשת לקובץ לאחר ההוספה
                string updatedJson = File.ReadAllText(filePath);
                result = JsonSerializer.Deserialize<RootObject>(updatedJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return result;
        }

    }
}
