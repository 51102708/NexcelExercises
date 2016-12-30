namespace Ex4
{
    public abstract class Animal
    {
        protected Animal(int age, string name, Sex sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public Sex Sex { get; private set; }

        public static string GetAnimalKindBySound(string sound)
        {
            switch (sound)
            {
                case AnimalSound.Dog:
                    return "This is DOG!";

                case AnimalSound.Frog:
                    return "This is Frog!";

                case AnimalSound.Kitten:
                    return "This is Kitten!";

                case AnimalSound.Tomcat:
                    return "This is Tomcat!";

                default:
                    return "I don't know!";
            }
        }

        public abstract string Sound();

        public override string ToString()
        {
            return string.Format("Animal: {0}, Name: {1}, Age: {2}, Sex: {3}, Sound: {4}", GetType(), Name, Age, Sex, Sound());
        }
    }
}