using MediatR;
using MediatRWebApi.DTOs;

namespace MediatRWebApi.CQRS.Commands
{
    public class CreateUserCommand : UserCreateDto , IRequest<int>
    {

    }
}
