using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_information_system_2.Models
{
    public class AddCourseViewModel
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
