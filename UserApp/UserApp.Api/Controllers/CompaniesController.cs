using Microsoft.AspNetCore.Mvc;
using UserApp.Application.Companies.Commands;
using UserApp.Application.Companies.Commands.CreateCompany;
using UserApp.Application.Companies.Commands.DeleteCompany;
using UserApp.Application.Companies.Commands.UpdateCompany;
using UserApp.Application.Companies.Queries;
using UserApp.Application.Companies.Queries.GetAllCompanies;
using UserApp.Application.Companies.Queries.GetCompanyById;

namespace UserApp.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly GetAllCompaniesHandler _getAllHandler;
        private readonly GetCompanyByIdHandler _getByIdHandler;
        private readonly CreateCompanyHandler _createHandler;
        private readonly UpdateCompanyHandler _updateHandler;
        private readonly DeleteCompanyHandler _deleteHandler;

        public CompaniesController(
            GetAllCompaniesHandler getAllHandler,
            GetCompanyByIdHandler getByIdHandler,
            CreateCompanyHandler createHandler,
            UpdateCompanyHandler updateHandler,
            DeleteCompanyHandler deleteHandler)
        {
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string username, [FromQuery] string password)
        {
            var result = await _getAllHandler.HandleAsync(new GetAllCompaniesQuery
            {
                Username = username,
                Password = password
            });

            if (result.HasErrors)
                return BadRequest(result.ValidationResult);

            return Ok(result.Value);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, [FromQuery] string username, [FromQuery] string password)
        {
            var result = await _getByIdHandler.HandleAsync(new GetCompanyByIdQuery
            {
                Id = id,
                Username = username,
                Password = password
            });

            if (result.HasErrors)
                return BadRequest(result.ValidationResult);

            return Ok(result.Value);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand cmd)
        {
            var result = await _createHandler.HandleAsync(cmd);

            if (result.HasErrors)
                return BadRequest(result.ValidationResult);

            return Ok(result.Value);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyCommand cmd)
        {
            cmd.Id = id;
            var result = await _updateHandler.HandleAsync(cmd);

            if (result.HasErrors)
                return BadRequest(result.ValidationResult);

            return Ok(result.Value);
        }

       
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string username, [FromQuery] string password)
        {
            var result = await _deleteHandler.HandleAsync(new DeleteCompanyCommand
            {
                Id = id,
                Username = username,
                Password = password
            });

            if (result.HasErrors)
                return BadRequest(result.ValidationResult);

            return Ok();
        }
    }
}
