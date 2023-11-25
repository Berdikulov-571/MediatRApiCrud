using MediatR;
using MediatRWebApi.CQRS.Commands;
using MediatRWebApi.DTOs;
using MediatRWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MediatRWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] CreateUserCommand user)
        {
            int result = await _mediator.Send(user);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<User> users = await _mediator.Send(new GetAllUsersCommand());

            return Ok(users);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteAsync(int UserId)
        {
            int result = await _mediator.Send(new DeleteUserCommand() { UserId = UserId });

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int UserId)
        {
            User user = await _mediator.Send(new GetUserByIdCommand()
            {
                UserId = UserId
            });

            return Ok(user);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync(UserUpdateDto user)
        {
            object res = await _mediator.Send(user);

            return Ok(res);
        }
    }
}