namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    public class Cat : Animal
    {
        public Cat(int age, string name, Gender gender) 
            : base(age, name, gender)
        {
            this.AnimalType = AnimalType.Cat;
        }

        public override string MakeSound()
        {
            return "Meow-meow";
        }
    }
}
