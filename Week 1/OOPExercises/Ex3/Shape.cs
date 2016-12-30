namespace Ex3
{
    public abstract class Shape
    {
        protected Shape(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return string.Format("Type: {0}, Width: {1}, Height: {2}, Surface: {3}", GetType(), Width, Height, CalculateSurface());
        }
    }
}