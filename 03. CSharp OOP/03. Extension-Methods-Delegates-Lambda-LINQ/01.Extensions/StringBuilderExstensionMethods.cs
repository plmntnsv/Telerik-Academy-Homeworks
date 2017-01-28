namespace _03.Extension_Methods_Delegates_Lambda_LINQ._01.Extensions
{
    using System.Text;

    public static class StringBuilderExstensionMethods
    {
        public static StringBuilder Substring(this StringBuilder strBldr, int startIndex)
        {
            StringBuilder result = new StringBuilder();
            for (int i = startIndex; i < strBldr.Length; i++)
            {
                result.Append(strBldr[i]);
            }

            return result;
        }

        public static StringBuilder Substring(this StringBuilder strBldr, int startIndex, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0, j = startIndex; i < length; i++, j++)
            {
                result.Append(strBldr[j]);
            }

            return result;
        }
    }
}
