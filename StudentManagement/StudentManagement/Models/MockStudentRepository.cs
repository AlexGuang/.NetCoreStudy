using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Models
{       /// <summary>
        /// 模拟数据
        /// </summary>
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _students;
        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student(){Id = 1, Name ="张三",ClassName=ClassNameEnum.FirstGrage, Email="tony_zhang@233.com"},
                new Student(){Id = 2, Name ="李四",ClassName=ClassNameEnum.SecondGrage, Email="mick_Li@233.com"},
                new Student(){Id = 3, Name ="王二",ClassName=ClassNameEnum.ThirdGrage, Email="hahah@233.com"},
                new Student(){Id = 4, Name ="赵五",ClassName=ClassNameEnum.FourGrage, Email="zhaoshen@233.com"}
            };
        }

        public Student AddNewStudent(Student student)
        {
           student.Id = _students.Max(s=>s.Id) + 1;
            _students.Add(student);
            return student;
        }

        public Student DeleteStudent(int id)
        {
           Student student = _students.FirstOrDefault(s=>s.Id==id);
            if (student != null)
            {
                _students.Remove(_students.FirstOrDefault(s => s.Id == id));
                return student;
            }
            else
                return null;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return   _students.FirstOrDefault(a => a.Id == id);
        }

        public Student UpdateStudent(Student student)
        {
          Student student1 = _students.FirstOrDefault(s=>s.Id==student.Id);
            if (student1 != null)
            {
                student1.Name = student.Name;
                student1.Email = student.Email;
                student1.ClassName = student.ClassName;
            }
            
                
            return student1;
        }
    }
}

