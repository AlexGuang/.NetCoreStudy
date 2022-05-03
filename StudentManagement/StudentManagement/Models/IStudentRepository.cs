using System.Collections.Generic;

namespace StudentManagement.Models
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 通过ID来获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);
        /// <summary>
        /// 获取所有学生信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudent();
        /// <summary>
        /// 添加一个学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student AddNewStudent(Student student);
        /// <summary>
        /// 更新一名学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student UpdateStudent(Student student);
        /// <summary>
        /// 删除一名学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student DeleteStudent(int id);
    }
}
