using MediatR;

namespace MediatRWebApi.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
