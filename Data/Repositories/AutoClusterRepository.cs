using Data.Models;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using Data.Models.DTO;

namespace Data.Repositories
{
    public class AutoClusterRepository : RepositoryBase, IAutoClusterRepository
    {
        private const int ChunkSize = 100;

        public AutoClusterRepository(IConnectionFactory f )
            : base(f, "AutoClusterDB") {
        }

        /* ---------- SapirClusters ------------------------------------------------ */
 
        public ChunkResult<SapirClusterTab> GetSapirClusters(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT ClusterID, Comment, DateOfReport
            FROM  dbo.SapirClusters
            ORDER BY ClusterID
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.SapirClusters;";

            return Query(
                sql,
                r => new SapirClusterTab
                {
                    ClusterID = r.GetInt32(0),
                    Comment = r.GetBoolean(1),
                    DateOfReport = r.GetDateTime(2),
                },
                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- ClustersWithMissingFields ------------------------------------ */
        public ChunkResult<MissingFieldsTab> GetMissingFields(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT CNT, ClusterID, MissingField, Comments, Status,
                   Assignee, DateOfReport, AssigneeDate
            FROM  dbo.ClustersWithMissingFields
            ORDER BY ClusterID
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.ClustersWithMissingFields;";

            return Query(
                sql,
               r => new MissingFieldsTab
               {
                   CNT = r.IsDBNull(0) ? 0 : r.GetInt32(0),
                   ClusterID = r.GetInt32(1),
                   MissingField = r.IsDBNull(2) ? null : r.GetString(2),
                   Comments = r.IsDBNull(3) ? null : r.GetString(3),          
                   Status = r.GetBoolean(4),
                   Assignee = new AutoClusterUser      
                   {
                       Id = r.IsDBNull(5) ? -1 : r.GetInt32(5)
                   },
                   DateOfReport = r.IsDBNull(6) ? (DateTime?)null : r.GetDateTime(6),
                   AssigneeDate = r.IsDBNull(7) ? (DateTime?)null : r.GetDateTime(7)
               },

                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- GroupsForClusterApprovalSystem -------------------------------- */
        public ChunkResult<ApprovalGroupsTab> GetApprovalGroups(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT GroupID, Score, Status, Assignee, DateOfReport, AssigneeDate
            FROM  dbo.GroupsForClusterApprovalSystem
            ORDER BY GroupID
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.GroupsForClusterApprovalSystem;";

            return Query(
                sql,
                r => new ApprovalGroupsTab
                {
                    GroupID = r.GetInt32(0),
                    Score = (int)(r.IsDBNull(1) ? (int?)null : r.GetInt32(1)),
                    Status = r.GetBoolean(2),
                    Assignee = new AutoClusterUser
                    {
                        Id = r.IsDBNull(3) ? -1 : r.GetInt32(3)
                    },
                    DateOfReport = r.IsDBNull(4) ? (DateTime?)null : r.GetDateTime(4),
                    AssigneeDate = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5)
                },
                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- ItemsForCheckList -------------------------------------------- */
        public ChunkResult<CheckListItemsTab> GetCheckListItems(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT GroupID, Score, Status, Assignee, DateOfReport, AssigneeDate
            FROM  dbo.ItemsForCheckList
            ORDER BY GroupID
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.ItemsForCheckList;";

            return Query(
                sql,
            r => new CheckListItemsTab
            {
                GroupID = r.GetInt32(0),
                Score = (int)(r.IsDBNull(1) ? (int?)null : r.GetInt32(1)),
                Status = r.GetBoolean(2),
                Assignee = new AutoClusterUser
                {
                    Id = r.IsDBNull(3) ? -1 : r.GetInt32(3)
                },
                DateOfReport = r.IsDBNull(4) ? (DateTime?)null : r.GetDateTime(4),
                AssigneeDate = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5)
            },
                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- GroupsWithDifferentClusters ----------------------------------- */
        public ChunkResult<DifferentClustersTab> GetDifferentClusters(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT BookID, ClustersIDs, Status, Assignee, DateOfReport, AssigneeDate
            FROM  dbo.GroupsWithDifferentClusters
            ORDER BY BookID
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.GroupsWithDifferentClusters;";

            return Query(
                sql,
            r => new DifferentClustersTab
            {
                BookID = r.GetInt32(0),
                ClustersIDs = r.IsDBNull(1) ? null : r.GetString(1),
                Status = r.GetBoolean(2),
                Assignee = new AutoClusterUser
                {
                    Id = r.IsDBNull(3) ? -1 : r.GetInt32(3)
                },
                DateOfReport = r.IsDBNull(4) ? (DateTime?)null : r.GetDateTime(4),
                AssigneeDate = r.IsDBNull(5) ? (DateTime?)null : r.GetDateTime(5)
            },
                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- ErrorMessages -------------------------------------------------- */
        public ChunkResult<ErrorMessagesTab> GetErrorMessages(int chunkNumber)
        {
            int offset = chunkNumber * ChunkSize;
            string sql = @"
            SELECT ErrorMessage, Status, Assignee, DateOfReport, AssigneeDate
            FROM  dbo.ErrorMessages
            ORDER BY DateOfReport DESC
            OFFSET @offset ROWS FETCH NEXT @chunkSize ROWS ONLY;

            SELECT COUNT(*) FROM dbo.ErrorMessages;";

            return Query(
                sql,
                r => new ErrorMessagesTab
                {
                    ErrorMessage = r.IsDBNull(0) ? null : r.GetString(0),
                    Status = r.GetBoolean(1),
                    Assignee = new AutoClusterUser
                    {
                        Id = r.IsDBNull(2) ? -1 : r.GetInt32(2)
                    },
                    DateOfReport = r.IsDBNull(3) ? (DateTime?)null : r.GetDateTime(3),
                    AssigneeDate = r.IsDBNull(4) ? (DateTime?)null : r.GetDateTime(4)
                },
                ChunkParams(offset),
                chunkNumber,
                ChunkSize);
        }

        /* ---------- helper -------------------------------------------------------- */
        private static SqlParameter[] ChunkParams(int offset) => new[]
 {
        new SqlParameter("@offset",    SqlDbType.Int) { Value = offset },
        new SqlParameter("@chunkSize", SqlDbType.Int) { Value = ChunkSize }
        };


 
        public void updateStatus(int  clusterId, string tableName)
        {
            string sql = $@"UPDATE [{tableName}] SET Status = 1 - Status WHERE ClusterID = @Cluster";

            var parameters = new[]
            {
                new SqlParameter("@Cluster",  SqlDbType.Int) { Value = clusterId  }
            };

            _ = ExecuteAsync(sql, parameters);
        }

        public void updateAssignee(int clusterId, int assygneeId, string tableName)
        {
            string sql = $@"UPDATE [{tableName}] SET Assignee = @Assignee WHERE ClusterID = @Cluster";

            var parameters = new[]
            {
                new SqlParameter("@Cluster",  SqlDbType.Int) { Value = clusterId  },
                new SqlParameter("@Assignee", SqlDbType.Int) { Value = assygneeId }
            };
            _ = ExecuteAsync(sql, parameters);
        }
    }

}
