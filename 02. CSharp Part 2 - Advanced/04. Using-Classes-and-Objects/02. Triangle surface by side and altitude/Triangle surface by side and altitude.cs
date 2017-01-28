using System;

namespace _04._02.Triangle_surface_by_side_and_altitude
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine()),
                   altitude = double.Parse(Console.ReadLine());
            Triangle tri = new Triangle();
            Console.WriteLine("{0:F2}",tri.ClaculateArea(side, altitude)); 
        }
    }
    class Triangle
    {
        private double side;
        private double altitude;
        
        public double ClaculateArea (double side, double altitude)
        {
            double area = (side * altitude) / 2;

            return area;
        }
    }
}
/*Description

Write program that calculates the surface of a triangle by given a side and an altitude to it.

Input

On the first line you will receive the length of a side of the triangle
On the second line you will receive the altitude to that side
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
23.2
5	58.00
*/