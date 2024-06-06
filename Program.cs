using Microsoft.EntityFrameworkCore;
using UsersMicroserviceAPI.Data;
using UsersMicroserviceAPI.Repository;
using UsersMicroserviceAPI.Repository.IRepository;
using UsersMicroserviceAPI.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<IInterestRepository, InterestRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

UsersApiExtensions.AddUsersApiEndpoints(app);

app.Run();