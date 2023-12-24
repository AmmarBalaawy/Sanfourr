using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Knowledge_Of_Univarsity.Models
{
    public class Admin
    {
        [Key] 
        public int Id { get; set; }
        [DisplayName("Username")]
        public string AdminName { get; set; }
        public string Password {get; set; }

    }
}
