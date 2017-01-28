namespace _02.Defining_Classes___Part_2
{
    using System;

    public struct Point3D
    {
        // fields
        private static readonly Point3D PointO = new Point3D(0, 0, 0);

        // Constructors
        public Point3D(decimal x, decimal y, decimal z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D(int x, int y, int z)
            : this((decimal)x, (decimal)y, (decimal)z)
        {
        }

        // Properties
        public static Point3D O
        {
            get
            {
                return PointO;
            }
        }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        // Methods
        public override string ToString()
        {
            return string.Format("x={0} y={1} z={2}", this.X, this.Y, this.Z);
        }
    }
}
