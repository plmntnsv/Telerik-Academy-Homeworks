using Academy.Models.Abstractions;

namespace Academy.Tests.Fakes
{
    internal class UserMock : User
    {
        public UserMock(string username) 
            : base(username)
        {
        }
    }
}
