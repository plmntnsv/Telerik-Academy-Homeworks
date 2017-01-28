namespace _03.Extension_Methods_Delegates_Lambda_LINQ._03.LINQ_query
{
    using System;
    using System.Linq;

    public static class LongestString
    {
        public static void Test()
        {
            string[] longStrings = new string[]
            {
                "aljdksalasklcaslkjkaljfklasfjlkafjafjsafasf 1",
                "aksjdkahdoiajwdoajdalksdajk 2",
                "alksdajkdsalkdaksdandaks jasdk jasdnajdoqdwq.a,sn a  qiw l nqlwdjqdjanskd qwdhkalsd 2.5",
                "lkajfiaoifjlfnzlkaljkfffskjkjsaojdofaknfa ladjnd ajljkqdlaa 3",
                "aslkjdlkasjda;ofiaf ajksdjka dlkas qwoijqoadkals hqwlkda;jsdl 4",
                "asjfialfjalbkfasfl ahdjk asd akjs dq  oiq dahsda alkdbavdjhfifoqd anbda mnda 5"
            };

            var findLongest = longStrings
                              .OrderByDescending(s => s.Length)
                              .FirstOrDefault();
            Console.WriteLine(findLongest);
        }
    }
}
