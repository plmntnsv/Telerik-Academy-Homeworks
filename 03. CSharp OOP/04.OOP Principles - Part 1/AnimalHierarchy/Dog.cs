namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Gender gender) 
            : base(age, name, gender)
        {
            this.AnimalType = AnimalType.Dog;
        }

        public override string MakeSound()
        {
            return "Woof-woof";
        }
    }
}
