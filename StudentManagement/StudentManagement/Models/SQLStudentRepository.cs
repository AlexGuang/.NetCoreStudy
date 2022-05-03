using System.Collections.Generic;

namespace StudentManagement.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public SQLStudentRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Student AddNewStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            if (student!=null)
            {
               _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);

        }

        public Student UpdateStudent(Student updateStudent)
        {
            var student = _context.Students.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
            return updateStudent;
        }
    }
}
