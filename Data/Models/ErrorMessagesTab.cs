using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Models
{
    public class ErrorMessagesTab
    {
        public string ErrorMessage { get; set; }
        public bool Status { get; set; }
        public AutoClusterUser ?Assignee { get; set; }
        public DateTime ?DateOfReport { get; set; }
        public DateTime ?AssigneeDate { get; set; }
    }
}
