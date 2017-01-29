namespace _04.OOP_Principles___Part_1.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;

    public static class AnimalHierarchyTest
    {
        public static void Test()
        {
            Dog dog = new Dog(3, "Sharo", Gender.Male);
            Dog anotherDog = new Dog(3, "Shiro", Gender.Male);
            Frog frog = new Frog(1, "Skippy", Gender.Male);
            Cat cat = new Cat(2, "Kat", Gender.Female);
            Cat anotherCat = new Cat(2, "Katz", Gender.Female);
            Kitten kitt = new Kitten(3, "Kit");
            Tomcat tom = new Tomcat(4, "Tom");
            Console.WriteLine("\nA list of different animals:");
            List<Animal> animals = new List<Animal> { dog, anotherDog, frog, cat, anotherCat, kitt, tom };
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("\nAverage age of these animals:");
            Console.WriteLine("{0:F2} years", Animal.AverageAge(animals));

            Console.WriteLine("\nDog array:");
            Dog[] dogArr = new Dog[] { dog, anotherDog, new Dog(4, "Rex", Gender.Male), new Dog(7, "Woofer", Gender.Female) };
            foreach (Dog doge in dogArr)
            {
                Console.WriteLine(doge);
            }

            Console.WriteLine("\nAverage years of all dogs:\n{0:F2} years", Animal.AverageAge(dogArr));
        }
    }
}
