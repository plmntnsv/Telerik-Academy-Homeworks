using System;

namespace Methods
{
    public class Methods
    {
        static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new InvalidOperationException("Sides should be positive.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Empty or null array provided!");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            double checkedNumber;
            bool isNumber = double.TryParse(number.ToString(), out checkedNumber);
            if (!isNumber)
            {
                throw new ArgumentException("Invalid number!");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format!");
            }
        }


        public static double CalculateDistance(double pointXOne, double pointYOne, double pointXTwo, double pointYTwo)
        {
            double distance = Math.Sqrt((pointXTwo - pointXOne) * (pointXTwo - pointXOne) + (pointYTwo - pointYOne) * (pointYTwo - pointYOne));
            return distance;
        }

        public static bool FindIfHorizontal(double pointXOne, double pointYOne, double pointXTwo, double pointYTwo, out bool isHorizontal)
        {
            isHorizontal = (pointYOne == pointYTwo);
            return isHorizontal;
        }

        public static bool FindIfVertical(double pointXOne, double pointYOne, double pointXTwo, double pointYTwo, out bool isVertical)
        {
            isVertical = (pointXOne == pointXTwo);
            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));

            bool horizontal, vertical;
            FindIfHorizontal(3, -1, 3, 2.5, out horizontal);
            FindIfVertical(3, -1, 3, 2.5, out vertical);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella.OtherInfo));
        }
    }
}
