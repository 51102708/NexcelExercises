namespace Ex4
{
    public class Tomcat : Cat
    {
        public Tomcat(int age, string name)
            : base(age, name, Sex.Male)
        {
        }

        public override string Sound()
        {
            return AnimalSound.Tomcat;
        }
    }
}