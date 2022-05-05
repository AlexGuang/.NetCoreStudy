using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagement.Controllers
{
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly HostingEnvironment hostingEnvironment;

        public HomeController(IStudentRepository istudentRepository,HostingEnvironment hostingEnvironment)
        {
            _studentRepository = istudentRepository;
            this.hostingEnvironment = hostingEnvironment;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentBuilderViewModel model)
        {
            if (ModelState.IsValid)
            {

          
                string uniqueFileName = null;
                if (model.Photo!=null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath= Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    ClassName = model.ClassName,
                    PhotoPath = uniqueFileName
                };
                _studentRepository.AddNewStudent(newStudent);
                return RedirectToAction("Details", new { id = newStudent.Id });

                    //Student newStudent = _studentRepository.AddNewStudent(student);
                    //
            }
            return View();
        }
    }
}
