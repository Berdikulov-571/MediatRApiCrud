using MediatR;
using MediatRWebApi.Entities;

namespace MediatRWebApi.CQRS.Commands
{
    public class GetUserByIdCommand : IRequest<User>
    {
        public int UserId { get; set; }
    }
}
