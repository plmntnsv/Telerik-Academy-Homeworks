namespace _04.OOP_Principles___Part_1.School
{
    using System;
    using System.Collections.Generic;

    public class Student : Person, IComment
    {
        private static List<int> uniqueClassNumber = new List<int>();
        private List<string> comments;
        private int classNumber;

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
            this.comments = new List<string>();
        }
        
        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (UniqueClassNumber.Contains(value))
                {
                    throw new ArgumentException($"Student's number must be unique. '{value}' is already taken!");
                }
                else if (value <= 0)
                {
                    throw new ArgumentException("Student's number cannot be zero or negative!");
                }

                this.classNumber = value;
                UniqueClassNumber.Add(value);
            }
        }

        public string Comments
        {
            get
            {
                return string.Join(", ", this.comments);
            }
        }

        internal static List<int> UniqueClassNumber
        {
            get
            {
                return uniqueClassNumber;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
