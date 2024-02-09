using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudent.Models
{
    [Table("SubjectMarks")]
    public class SubjectMarks
    {
        public int Id { get; set; }
        public int English { get; set; }
        public int Hindi { get; set; }
        public int Physics { get; set; }
        public int Mathematics { get; set; }
        public int Chemistry { get; set; }


    }
}
