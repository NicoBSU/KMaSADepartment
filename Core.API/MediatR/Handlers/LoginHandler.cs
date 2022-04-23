using Core.API.MediatR.Commands;
using Core.API.MediatR.Query;
using KMaSA.Models.Entities;
using MediatR;

namespace Core.API.MediatR.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginDto>
    {
        public

        public async Task<LoginCommand> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return
        }
    }
}
