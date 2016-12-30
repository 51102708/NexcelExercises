namespace Ex4
{
    public class Frog : Animal
    {
        public Frog(int age, string name, Sex sex)
            : base(age, name, sex)
        {
        }

        public override string Sound()
        {
            return AnimalSound.Frog;
        }
    }
}