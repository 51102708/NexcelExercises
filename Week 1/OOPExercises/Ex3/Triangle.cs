namespace Ex3
{
    internal class Triangle : Shape
    {
        public Triangle(int parwidth, int parheight)
            : base(parwidth, parheight)
        {
        }

        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }
}