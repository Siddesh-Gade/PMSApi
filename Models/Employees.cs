using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PMSWebApi.Models
{
    public class Employees
    {
        [Key]  // Marks this field as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public string LoginId { get; set; } = string.Empty;
        public ICollection<KPIs> KPIs { get; set; }
    }
}
