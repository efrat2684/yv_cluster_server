using Data.Models;
using Data.Models.DTO;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AutoClusterService : IAutoclusterService
    {

        private readonly IAutoClusterRepository _autoClusterRepository;

        public AutoClusterService(IAutoClusterRepository sapirClusterTabRepository)
        {
            _autoClusterRepository = sapirClusterTabRepository;
        }

        public ChunkResult<SapirClusterTab> GetSapirClusters(int chunkNumber)
        {
            return _autoClusterRepository.GetSapirClusters(chunkNumber);

        }

        public ChunkResult<MissingFieldsTab> GetMissingFields(int chunkNumber)
        {
            return _autoClusterRepository.GetMissingFields(chunkNumber);
        }

        public ChunkResult<ApprovalGroupsTab> GetApprovalGroups(int chunkNumber)
        {
            return _autoClusterRepository.GetApprovalGroups(chunkNumber);

        }
        public ChunkResult<CheckListItemsTab> GetCheckListItems(int chunkNumber)
        {
            return _autoClusterRepository.GetCheckListItems(chunkNumber);
        }
        public ChunkResult<DifferentClustersTab> GetDifferentClusters(int chunkNumber)
        {
            return _autoClusterRepository.GetDifferentClusters(chunkNumber);
        }
        public ChunkResult<ErrorMessagesTab> GetErrorMessages(int chunkNumber)
        {
            return _autoClusterRepository.GetErrorMessages(chunkNumber);
        }
        public void updateAssignee(int clusterId, int assygneeId, string tableName)
        {
             _autoClusterRepository.updateAssignee(clusterId, assygneeId, tableName);
        }
        public void updateStatus(int clusterId, string tableName)
        {
            _autoClusterRepository.updateStatus(clusterId,tableName);
        }

    }
}
