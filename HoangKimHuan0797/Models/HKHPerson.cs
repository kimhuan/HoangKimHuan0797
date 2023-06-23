using System.ComponentModel.DataAnnotations;

namespace HoangKimHuan0797.Models;

public class HKHPerson
{
    [Key]
    public string PersonID { get; set; }
    
    public string PersonName { get; set; }

    public string PersonPhone { get; set; }
}