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


    }
}
