using System.ComponentModel.DataAnnotations;

namespace BlazorDemoApp_02.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; } = null!; 
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Designation { get; set; }
    }
}
