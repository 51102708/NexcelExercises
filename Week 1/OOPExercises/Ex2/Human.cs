namespace Ex2
{
    public class Human
    {
        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("Type: {0},  FirstName: {1}, LastName: {2}", GetType(), FirstName, LastName);
        }
    }
}