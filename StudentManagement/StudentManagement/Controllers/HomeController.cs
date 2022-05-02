using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System.Collections.Generic;

namespace StudentManagement.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository istudentRepository)
        {
            _studentRepository = istudentRepository;
        }
        
       
       // [Route("[Index]")]
       // [Route("~/")]//通过绝对路径确认即使是空路径也可以路由到此方法
        public IActionResult Index()
        {
            IEnumerable<Student> students = _studentRepository.GetAllStudent();
            //return View("~/Views/Home/Index.cshtml",students);可以随意改变View页面，通过改变路径。 view名称和controller名称并不是强链接
            return View(students);

        }
       // [Route("")]
        
       // [Route("[action]/{id?}")]
        public IActionResult Details(int? id)
        {
            
            HomeDetailsViewModel homeDetailsViewModes = new HomeDetailsViewModel()
            {
                PageTitle = "学生信息",
                Student = _studentRepository.GetStudent(id??1)

            };
            return View(homeDetailsViewModes);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
