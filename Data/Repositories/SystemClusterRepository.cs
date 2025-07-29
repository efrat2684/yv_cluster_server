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



        public BookIdDetails createNewBookIdDetails(DataRow row)
        {
            BookIdDetails bookIdDetailsObject = new BookIdDetails
            {
                //__type = "YourNamespace.ClusteredNameRow", // אפשר לשנות לפי הצורך
                BookId = row["BookId"] == DBNull.Value ? "" : row["BookId"].ToString().Trim(),
                FirstName = new ValueCodeItem
                {
                    Value = row["FirstName"] == DBNull.Value ? "" : row["FirstName"].ToString().Trim(),
                    Code = row["FirstNameCode"] == DBNull.Value ? null : row["FirstNameCode"].ToString().Trim()
                },
                LastName = new ValueCodeItem
                {
                    Value = row["LastName"] == DBNull.Value ? "" : row["LastName"].ToString().Trim(),
                    Code = row["LastNameCode"] == DBNull.Value ? null : row["LastNameCode"].ToString().Trim()
                },
                FatherFirstName = new ValueCodeItem
                {
                    Value = row["FatherName"] == DBNull.Value ? "" : row["FatherName"].ToString().Trim(),
                    Code = row["FatherNameCode"] == DBNull.Value ? null : row["FatherNameCode"].ToString().Trim()
                },
                MotherFirstName = new ValueCodeItem
                {
                    Value = row["MotherName"] == DBNull.Value ? "" : row["MotherName"].ToString().Trim(),
                    Code = row["MotherNameCode"] == DBNull.Value ? null : row["MotherNameCode"].ToString().Trim()
                },
                SpouseFirstName = new ValueCodeItem
                {
                    Value = row["SpouseFirstName"] == DBNull.Value ? "" : row["SpouseFirstName"].ToString().Trim(),
                    Code = row["SpouseFirstNameCode"] == DBNull.Value ? null : row["SpouseFirstNameCode"].ToString().Trim()
                },
                DateOfBirth = new ValueCodeItem
                {
                    Value = row["DateOfBirth"] == DBNull.Value ? "" : row["DateOfBirth"].ToString().Trim(),
                    Code = row["DateOfBirthCode"] == DBNull.Value ? null : row["DateOfBirthCode"].ToString().Trim()
                },
                PlaceOfBirth = new ValueCodeItem
                {
                    Value = row["PlaceOfBirth"] == DBNull.Value ? "" : row["PlaceOfBirth"].ToString().Trim(),
                    Code = row["PlaceOfBirthCode"] == DBNull.Value ? null : row["PlaceOfBirthCode"].ToString().Trim()
                },
                PermanentPlace = new ValueCodeItem
                {
                    Value = row["PermanentPlace"] == DBNull.Value ? "" : row["PermanentPlace"].ToString().Trim(),
                    Code = row["PermanentPlaceCode"] == DBNull.Value ? null : row["PermanentPlaceCode"].ToString().Trim()
                },
                Source = new ValueCodeItem
                {
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
                //Score = row["Score"] == DBNull.Value ? "" : row["Score"].ToString().Trim()
            };
            return bookIdDetailsObject;
        }
        public ClusterGroupWithCrmLinks GetClusterGroupDetails(int groupId)
        {
            string query = "select * from namesData n join groups g on n.bookId = g.bookId where g.groupId = @groupId";
            DataTable dt = new DataTable();
            ClusterGroupWithCrmLinks result = new ClusterGroupWithCrmLinks();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@groupId", groupId);
                    try
                    {
                        connection.Open();
                        da.Fill(dt);
                        List<BookIdDetails> clusteredNameRows = new List<BookIdDetails>();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];

                            BookIdDetails item = createNewBookIdDetails(row);
                            item.Score = row["Score"] == DBNull.Value ? "" : row["Score"].ToString().Trim();

                            clusteredNameRows.Add(item);
                        }

                        // הרכבת האובייקט הסופי:
                        result = new ClusterGroupWithCrmLinks
                        {
                            BookIdDetailsList = clusteredNameRows,
                            CrmLinkList = new List<object>(), // אם יש נתונים – תוכל להוסיף
                            Contact = null // או שים אובייקט מתאים אם יש
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


        public BookIdDetails AddBookId(string bookId)
        {
            string query = "select * from namesData where BookId = @BookId";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@BookId", bookId);
                    try
                    {
                        connection.Open();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                            return null;

                        DataRow row = dt.Rows[0];

                        BookIdDetails item = createNewBookIdDetails(row);
                        return item;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public List<BookIdDetails> AddBookIdsByClusterId(string clusterId)
        {
            string query = "select * from namesData where ExistsClusterId = @ClusterId";
            DataTable dt = new DataTable();
            var results = new List<BookIdDetails>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ClusterId", clusterId);
                    try
                    {
                        connection.Open();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];

                            BookIdDetails item = createNewBookIdDetails(row);
                            results.Add(item);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return results;
        }

        public void AddNewBookIdToExistCluster(string[] bookIds, string clusterId)
        {
            string insertQuery = "INSERT INTO newClusterFromSystem (BookId, ClusterId, CreateDate) VALUES (@BookId, @ClusterId, @CreateDate)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (string bookId in bookIds)
                    {
                        using (SqlDataAdapter insertAdapter = new SqlDataAdapter())
                        {
                            insertAdapter.InsertCommand = new SqlCommand(insertQuery, connection);
                            insertAdapter.InsertCommand.Parameters.AddWithValue("@BookId", bookId);
                            insertAdapter.InsertCommand.Parameters.AddWithValue("@ClusterId", clusterId);
                            insertAdapter.InsertCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                            insertAdapter.InsertCommand.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<BookIdDetails> GetCreateClusterData(List<string> bookIds)
        {
            var results = new List<BookIdDetails>();
            if (bookIds == null || bookIds.Count == 0)
                return results;

            var parameters = string.Join(", ", bookIds.Select((id, i) => $"@id{i}"));
            string query = $"select * from namesData where BookId IN ({parameters})";
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    for (int i = 0; i < bookIds.Count; i++)
                        command.Parameters.AddWithValue($"@id{i}", bookIds[i]);

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        connection.Open();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];
                            BookIdDetails item = createNewBookIdDetails(row);

                            // מיפוי שדות נוספים שלא קיימים ב-createNewBookIdDetails
                            //item.ClusterId = row.Table.Columns.Contains("ClusterId") && row["ClusterId"] != DBNull.Value ? row["ClusterId"].ToString().Trim() : null;
                            item.PlaceOfDeath = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("PlaceOfDeath") && row["PlaceOfDeath"] != DBNull.Value ? row["PlaceOfDeath"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("PlaceOfDeathCode") && row["PlaceOfDeathCode"] != DBNull.Value ? row["PlaceOfDeathCode"].ToString().Trim() : null
                            };
                            item.AuthenticDateOfBirth = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("AuthenticDateOfBirth") && row["AuthenticDateOfBirth"] != DBNull.Value ? row["AuthenticDateOfBirth"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("AuthenticDateOfBirthCode") && row["AuthenticDateOfBirthCode"] != DBNull.Value ? row["AuthenticDateOfBirthCode"].ToString().Trim() : null
                            };
                            item.RestoredDateOfBirth = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("RestoredDateOfBirth") && row["RestoredDateOfBirth"] != DBNull.Value ? row["RestoredDateOfBirth"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("RestoredDateOfBirthCode") && row["RestoredDateOfBirthCode"] != DBNull.Value ? row["RestoredDateOfBirthCode"].ToString().Trim() : null
                            };
                            item.AuthenticDateOfDeath = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("AuthenticDateOfDeath") && row["AuthenticDateOfDeath"] != DBNull.Value ? row["AuthenticDateOfDeath"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("AuthenticDateOfDeathCode") && row["AuthenticDateOfDeathCode"] != DBNull.Value ? row["AuthenticDateOfDeathCode"].ToString().Trim() : null
                            };
                            item.RestoredDateOfDeath = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("RestoredDateOfDeath") && row["RestoredDateOfDeath"] != DBNull.Value ? row["RestoredDateOfDeath"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("RestoredDateOfDeathCode") && row["RestoredDateOfDeathCode"] != DBNull.Value ? row["RestoredDateOfDeathCode"].ToString().Trim() : null
                            };
                            item.Gender = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("Gender") && row["Gender"] != DBNull.Value ? row["Gender"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("GenderCode") && row["GenderCode"] != DBNull.Value ? row["GenderCode"].ToString().Trim() : null
                            };
                            item.Fate = new ValueCodeItem
                            {
                                Value = row.Table.Columns.Contains("Fate") && row["Fate"] != DBNull.Value ? row["Fate"].ToString().Trim() : "",
                                Code = row.Table.Columns.Contains("FateCode") && row["FateCode"] != DBNull.Value ? row["FateCode"].ToString().Trim() : null
                            };
                            results.Add(item);
                        }
                    }
                }
            }
            return results;
        }
    }
}
