using System.ComponentModel.DataAnnotations;

namespace HoangKimHuan0797.Models;
public class HKHStudent
{
    [Key]
    public string HKHStudentName { get; set; }
    public string HKHStudentAddress { get; set; }
    public string HKHStudentPhone { get; set; }
}
