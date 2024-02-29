using System.ComponentModel.DataAnnotations;

namespace BlazorForms.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(8, 15)]
        public int Age { get; set; }

        public DateTime DOB { get; set; }

        [Range(5, 10)]
        public int Standard { get; set; }

        [Required]
        public string Sex { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool Terms { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Select School")]
        public int SchoolId { get; set; }
        public School School_R { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please Select Location")]
        public int LocationId { get; set; }
        public Location Location_R { get; set; }
    }
}
