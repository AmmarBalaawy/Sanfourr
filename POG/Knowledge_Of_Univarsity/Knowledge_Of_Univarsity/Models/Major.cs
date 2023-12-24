using System.ComponentModel.DataAnnotations;
namespace Knowledge_Of_Univarsity.Models
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string images { get; set; }
        public string PersonSpecifications { get; set; }
        public string workfields {get;set;}
        public string Courses { get; set; }
        public College college { get; set; }
        public int CollegeId { get; set; }

    }

}
