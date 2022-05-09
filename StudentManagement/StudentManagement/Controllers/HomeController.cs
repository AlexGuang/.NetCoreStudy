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
        public IActionResult Details(int id)
        {
            throw new Exception("此异常发生在Detail视图中");
            Student student = _studentRepository.GetStudent(id);
            if (student==null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound",id);

            }
            //实例化HomeDetailsViewModel并存储Student详细信息和PageTitle
            HomeDetailsViewModel homeDetailsViewModes = new HomeDetailsViewModel()
            {
                PageTitle = "学生信息",
                Student = student

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
               string uniqueFileName = AddImage(model);

                /* string uniqueFileName = null;
                 if (model.Photo != null)
                 {
                     string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                     uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                     string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                     model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                 }*/


                //if (model.Photos!=null&&model.Photos.Count>0)
                //{
                //    foreach (var photo in model.Photos)
                //    {
                //        //必须将图像上传到wwwroot中的images文件夹
                //        //而要获取wwwroot文件夹的路径，我们需要注入ASP.NET Core提供的HostingEnvironment服务
                //        //通过HostingEnvironment服务去获取wwwroot文件夹的路径
                //        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //        //为了确保文件名是唯一的，我们在文件名后附加一个新的GUID值和一个下划线
                //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //        //使用IFormFile接口提供的CopyTo()方法将文件复制到wwwroot/images文件夹
                //        photo.CopyTo(new FileStream(filePath, FileMode.Create));

                //    }
                //}

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

        [HttpGet]
        //创建编辑的视图步骤1.视图，视图模型，2.对应的页面调整
        public ViewResult Edit(int id)
        {
            Student studentSearch=_studentRepository.GetStudent(id);
            StudentEditViewModel model = new StudentEditViewModel
            {
                Id = studentSearch.Id,
                Name = studentSearch.Name,
                Email = studentSearch.Email,
                ClassName = studentSearch.ClassName,
                ExistingPhotoPath = studentSearch.PhotoPath
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel studentEditViewModel)
        {
            if (ModelState.IsValid)//模型验证，保证能通过模型验证 
            {//检查提供的数据是否有效，如果没有通过验证，需要重新编辑学生信息，这样用户就可以更正并从新提交编辑表单
                Student student = _studentRepository.GetStudent(studentEditViewModel.Id);

                student.Name = studentEditViewModel.Name;
                student.Email = studentEditViewModel.Email;
                student.ClassName = studentEditViewModel.ClassName;
                student.PhotoPath = studentEditViewModel.ExistingPhotoPath;
                if (studentEditViewModel.Photo!=null)
                {
                    if (studentEditViewModel.ExistingPhotoPath != null)//
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", studentEditViewModel.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    /*
                    string uniqueFileName = null;                        
                        
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + studentEditViewModel.Photo.FileName;
                    string fileNewPath = Path.Combine(uploadsFolder, uniqueFileName);
                    using(FileStream fs = new FileStream(fileNewPath, FileMode.Create))
                    {
                        studentEditViewModel.Photo.CopyTo(fs);
                    }*/
                     string uniqueFileName = AddImage(studentEditViewModel);
                    // studentEditViewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    student.PhotoPath = uniqueFileName;

                }
                
                Student updateStudent = _studentRepository.UpdateStudent(student);

                return RedirectToAction("Index");
            }
            return View(studentEditViewModel);
        }
        /// <summary>
        /// 生成新图片的保存路径，并把新图片按照保存路径保存在项目中，把路径保存在数据库中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string AddImage (StudentBuilderViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo!=null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string fileNewPath = Path.Combine(uploadsFolder, uniqueFileName);
                using (FileStream fs = new FileStream(fileNewPath, FileMode.Create))
                {
                    model.Photo.CopyTo(fs);
                }
            }
           
            return uniqueFileName;
        }

        public IActionResult Delete(int id)
        {
            Student deletingStudent = _studentRepository.GetStudent(id);
            if (deletingStudent.PhotoPath!=null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", deletingStudent.PhotoPath);
                System.IO.File.Delete(filePath);
            }
            _studentRepository.DeleteStudent(id);
            return RedirectToAction("Index");
        }

    }
}
