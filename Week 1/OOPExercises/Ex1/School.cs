namespace Ex1
{
    using System.Collections.Generic;

    public class School
    {
        public School(List<ClassOfSchool> classes)
        {
            Classes = classes;
        }

        public List<ClassOfSchool> Classes { get; private set; }
    }
}