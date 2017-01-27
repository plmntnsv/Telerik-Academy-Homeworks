namespace _05.OOP_Principles___Part_2.Shapes
{
    using System;

    public class ShapesTest
    {
        public static void Test()
        {
            Shape rectangle = new Rectangle(5, 2);
            Shape triangle = new Triangle(4, 6);
            Shape square = new Square(3);

            Shape[] shapes = new Shape[] { rectangle, triangle, square };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + " surface is " + shape.CalculateSurface());
            }
        }
    }
}