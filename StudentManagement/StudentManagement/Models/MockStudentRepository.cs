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
                new Student(){Id = 1, Name ="张三",ClassName="一年级三班", Email="tony_zhang@233.com"},
                new Student(){Id = 2, Name ="李四",ClassName="二年级一班", Email="mick_Li@233.com"},
                new Student(){Id = 3, Name ="王二",ClassName="一年级五班", Email="hahah@233.com"},
                new Student(){Id = 4, Name ="赵五",ClassName="三年级四班", Email="zhaoshen@233.com"}
            };
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return   _students.FirstOrDefault(a => a.Id == id);
        }
    }
}

