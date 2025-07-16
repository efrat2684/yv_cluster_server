using Data.Models;
using Data.Models.DTO;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IAutoClusterRepository
    {
        public ChunkResult<SapirClusterTab> GetSapirClusters(int chunkNumber);
        public ChunkResult<MissingFieldsTab> GetMissingFields(int chunkNumber);
        public ChunkResult<ApprovalGroupsTab> GetApprovalGroups(int chunkNumber);
        public ChunkResult<CheckListItemsTab> GetCheckListItems(int chunkNumber);
        public ChunkResult<DifferentClustersTab> GetDifferentClusters(int chunkNumber);
        public ChunkResult<ErrorMessagesTab> GetErrorMessages(int chunkNumber);

        public void updateStatus(int clusterId,string tableName);
        public void updateAssignee(int clusterId, int assygneeId, string tableName);
    }
}
