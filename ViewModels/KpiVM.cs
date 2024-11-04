namespace PMSWebApi.ViewModels
{
    public class KpiVM
    {
        public int Id { get; set; }

        public string KPIName { get; set; } = string.Empty;

        public string KPIDescription { get; set; } = string.Empty;

        public string EmployeeComments { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public int EmployeeRatings { get; set; }

        public int ManagerRatings { get; set; }

        public int EmployeeOverallRating { get; set; }

        public int ManagerOverallRating { get; set; }

        public DateTime CreatedDate { get; set; }

        public int RoundId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
    }
}
