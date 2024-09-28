using System.ComponentModel.DataAnnotations.Schema;

namespace PMSWebApi.Models
{
    public class Rounds
    {
        public int Id { get; set; }
        public int RoundId { get; set; }

        [ForeignKey("Employees")]  // This indicates that EmployeeId is a foreign key
        public int EmployeeId { get; set; }  // Foreign key property

        [ForeignKey("Employees")]  // This indicates that EmployeeId is a foreign key
        public int ManagerId { get; set; }

        // Navigation property to refer to the related employee
        public Employees? Employee { get; set; }  // Navigation property to Employee

        public Employees? Manager { get; set; }

    }
}
