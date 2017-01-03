namespace Ex4
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var arrAnimal = new Animal[]
            {
                new Dog(4, "Beggie", Sex.Male),
                new Frog(3, "MrFrog", Sex.Male),
                new Kitten(5, "HelloKitty"),
                new Tomcat(7, "Mr Tom")
            };

            arrAnimal.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Average age: " + arrAnimal.Average(a => a.Age));
            foreach (Animal animal in arrAnimal)
            {
                Console.WriteLine(Animal.GetAnimalKindBySound(animal.Sound()));
            }

            Console.ReadLine();
        }
    }
}