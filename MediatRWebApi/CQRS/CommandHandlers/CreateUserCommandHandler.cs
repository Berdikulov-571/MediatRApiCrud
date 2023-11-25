using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DataAccess;
using MediatRWebApi.Entities;

namespace MediatRWebApi.CQRS.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,int>
    {
        private readonly ApplicationDbContext _context;

        public CreateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<int> IRequestHandler<CreateUserCommand, int>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User();
            user.firstName = request.firstName;
            user.lastName = request.lastName;
            user.Age = request.Age;

            await _context.Users.AddAsync(user);
            int result = await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
