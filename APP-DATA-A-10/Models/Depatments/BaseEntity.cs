using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_DATA_A_10.Models.Depatments
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastMidifiedBy { get; set; }
        public DateTime LastMidifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
