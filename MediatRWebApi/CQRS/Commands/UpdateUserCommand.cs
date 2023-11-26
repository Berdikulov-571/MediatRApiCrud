using MediatR;
using MediatRWebApi.DTOs;

namespace MediatRWebApi.CQRS.Commands
{
    public class UpdateUserCommand : UserUpdateDto, IRequest<int>
    {

    }
}
