namespace _05.OOP_Principles___Part_2.Shapes
{
    public class Square : Shape
    {
        public Square(double side)
            : base(side, side)
        {
        }

        public override double CalculateSurface()
        {
            double surface = this.Height * this.Width;
            return surface;
        }
    }
}