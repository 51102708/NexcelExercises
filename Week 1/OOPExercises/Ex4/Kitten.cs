namespace Ex4
{
    public class Kitten : Cat
    {
        public Kitten(int age, string name)
            : base(age, name, Sex.Female)
        {
        }

        public override string Sound()
        {
            return AnimalSound.Kitten;
        }
    }
}