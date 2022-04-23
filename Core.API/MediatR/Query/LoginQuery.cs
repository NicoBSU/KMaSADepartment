using KMaSA.Models.DTO;
using MediatR;

namespace Core.API.MediatR.Query
{
    public class LoginQuery : IRequest<LoginDto>
    {
        public string Password { get; }
        public string Login { get; }

        public LoginQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
