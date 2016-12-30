namespace Ex4
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Sex sex)
            : base(age, name, sex)
        {
        }

        public override string Sound()
        {
            return AnimalSound.Dog;
        }
    }
}