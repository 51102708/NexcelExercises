namespace Ex3
{
    public class Rectangle : Shape
    {
        public Rectangle(int _width, int _height)
            : base(_width, _height)
        {
        }

        public override double CalculateSurface()
        {
            return Width * Height;
        }

        //public override string ToString()
        //{
        //    return "Rectangle - " + base.ToString();
        //}
    }
}