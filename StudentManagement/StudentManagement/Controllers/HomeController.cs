using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System.Collections.Generic;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository istudentRepository)
        {
            _studentRepository = istudentRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetAllStudent();
            return View(students);

        }
        public IActionResult Details()
        {
            
            HomeDetailsViewModel homeDetailsViewModes = new HomeDetailsViewModel()
            {
                PageTitle = "学生信息",
                Student = _studentRepository.GetStudent(3)

            };
            return View(homeDetailsViewModes);
        }
    }
}
