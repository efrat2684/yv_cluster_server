using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CheckListItemsTab
    {
        public int GroupID { get; set; }

        public int Score { get; set; }

        public bool Status { get; set; }

        public AutoClusterUser ?Assignee { get; set; }

        public DateTime ?DateOfReport { get; set; }

        public DateTime ?AssigneeDate { get; set; }

    }
}
