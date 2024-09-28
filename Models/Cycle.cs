using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PMSWebApi.Models
{
    public class Cycle
    {
        [Key]  // Marks this field as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CycleId { get; set; }
        public string CycleName { get; set; } = string.Empty;
        public int IsActive { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
