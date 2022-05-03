using System.Collections.Generic;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);

        IEnumerable<Student> GetAllStudent();

        Student AddNewStudent(Student student);
    }
}
