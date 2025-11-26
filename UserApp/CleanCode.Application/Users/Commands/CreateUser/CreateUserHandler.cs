using UserApp.Application.Common.Model;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Commands.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _users;
        private readonly ICompanyRepository _companies;
        private readonly CreateUserValidator _validator;

        public CreateUserHandler(IUserRepository users, ICompanyRepository companies)
        {
            _users = users;
            _companies = companies;
            _validator = new CreateUserValidator(users, companies);
        }

        public async Task<Result<UserDto>> Handle(CreateUserCommand cmd)
        {
            var validation = await _validator.Validate(cmd);
            if (validation.HasErrors)
                return Result<UserDto>.Fail(validation);

            var user = new User
            {
                Name = cmd.Name,
                Username = cmd.Username,
                Email = cmd.Email,
                DateOfBirth = cmd.DateOfBirth,
                Address = cmd.Address,
                Website = cmd.Website,
                Company = cmd.Company,
                IsActive = true
            };
            await _users.InsertAsync(user);

            var dto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Website = user.Website,
                Company = user.Company,
                IsActive = true
            };


            return Result<UserDto>.Ok(dto);
        }
    }
}
