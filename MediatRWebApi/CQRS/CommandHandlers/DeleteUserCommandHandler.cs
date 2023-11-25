using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DataAccess;
using MediatRWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRWebApi.CQRS.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId);

            if (user != null)
            {
                _context.Users.Remove(user);
                int result = await _context.SaveChangesAsync(cancellationToken);

                return result;
            }

            return 0;
        }
    }
}
