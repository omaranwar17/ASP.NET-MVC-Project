using APP_DATA_A_10.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Models.Depatments
{
    public class Department :BaseEntity
    {
        
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
