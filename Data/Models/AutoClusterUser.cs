using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AutoClusterUser
    {
        public int Id { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public bool ?Role { get; set; }

        public static implicit operator AutoClusterUser?(int? v)
        {
            throw new NotImplementedException();
        }
    }
}
