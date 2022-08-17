using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JacquelynneHeiman_Aeries.Models;
using JacquelynneHeiman_Aeries.Services;

namespace JacquelynneHeiman_Aeries.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<StudentModel> students = new List<StudentModel>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        //get the student data from the mySql database
        StudentsDAO studentsDAO = new StudentsDAO();
        students = studentsDAO.GetStudentData();

        //get the contacts for each student
        foreach(StudentModel student in students)
        {
            student.GetContacts();
        }
    }

    public IActionResult Index()
    {
        ViewBag.Counter = 0;
        return View(students);
    }

    public IActionResult GetStudentInfo()
    {
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

