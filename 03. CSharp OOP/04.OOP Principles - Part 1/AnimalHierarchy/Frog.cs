namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    public class Frog : Animal
    {
        public Frog(int age, string name, Gender gender) 
            : base(age, name, gender)
        {
            this.AnimalType = AnimalType.Frog;
        }

        public override string MakeSound()
        {
            return "Ribbit-ribbit";
        }
    }
}
