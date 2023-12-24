using System.ComponentModel.DataAnnotations;

namespace Knowledge_Of_Univarsity.Models
{
    public class College
    {
        [Key]

        public int? CollegeId { get; set; }
        public string img { get; set; }
        public string Name { get; set; }
        public List<Major>? majors { get; set; }
    }
}
