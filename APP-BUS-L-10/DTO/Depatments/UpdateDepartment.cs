using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.DTO.Depatments
{
    public class UpdateDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateOnly DataOfCreation { get; set; }
    }
}
