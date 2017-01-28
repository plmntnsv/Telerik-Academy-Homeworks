namespace _02.Defining_Classes___Part_2
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        public Path()
        {
            this.PointsList = new List<Point3D>();
        }

        public List<Point3D> PointsList { get; }

        public void AddPoint(Point3D point)
        {
            this.PointsList.Add(point);
        }

        public void DisplayPoints()
        {
            foreach (Point3D point in this.PointsList)
            {
                Console.WriteLine(point.ToString());
            }
        }
    }
}
