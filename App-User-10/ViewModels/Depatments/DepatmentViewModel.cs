
using APP_BUS_L_10.DTO.Depatments;

namespace App_User_10.ViewModels.Depatments
{
    public class DepatmentViewModel 
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }
        public DateOnly DataOfCreation { get; set; }

    }
}
