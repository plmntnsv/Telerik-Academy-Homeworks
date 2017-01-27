using System;

namespace _04._06.Triangle_surface_by_two_sides_and_an_angle
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine()),
                   sideB = double.Parse(Console.ReadLine()),
                   angle = double.Parse(Console.ReadLine());
            Triangle tri = new Triangle(sideA, sideB, Triangle.FindSine(angle));      
            
            Console.WriteLine("{0:F2}",tri.GetArea);
        }
    }
    class Triangle
    {
        public static double FindSine (double angle)
        {
            double sine = Math.Sin(angle * (Math.PI / 180));
            return sine;
        }        
        public Triangle(double a, double b, double c)
        {
            GetArea = (a * b) * (c / 2);
        }
        public double GetArea { get; private set; }
    }
}
/*Description
https://www.google.bg/search?q=find+area+of+triangle+with+two+sides+and+an+angle&oq=find+area+of+triangle+by+two+sides+&aqs=chrome.1.69i57j0l4.10444j0j4&sourceid=chrome&ie=UTF-8
http://www.teacherschoice.com.au/maths_library/angles/angles.htm
Write program that calculates the surface of a triangle by given two sides and an angle between them.

Input

On the first line you will receive the length of the first side of the triangle
On the second line you will receive the length of the second side of the triangle
On the third line you will receive the angle between the given sides
Angle is given in degrees
Output

Print the surface of the rectangle with two digits of precision
Constraints

Input data describes a valid triangle
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10
7
25	    14.79
*/
