namespace Ex2
{
    public class Human
    {
        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return string.Format("Type: {0},  FirstName: {1}, LastName: {2}", GetType(), FirstName, LastName);
        }
    }
}