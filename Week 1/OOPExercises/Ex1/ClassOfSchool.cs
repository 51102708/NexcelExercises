using System.Collections.Generic;

namespace Ex1
{
    public class ClassOfSchool
    {
        public ClassOfSchool(List<Teacher> teachers, List<Student> students, string id, string name)
        {
            Teachers = teachers;
            Students = students;
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public List<Teacher> Teachers { get; private set; }

        public List<Student> Students { get; private set; }
    }
}