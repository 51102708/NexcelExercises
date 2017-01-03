namespace Ex3
{
    internal class Triangle : Shape
    {
        public Triangle(int width, int height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }
}