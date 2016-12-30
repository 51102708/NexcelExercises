namespace Ex1
{
    using System.Collections.Generic;

    public class Teacher : People
    {
        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            Disciplines = disciplines;
        }

        public List<Discipline> Disciplines { get; private set; }
    }
}