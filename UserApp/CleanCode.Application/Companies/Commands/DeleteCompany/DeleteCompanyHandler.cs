using UserApp.Application.Common.Model;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyHandler
    {
        private readonly ICompanyRepository _repo;
        private readonly DeleteCompanyValidator _validator;
        private readonly IUserRepository _userRepository;

        public DeleteCompanyHandler(ICompanyRepository repo, IUserRepository userRepository)
        {
            _repo = repo;
            _validator = new DeleteCompanyValidator(repo);
            _userRepository = userRepository;
        }


        public async Task<Result<bool>> HandleAsync(DeleteCompanyCommand cmd)
        {

            var validation = await _validator.ValidateAsync(cmd);
            if (!await UserAuthHelper.Authenticate(_userRepository, cmd.Username, cmd.Password, validation))
                return Result<bool>.Fail(validation);
            if (validation.HasErrors)
                return Result<bool>.Fail(validation);


            await _repo.DeleteAsync(cmd.Id);
            return Result<bool>.Ok(true);
        }
    }
}
