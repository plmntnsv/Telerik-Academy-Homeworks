namespace _04.OOP_Principles___Part_1.School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, IComment
    {
        private List<Discipline> setOfDisciplines;
        private List<string> comments;

        public Teacher(string firstName, string lastName) 
            : base(firstName, lastName)
        {
            this.setOfDisciplines = new List<Discipline>();
            this.comments = new List<string>();
        }

        public string Comments
        {
            get
            {
                return string.Join(", ", this.comments);
            }
        }

        public void Teach(Discipline discipline)
        {
            this.setOfDisciplines.Add(discipline);
        }
        
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
