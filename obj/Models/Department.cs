using System.ComponentModel.DataAnnotations;

namespace Student_information_system_2.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
