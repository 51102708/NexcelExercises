namespace Ex1
{
    public class Student : People
    {
        public Student(string name, int classnumber) : base(name)
        {
            ClassNumber = classnumber;
        }

        public int ClassNumber { get; private set; }
    }
}