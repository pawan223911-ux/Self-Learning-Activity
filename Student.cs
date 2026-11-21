
using System.ComponentModel.DataAnnotations;

namespace StudentCourseRegistration.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter student name.")]
    [StringLength(50, MinimumLength = 2)]
    [Display(Name = "Student Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Enter valid email.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter course.")]
    [StringLength(60, MinimumLength = 2)]
    public string Course { get; set; } = string.Empty;

    [Range(1, 8, ErrorMessage = "Semester must be 1 to 8.")]
    public int Semester { get; set; }
}
