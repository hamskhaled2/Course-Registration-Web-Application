namespace Student_information_system_2.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateOnly dob { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string major { get; set; }
    }
}
