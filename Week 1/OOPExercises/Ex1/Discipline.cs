namespace Ex1
{
    public class Discipline
    {
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            Name = name;
            NumberOfExercises = numberOfExercises;
            NumberOfLectures = numberOfLectures;
        }

        public string Name { get; private set; }

        public int NumberOfLectures { get; private set; }

        public int NumberOfExercises { get; private set; }
    }
}