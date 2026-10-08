using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_BUS_L_10.DTO.Depatments
{
    public class AddDepartmentDbo
    //{

    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //    public string Code { get; set; }
    //    public DateOnly DataOfCreation { get; set; }
    //}

    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "تاريخ الإنشاء مطلوب")]
        public DateOnly DataOfCreation { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
