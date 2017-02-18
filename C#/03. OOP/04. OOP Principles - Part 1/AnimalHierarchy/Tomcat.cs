namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, Gender.Male)
        {
            this.AnimalType = AnimalType.Tomcat;
        }
    }
}
