namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        public Animal(int age, string name, Gender gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
            this.AnimalType = AnimalType.Unknown;
        }

        public int Age { get; private set; }

        public string Name { get; set; }

        public Gender Gender { get; private set; }

        public AnimalType AnimalType { get; set; }

        public static double AverageAge(IEnumerable<Animal> animals)
        {
            ////var result = animals.GroupBy(anim => anim.AnimalType).Select(y => y.Select(z => new { AnimalType = z.AnimalType, AverageAge = y.Average(x => x.Age) })).ToList();
            ////foreach (var animal in result)
            ////{
            ////    foreach (var type in animal)
            ////    {
            ////        Console.WriteLine(type);
            ////    }
            ////}
            return animals.Average(x => x.Age);
        }

        public virtual string MakeSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return $"{this.MakeSound()} my name is {this.Name} and I am a {this.Gender} {this.AnimalType}. I am {this.Age}-years-old {this.MakeSound()}.";
        }
    }
}
