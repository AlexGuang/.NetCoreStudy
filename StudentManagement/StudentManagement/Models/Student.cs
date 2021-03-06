using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{           
    /// <summary>
    /// 学生模型
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="请输入您的名字"),MaxLength(50,ErrorMessage ="名字的长度不能超过50个字符")]
        [Display(Name ="姓名")]
        public string Name { get; set; }
        [Display(Name ="班级信息")]
        [Required(ErrorMessage ="请选择班级信息")]
        public ClassNameEnum? ClassName { get; set; }
        [Display(Name="电子邮件")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",
            ErrorMessage ="邮箱的格式不正确")]
        [Required(ErrorMessage ="请输入邮箱地址")]            
        public string Email { get; set; }
        public string PhotoPath { get; set; }
      
    }
}
