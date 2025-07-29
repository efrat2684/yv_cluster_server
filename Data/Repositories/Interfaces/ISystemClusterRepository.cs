using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
     public interface ISystemClusterRepository
    {

        ClusterGroupWithCrmLinks GetClusterGroupDetails(int groupId);
        StatisticData GetStatisticData();

        BookIdDetails AddBookId(string bookId);

        List<BookIdDetails> AddBookIdsByClusterId(string clusterId);

        void AddNewBookIdToExistCluster(string[] bookIds, string clusterId);
        List<BookIdDetails> GetCreateClusterData(List<string> bookIds);


    }
}
