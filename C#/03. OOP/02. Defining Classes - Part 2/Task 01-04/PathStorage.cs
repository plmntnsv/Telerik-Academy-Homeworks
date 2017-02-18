namespace _02.Defining_Classes___Part_2
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Point3D point, string fileName, string directory = "")
        {
            string filePath = directory + fileName + ".txt";
            FileInfo file = new FileInfo(filePath);

            ////using (StreamWriter writeToFile = new StreamWriter(filePath, true))
            ////{
            ////    writeToFile.WriteLine(point);
            ////}
            using (StreamWriter sw = file.AppendText())
            {
                sw.WriteLine(point);
            }
        }

        public static void LoadPath(string fileName, string directory = "")
        {
            string filePath = directory + fileName + ".txt";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file cannot be found!");
            }

            FileInfo file = new FileInfo(filePath);
            ////using (StreamReader readFromFile = new StreamReader(filePath))
            ////{
            ////    string s = "";
            ////    while ((s = readFromFile.ReadLine()) != null)
            ////    {
            ////        Console.WriteLine(s);
            ////    }
            ////}
            using (StreamReader readFromFile = file.OpenText())
            {
                string str = string.Empty;
                while ((str = readFromFile.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }
        }

        public static void DeletePath(string fileName, string directory = "")
        {
            string filePath = directory + fileName + ".txt";
            FileInfo file = new FileInfo(filePath);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file cannot be found!");
            }

            file.Delete();
            Console.WriteLine("{0}.txt was successfully deleted.", fileName);
        }
    }
}
