using System.ComponentModel.DataAnnotations;

namespace PMSWebApi.ViewModels
{
    public class EmployeeVM
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public string LoginId { get; set; } = string.Empty;
    }
}
