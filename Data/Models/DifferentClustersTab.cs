using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DifferentClustersTab
    {
        public int BookID { get; set; }
        public string ClustersIDs { get; set; }
        public bool Status { get; set; }
        public AutoClusterUser ?Assignee { get; set; }
        public DateTime ?DateOfReport { get; set; }
        public DateTime ?AssigneeDate { get; set; }
    }
}
