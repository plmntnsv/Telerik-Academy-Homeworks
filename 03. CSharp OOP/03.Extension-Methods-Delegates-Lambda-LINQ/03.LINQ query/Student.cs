namespace _03.Extension_Methods_Delegates_Lambda_LINQ._03.LINQ_query
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private int age;

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Student(string firstName, string lastName, int age, string facNumber, string phoneNumber, string email, List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FN = facNumber;
            this.Phone = phoneNumber;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FN { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public List<int> Marks { get; private set; }

        public int GroupNumber { get; private set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 5 || value > 100)
                {
                    throw new ArgumentException("Ivalid student's age.");
                }
                this.age = value;
            }
        }
        
        // Methods
        public string GetMarks()
        {
            return string.Join(", ",this.Marks);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} - {this.age}";
        }
    }
}
