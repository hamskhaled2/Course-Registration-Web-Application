using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_information_system_2.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CreditHours { get; set; }

        public int DeptID { get; set; }
        [ForeignKey("DeptID")]

        public virtual Department Department { get; set; }
    }
}
