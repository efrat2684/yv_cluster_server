using Data.Repositories.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Data.context;
using System.Net;

namespace Data.Repositories
{
    public class SystemClusterRepository : ISystemClusterRepository
    {

        //private readonly SystemClusterDbContext _context;

        //public SystemClusterRepository(SystemClusterDbContext context)
        //{
        //    _context = context;
        //}
        private string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));

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


        public RootObjectOfClusterGroupDetails GetClusterGroupDetails()
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
        //public RootObjectOfClusterGroupDetails GetClusterGroupDetails()
        //{
        //    var result = new RootObjectOfClusterGroupDetails
        //    {
        //        d = new ClusterGroupWithCrmLinks
        //        {
        //            ClusteredNameRowList = _context.NamesData
        //                .Select(n => new ClusteredNameRow
        //                {
        //                    BookId = n.BookId,
        //                    FirstName = new ValueCodeItem
        //                    {
        //                        Value = n.FirstName.Value,
        //                        Code = n.FirstName.Code
        //                    },
        //                    LastName = new ValueCodeItem
        //                    {
        //                        Value = n.LastName.Value,
        //                        Code = n.LastName.Code
        //                    },
        //                    FatherFirstName = new ValueCodeItem
        //                    {
        //                        Value = n.FatherFirstName.Value,
        //                        Code = n.FatherFirstName.Code
        //                    },
        //                    MotherFirstName = new ValueCodeItem
        //                    {
        //                        Value = n.MotherFirstName.Value,
        //                        Code = n.MotherFirstName.Code
        //                    },
        //                    PlaceOfBirth = new ValueCodeItem
        //                    {
        //                        Value = n.PlaceOfBirth.Value,
        //                        Code = n.PlaceOfBirth.Code
        //                    },
        //                    PermanentPlace = new ValueCodeItem
        //                    {
        //                        Value = n.PermanentPlace.Value,
        //                        Code = n.PermanentPlace.Code
        //                    },
        //                    DateOfBirth = new ValueCodeItem
        //                    {
        //                        Value = n.DateOfBirth.Value,
        //                        Code = n.DateOfBirth.Code
        //                    },
        //                    Source = new ValueCodeItem
        //                    {
        //                        Value = n.Source.Value,
        //                        Code = n.Source.Code
        //                    },
        //                    SpouseFirstName = new ValueCodeItem
        //                    {
        //                        Value = n.SpouseFirstName.Value,
        //                        Code = n.SpouseFirstName.Code
        //                    },
        //                    MaidenName = n.MaidenName,
        //                    IsClustered = n.IsClustered,
        //                    ExistsClusterId = n.ExistsClusterId,
        //                    RelatedFnameGroupId = n.RelatedFnameGroupId,
        //                    IsHasRelatedFname = n.IsHasRelatedFname,
        //                    Ind = n.Ind,
        //                    HasRelatedGroups = n.HasRelatedGroups,
        //                    Score = n.Score,
        //                    NumberOfSuggestions = n.NumberOfSuggestions,
        //                    RelatedFnameList = null // אם יש צורך לאכלס, אפשר להוסיף לוגיקה כאן
        //                })
        //                .ToList()
        //        }
        //    };

        //    return result;
        //}


        public StatisticData GetStatisticData()
        {

            var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getStatisticData.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found", filePath);

            string jsonContent = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<StatisticData>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
    }
