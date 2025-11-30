using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using UserApp.Application.Companies.Commands.CreateCompany;
using UserApp.Application.Companies.Commands.DeleteCompany;
using UserApp.Application.Companies.Commands.UpdateCompany;
using UserApp.Application.Companies.Queries.GetCompanyById;
using UserApp.Application.Users.Commands.CreateUser;
using UserApp.Application.Users.Commands.ImportExternalUser;
using UserApp.Application.Users.Commands.UpdateUser;
using UserApp.Application.Users.Models;
using UserApp.Application.Users.Queries;
using UserApp.Domain.Persistance.Users;
using UserApp.Infrastructure.Persistance;
using UserApp.Infrastructure.Persistance.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<UsersContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDb")));

builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CompanyDb")));


builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("UsersDb")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddHttpClient<IExternalUserService, ExternalUserService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});


builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<GetUserByIdHandler>();
builder.Services.AddScoped<GetAllUsersHandler>();
builder.Services.AddScoped<ChangePasswordHandler>();
builder.Services.AddScoped<DeactivateUserHandler>();
builder.Services.AddScoped<ImportExternalUserHandler>();

builder.Services.AddScoped<CreateCompanyHandler>();
builder.Services.AddScoped<UpdateCompanyHandler>();
builder.Services.AddScoped<DeleteCompanyHandler>();
builder.Services.AddScoped<GetAllCompaniesHandler>();
builder.Services.AddScoped<GetCompanyByIdHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", p =>
        p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();
Console.WriteLine("USERS DB = " + builder.Configuration.GetConnectionString("UsersDb"));
Console.WriteLine("COMPANY DB = " + builder.Configuration.GetConnectionString("CompanyDb"));


if (app.Environment.IsDevelopment())
{
    app.UseCors("default");

    app.UseSwagger();
    app.UseSwaggerUI(/*c => c.RoutePrefix = "swagger"*/);
}

//app.UseHttpsRedirection();
app.MapControllers();

app.Run();
