using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository istudentRepository)
        {
            _studentRepository = istudentRepository;
        }
        public string Index()
        {
            return _studentRepository.GetStudent(1).Name;

        }
        public IActionResult Details()
        {
            Student model = _studentRepository.GetStudent(1);
            return View(model);
        }
    }
}
