using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudent.Models
{
    [Table("Student")]
    public class Student
    {public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
