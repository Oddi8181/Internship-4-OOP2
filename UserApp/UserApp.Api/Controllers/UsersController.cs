using Microsoft.AspNetCore.Mvc;
using UserApp.Application.Users.Commands.CreateUser;
using UserApp.Application.Users.Commands.UpdateUser;
using UserApp.Application.Users.Queries;
using UserApp.Application.Users.Commands.ImportExternalUser;
namespace UserApp.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly CreateUserHandler _createHandler;
        private readonly GetUserByIdHandler _getByIdHandler;
        private readonly GetAllUsersHandler _getAllHandler;
        private readonly ChangePasswordHandler _changePasswordHandler;
        private readonly DeactivateUserHandler _deactivateHandler;
        private readonly ImportExternalUserHandler _importHandler;

        public UsersController(
            CreateUserHandler createHandler,
            GetUserByIdHandler getByIdHandler,
            GetAllUsersHandler getAllHandler,
            ChangePasswordHandler changePasswordHandler,
            DeactivateUserHandler deactivateHandler,
            ImportExternalUserHandler importHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
            _changePasswordHandler = changePasswordHandler;
            _deactivateHandler = deactivateHandler;
            _importHandler = importHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getAllHandler.Handle();
            return Ok(result.Value);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getByIdHandler.HandleAsync(new GetUserByIdQuery { Id = id });
            if (result.HasErrors)
                return BadRequest(result.ValidationResult);
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand cmd)
        {
            var result = await _createHandler.Handle(cmd);
            if (result.HasErrors)
                return BadRequest(result.ValidationResult);
            return Ok(result.Value);
        }

        [HttpPut("{id:int}/password")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordCommand cmd)
        {
            cmd.UserId = id;

            var result = await _changePasswordHandler.Handle(cmd);
            if (result.HasErrors)
                return BadRequest(result.ValidationResult);
            return Ok(result.Value);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var result = await _deactivateHandler.Handle(new DeactivateUserCommand { Id = id});
            if (result.HasErrors)
                return BadRequest(result.ValidationResult);
            return Ok();
        }

        [HttpPost("import-external")]
        public async Task<IActionResult> Import([FromBody] ImportExternalUserCommand cmd)
        {
            var result = await _importHandler.Handle(cmd);
            if (result.HasErrors)
                return BadRequest(result.ValidationResult);
            return Ok(result.Value);
        }
    }
}
