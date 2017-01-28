namespace School
{
    using Common;
    using Contracts;
    using System.Collections.Generic;

    public static class School
    {
        private static int uniqueId = Constants.MinIdNumber;
        internal static List<Student> students = new List<Student>();

        public static int GenerateId()
        {
            int id = uniqueId;
            Validator.ValidateIdUniqueness(id);
            Validator.ValidateIdRange(id, Constants.MinIdNumber, Constants.MaxIdNumber, Constants.MinOrMaxIdNumberReached);
            uniqueId++;
            return id;
        }

        public static void Reset()
        {
            uniqueId = Constants.MinIdNumber;
            students = new List<Student>();
        }
    }
}
