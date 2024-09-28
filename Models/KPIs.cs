using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMSWebApi.Models
{
    public class KPIs
    {
        public int Id { get; set; }

        public string KPIName { get; set; } = string.Empty;

        public string KPIDescription { get; set; } = string.Empty;

        public string EmployeeComments {  get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public int EmployeeRatings { get; set; }

        public int ManagerRatings {  get; set; }

        public int EmployeeOverallRating { get; set; }

        public int ManagerOverallRating { get; set; }



        [ForeignKey("Employees")]  // This indicates that EmployeeId is a foreign key
        public int EmployeeId { get; set; }  // Foreign key property
        
        [ForeignKey("Employees")]  // This indicates that EmployeeId is a foreign key
        public int ManagerId { get; set; }

        // Navigation property to refer to the related employee
        public Employees? Employee { get; set; }  // Navigation property to Employee

        public Employees? Manager { get; set; }
    }
}
