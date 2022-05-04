using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                 new Student
                 {
                     Id = 1,
                     Name = "李晓光",
                     ClassName = ClassNameEnum.FourGrage,
                     Email = "shinevvip@gmail.com"
                 },
                 new Student
                 {
                     Id = 2,
                     Name = "陈婧瑶",
                     ClassName = ClassNameEnum.FourGrage,
                     Email = "oliviachen797@gmail.com"

                 },
                 new Student
                 {
                     Id = 3,
                     Name = "张大拿",
                     ClassName = ClassNameEnum.FourGrage,
                     Email = "haha@ffsd.com"
                 });
        }
    }
}
