using System.ComponentModel.DataAnnotations;

namespace BlazorForms.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<Student> Student_R { get; set; }
    }
}