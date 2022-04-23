using KMaSA.Models.DTO;
using MediatR;

namespace Core.API.MediatR.Commands
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public LoginDto UserCredentials { get; set; }
        public LoginCommand(LoginDto userCredentials)
        {
            UserCredentials = userCredentials;
        }
    }
}
