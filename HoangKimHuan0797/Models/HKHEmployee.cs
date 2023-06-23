using System.ComponentModel.DataAnnotations;

namespace HoangKimHuan0797.Models;

public class HKHEmployee
{
    [Key]
    public string HKHEmployeeID { get; set; }
    
    public string HKHEmployeeName { get; set; }
    public string HKHEmployeeAddress { get; set; }
}