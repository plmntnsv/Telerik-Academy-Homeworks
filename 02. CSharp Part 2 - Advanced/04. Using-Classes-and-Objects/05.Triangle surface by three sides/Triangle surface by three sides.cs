using System;

namespace _04._05.Triangle_surface_by_three_sides
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tri = new Triangle();
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double sideC = double.Parse(Console.ReadLine());
            double perimeter = (sideA + sideB + sideC) / 2;
            tri.Area = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));
            Console.WriteLine("{0:F2}",tri.Area);

        }
    }
    class Triangle
    {
        public double Area { get; set; }
        //public double Area
        //{
        //    get
        //    {
        //        return area;
        //    }
        //    set
        //    {
        //        area = value;
        //    }
        //}
    }
}
/*Description

Write program that calculates the surface of a triangle by given its three sides.

Input

On the first line you will receive the length of the first side of the triangle
On the second line you will receive the length of the second side of the triangle
On the third line you will receive the length of the third side of the triangle
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
11      61.48
12
13	    
*/
