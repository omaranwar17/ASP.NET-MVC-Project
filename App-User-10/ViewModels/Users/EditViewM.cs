namespace App_User_10.ViewModels.Users
{
    public class EditViewM
    {
        public string Id { get; set; }
        public string Email { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string? LName { get; set; }
        public string? PhoneNumber { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
