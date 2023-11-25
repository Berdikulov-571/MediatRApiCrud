using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DataAccess;
using MediatRWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatRWebApi.CQRS.CommandHandlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, User>
    {
        private readonly ApplicationDbContext _context;

        public GetUserByIdCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == request.UserId);

            return user;
        }
    }
}
