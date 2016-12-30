namespace Ex2
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            Grade = grade;
        }

        public int Grade { get; private set; }

        public override string ToString()
        {
            var baseString = base.ToString();

            return string.Format("{0}, Grade: {1}", baseString, Grade);
        }
    }
}