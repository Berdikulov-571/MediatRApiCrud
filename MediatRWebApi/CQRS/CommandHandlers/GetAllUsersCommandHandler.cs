using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DataAccess;
using MediatRWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRWebApi.CQRS.CommandHandlers
{
    public class GetAllUsersCommandHandler : IRequestHandler<GetAllUsersCommand, IEnumerable<User>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllUsersCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _context.Users.ToListAsync(cancellationToken);

            return users;
        }
    }
}
