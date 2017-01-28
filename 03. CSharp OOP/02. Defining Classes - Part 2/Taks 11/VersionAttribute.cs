namespace _02.Defining_Classes___Part_2
{
    using System;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Interface |
                    AttributeTargets.Enum |
                    AttributeTargets.Method,
                    AllowMultiple = false)
]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }

        public int Minor { get; private set; }

        public override string ToString()
        {
            return string.Format("Version: {0}.{1}", this.Major, this.Minor);
        }
    }
}
