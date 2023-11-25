using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DataAccess;
using MediatRWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRWebApi.CQRS.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId);

            if (user != null)
            {
                user.firstName = request.firstName;
                user.lastName = request.lastName;
                user.Age = request.Age;

                _context.Users.Update(user);
                int result = await _context.SaveChangesAsync(cancellationToken);
                return result;
            }

            return 0;
        }
    }
}