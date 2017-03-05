namespace Task_2.Refactor__Make_Чуек
{
    public class PeopleFactory
    {
        private enum Gender
        {
            Male,
            Female
        };

        private class Person
        {
            public Gender Gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public void CreatePerson(int age)
        {
            Person person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Batkata";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Maceto";
                person.Gender = Gender.Female;
            }
        }
    }
}
