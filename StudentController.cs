
using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers;

public class StudentController : Controller
{
    private static readonly List<Student> Students = new();
    private static int _nextId = 1;

    // Display student list
    public IActionResult Index()
    {
        return View(Students.OrderBy(s => s.Id).ToList());
    }

    // Display registration form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Receive registration form
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        student.Id = _nextId++;
        Students.Add(student);

        return RedirectToAction(nameof(Index));
    }

    // Display individual student details
    public IActionResult Details(int id)
    {
        Student? student =
            Students.FirstOrDefault(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
}
