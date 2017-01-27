namespace _04.OOP_Principles___Part_1.School
{
    using System;
    using System.Collections.Generic;

    public class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private List<string> comments;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
            this.comments = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the discipline cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of lectures cannot be zero or negative");
                }

                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of exercises cannot be zero or negative");
                }

                this.numberOfExercises = value;
            }
        }

        public string Comments
        {
            get
            {
                return string.Join(", ", this.comments);
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
