using System;

namespace Ex4
{
    public class Cat : Animal
    {
        public Cat(int age, string name, Sex sex)
            : base(age, name, sex)
        {
        }

        public override string Sound()
        {
            return AnimalSound.Cat;
        }
    }
}