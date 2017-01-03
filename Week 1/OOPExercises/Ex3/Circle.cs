namespace Ex3
{
    using System;

    public class Circle : Shape
    {
        public Circle(int width)
            : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return (Width * Height) * Math.PI;
        }
    }
}