namespace _02.Defining_Classes___Part_2
{
    using System;

    public class TestPoint3D
    {
        public static void Test()
        {
            // Array of 3D points
            Point3D[] pointsArr =
                {
                Point3D.O,
            new Point3D(1m, 2m, 3m),
            new Point3D(4m, 5m, 6m),
            new Point3D(7m, 8m, 9m),
            new Point3D(4m, 8m, 3m),
            new Point3D(2m, 22m, 15m),
            new Point3D(12m, 10m, 4m),
            new Point3D(5.4m, 3.7m, 7.43m)
                };

            // Calculate the distance between two 3D points
            Console.WriteLine(DistanceBetweenTwoPoints.Calculate(pointsArr[0], pointsArr[1]));

            // Creating a path(list), and adding to it all the points from the Array
            Path path = new Path();

            foreach (Point3D point in pointsArr)
            {
                path.AddPoint(point);
            }

            // Displaying the path(list)
            path.DisplayPoints();

            // Saving the points to an external txt file, the directory is optional, if left like this it will create the file in the project/bin/debug folder
            foreach (Point3D point in path.PointsList)
            {
                PathStorage.SavePath(point, "test");
            }

            // Displaying the points from an external txt file to the console
            PathStorage.LoadPath("test");

            // Deletes the external txt path file
            PathStorage.DeletePath("test");
        }
    }
}
