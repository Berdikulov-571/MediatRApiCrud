using MediatR;
using MediatRWebApi.Entities;

namespace MediatRWebApi.CQRS.Commands
{
    public class GetAllUsersCommand : IRequest<IEnumerable<User>>
    {
    }
}
