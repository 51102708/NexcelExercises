namespace Ex1
{
    public abstract class People
    {
        protected People(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}