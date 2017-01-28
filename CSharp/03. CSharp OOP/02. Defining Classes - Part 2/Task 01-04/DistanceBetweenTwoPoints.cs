namespace _02.Defining_Classes___Part_2
{
    using System;

    public static class DistanceBetweenTwoPoints
    {
        public static string Calculate(Point3D firstPoint, Point3D secondPoint)
        {
            decimal distance = (decimal)Math.Sqrt(Math.Pow((double)(secondPoint.X - firstPoint.X), 2) + Math.Pow((double)(secondPoint.Y - firstPoint.Y), 2) + Math.Pow((double)(secondPoint.Z - firstPoint.Z), 2));

            return string.Format("The distance between {0} and {1} is {2:F2}", firstPoint, secondPoint, distance);
        }
    }
}
