using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class MissingFieldsTab
    {
        public int CNT { get; set; }
        public int ClusterID { get; set; }
        public string? MissingField { get; set; }
        public string? Comments { get; set; }
        public bool Status { get; set; }
        public AutoClusterUser ?Assignee { get; set; }
        public DateTime ?DateOfReport { get; set; }
        public DateTime ?AssigneeDate { get; set; }
    }
}
