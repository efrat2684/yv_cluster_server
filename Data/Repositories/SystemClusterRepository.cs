using Data.Models;
using Data.Repositories.Interfaces;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Data.context;
using System.Net;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data;
using Microsoft.Extensions.Configuration;
using static System.Formats.Asn1.AsnWriter;
namespace Data.Repositories
{
    public class SystemClusterRepository : ISystemClusterRepository
    {

        //private readonly SystemClusterDbContext _context;

        //public SystemClusterRepository(SystemClusterDbContext context)
        //{
        //    _context = context;
        //}
        private readonly string _connectionString;

        public SystemClusterRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(_connectionString);
        }

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


        //public RootObjectOfClusterGroupDetails GetClusterGroupDetails()
        //{

        //    var filePath = Path.Combine(projectRoot, "Data", "JsonFiles", "getClusterGroupDetails.json");

        //    if (!File.Exists(filePath))
        //        throw new FileNotFoundException("JSON file not found", filePath);

        //    string jsonContent = File.ReadAllText(filePath);
        //    var result = JsonSerializer.Deserialize<RootObjectOfClusterGroupDetails>(jsonContent, new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    });

        //    return result;
        //}
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


        public RootObjectOfClusterGroupDetails GetClusterGroupDetails()
        {
            DataTable dt = new DataTable();
            RootObjectOfClusterGroupDetails result = new RootObjectOfClusterGroupDetails();
            List<ClusteredNameRowEzer> allRows = new List<ClusteredNameRowEzer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from namesData n\r\njoin groups g on n.bookId=g.bookId", connection))
                {
                    try
                    {
                        connection.Open();
                        da.Fill(dt);
                        List<ClusteredNameRow> clusteredNameRows = new List<ClusteredNameRow>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];

                            ClusteredNameRow item = new ClusteredNameRow
                            {
                                //__type = "YourNamespace.ClusteredNameRow", // אפשר לשנות לפי הצורך
                                BookId = row["BookId"] == DBNull.Value ? "" : row["BookId"].ToString().Trim(),
                                FirstName = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["FirstName"] == DBNull.Value ? "" : row["FirstName"].ToString().Trim(),
                                    Code = row["FirstNameCode"] == DBNull.Value ? "" : row["FirstNameCode"].ToString().Trim()
                                },
                                LastName = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["LastName"] == DBNull.Value ? "" : row["LastName"].ToString().Trim(),
                                    Code = row["LastNameCode"] == DBNull.Value ? "" : row["LastNameCode"].ToString().Trim()
                                },
                                FatherFirstName = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["FatherName"] == DBNull.Value ? "" : row["FatherName"].ToString().Trim(),
                                    Code = row["FatherNameCode"] == DBNull.Value ? "" : row["FatherNameCode"].ToString().Trim()
                                },
                                MotherFirstName = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["MotherName"] == DBNull.Value ? "" : row["MotherName"].ToString().Trim(),
                                    Code = row["MotherNameCode"] == DBNull.Value ? "" : row["MotherNameCode"].ToString().Trim()
                                },
                                SpouseFirstName = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["SpouseFirstName"] == DBNull.Value ? "" : row["SpouseFirstName"].ToString().Trim(),
                                    Code = row["SpouseFirstNameCode"] == DBNull.Value ? "" : row["SpouseFirstNameCode"].ToString().Trim()
                                },
                                DateOfBirth = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["DateOfBirth"] == DBNull.Value ? "" : row["DateOfBirth"].ToString().Trim(),
                                    Code = row["DateOfBirthCode"] == DBNull.Value ? "" : row["DateOfBirthCode"].ToString().Trim()
                                },
                                PlaceOfBirth = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["PlaceOfBirth"] == DBNull.Value ? "" : row["PlaceOfBirth"].ToString().Trim(),
                                    Code = row["PlaceOfBirthCode"] == DBNull.Value ? "" : row["PlaceOfBirthCode"].ToString().Trim()
                                },
                                PermanentPlace = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["PermanentPlace"] == DBNull.Value ? "" : row["PermanentPlace"].ToString().Trim(),
                                    Code = row["PermanentPlaceCode"] == DBNull.Value ? "" : row["PermanentPlaceCode"].ToString().Trim()
                                },
                                Source = new ValueCodeItem
                                {
                                    __type = "YourNamespace.ValueCodeItem",
                                    Value = row["Source"] == DBNull.Value ? "" : row["Source"].ToString().Trim(),
                                    Code = row["SourceCode"] == DBNull.Value ? "" : row["SourceCode"].ToString().Trim()
                                },
                                MaidenName = row["MaidenName"] == DBNull.Value ? "" : row["MaidenName"].ToString().Trim(),
                                IsClustered = row["IsClustered"] == DBNull.Value ? 0 : Convert.ToInt32(row["IsClustered"]),
                                ExistsClusterId = row["ExistsClusterId"] == DBNull.Value ? "" : row["ExistsClusterId"].ToString().Trim(),
                                RelatedFnameGroupId = row["RelatedFnameGroupId"] == DBNull.Value ? null : row["RelatedFnameGroupId"],
                                IsHasRelatedFname = row["RelatedFnameList"] == DBNull.Value ? false : Convert.ToBoolean(row["RelatedFnameList"]),
                                Ind = row["Ind"] == DBNull.Value ? 0 : Convert.ToInt32(row["Ind"]),
                                HasRelatedGroups = row["HasRelatedGroups"] == DBNull.Value ? false : Convert.ToBoolean(row["HasRelatedGroups"]),
                                NumberOfSuggestions = row["NumberOfSuggestions"] == DBNull.Value ? 0 : Convert.ToInt32(row["NumberOfSuggestions"]),
                                RelatedFnameList = row["RelatedFnameList"] == DBNull.Value ? null : row["RelatedFnameList"],
                                Score = row["Score"] == DBNull.Value ? "" : row["Score"].ToString().Trim(),
                            };

                            clusteredNameRows.Add(item);
                        }

                        // הרכבת האובייקט הסופי:
                        result = new RootObjectOfClusterGroupDetails
                        {
                            d = new ClusterGroupWithCrmLinks
                            {
                                __type = "YourNamespace.ClusterGroupWithCrmLinks",
                                ClusteredNameRowList = clusteredNameRows,
                                CrmLinkList = new List<object>(), // אם יש נתונים – תוכל להוסיף
                                contact = null // או שים אובייקט מתאים אם יש
                            }
                        };

                    }
                    catch (Exception ex)
                    {
                        throw; // עדיף מ- throw ex
                    }
                }
            }

            return result;
        }

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
