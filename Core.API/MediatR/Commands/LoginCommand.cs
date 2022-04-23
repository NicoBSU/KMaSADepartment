using KMaSA.Models.Entities;
using MediatR;

namespace Core.API.MediatR.Commands
{
    public class LoginCommand : IRequest<UserCredentials>
    {
        public UserCredentials UserCredentials { get; set; }
        public LoginCommand(UserCredentials userCredentials)
        {
            UserCredentials = userCredentials;
        }
    }
}
