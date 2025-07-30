using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISystemClusterService
    {

        //string GetMessageFromService();

        ClusterGroupWithCrmLinks GetClusterGroupDetails(int groupId);
        StatisticData GetStatisticData();

        BookIdDetails AddBookId(string bookId);

        List<BookIdDetails> AddBookIdsByClusterId(string clusterId);

        List<BookIdDetails> GetCreateClusterData(List<string> bookIds);

    }
}
