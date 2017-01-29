namespace _04.OOP_Principles___Part_1.School
{
    using System.Collections.Generic;

    public interface IComment
    {
        string Comments { get; }

        void AddComment(string comment);
    }
}
