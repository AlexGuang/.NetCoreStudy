﻿using Microsoft.AspNetCore.Hosting.Internal;
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
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
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
            {
                Student student = _studentRepository.GetStudent(studentEditViewModel.Id);

                student.Name = studentEditViewModel.Name;
                student.Email = studentEditViewModel.Email;
                student.ClassName = studentEditViewModel.ClassName;

                if (studentEditViewModel.Photo!=null)
                {
                    if (studentEditViewModel.ExistingPhotoPath!=null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", studentEditViewModel.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                        string uniqueFileName = null;                        
                        
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + studentEditViewModel.Photo.FileName;
                        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using(FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            studentEditViewModel.Photo.CopyTo(fs);
                        }
                        // studentEditViewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        _studentRepository.UpdateStudent(student);

                    }
                }
            }
        }





    }
}
