public class ImportExternalUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IExternalUserService _externalUserService;
    private readonly ICompanyRepository _companyRepository;
    private readonly ImportExternalUserValidator _validator;
    public Task<Result<UserDto>> Handle(ImportExternalUserCommand cmd);
}