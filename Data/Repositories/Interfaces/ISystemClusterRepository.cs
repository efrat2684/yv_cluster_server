using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
     public interface ISystemClusterRepository
    {
        string GetMessage();
        ClusterGroupWithCrmLinks GetClusterGroupDetails(int groupId);
        StatisticData GetStatisticData();

    }
}
