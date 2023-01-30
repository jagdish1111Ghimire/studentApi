using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api;
[Table("StudentsApi")]
public class Student
{
    [Key]
    public int StuId { get; set; }

    public string StuName { get; set; } = string.Empty;

    public string StuAddress { get; set; } = string.Empty;

}