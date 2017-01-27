namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name) 
            : base(age, name, Gender.Female)
        {
            this.AnimalType = AnimalType.Kitten;
        }
    }
}
