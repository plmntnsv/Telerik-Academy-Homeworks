namespace _06.Common_Type_System.Student
{
    public class Student
    {
        public Student(string firstName, string lastName, int ssn, string address, string phone, string email, string course, Specialty specialty, Faculty faculty, University university)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.Faculty = faculty;
            this.University = university;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SSN { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public Specialty Specialty { get; set; }

        public Faculty Faculty { get; set; }

        public University University { get; set; }
    }
}
