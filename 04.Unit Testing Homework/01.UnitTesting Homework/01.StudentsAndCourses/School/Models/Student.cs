namespace School
{
    using Common;
    using Contracts;

    public class Student : IStudent
    {
        private string name;
        private int id;

        // You can create either a student with name that will generate automatic ID or
        // a student with name and ID, in both cases it check for correctness of name, uniqueness and range of ID
        public Student(string name)
        {
            this.Name = name;
            this.id = School.GenerateId();
            School.students.Add(this);
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            School.students.Add(this);
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                Validator.ValidateIdUniqueness(value);
                Validator.ValidateIdRange(value, Constants.MinIdNumber, Constants.MaxIdNumber, Constants.MinOrMaxIdNumberReached);
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateNullOrEmptyName(value);
                this.name = value;
            }
        }
    }
}
