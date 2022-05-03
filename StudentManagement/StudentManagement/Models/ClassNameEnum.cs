using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    /// <summary>
    /// 班级的枚举
    /// </summary>
    public enum ClassNameEnum
    {
        [Display(Name="未分配")]
        None,
        [Display(Name = "一年级")]
        FirstGrage,
        [Display(Name = "二年级")]
        SecondGrage,
        [Display(Name = "三年级")]
        ThirdGrage,
        [Display(Name = "四年级")]
        FourGrage

    }
}
