using UsersMicroserviceAPI.Repository.IRepository;
using UsersMicroserviceAPI.Models;

namespace UsersMicroserviceAPI.Api;

public static class UsersApiExtensions
{
    public static void AddUsersApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async (IUsersRepository repository) => await GetUsers(repository));
        app.MapGet("/users/{id:int}", async (int id, IUsersRepository repository) => await GetUserById(id, repository));
        app.MapPost("/users", async (UserProfile userProfile, IUsersRepository repository) => await CreateUser(userProfile, repository));
        app.MapPut("/users/{id:int}", async (int id, UserProfile userProfile, IUsersRepository repository) => await UpdateUser(id, userProfile, repository));
        app.MapDelete("/users/{id:int}", async (int id, IUsersRepository repository) => await DeleteUser(id, repository));
    }

    private static async Task<IResult> GetUsers(IUsersRepository repository)
    {
        var users = await repository.GetAllUsersAsync();
        return Results.Ok(users);
    }

    private static async Task<IResult> GetUserById(int id, IUsersRepository repository)
    {
        var user = await repository.GetUserIdAsync(id);
        return user != null ? Results.Ok(user) : Results.NotFound();
    }

    private static async Task<IResult> CreateUser(UserProfile userProfile, IUsersRepository repository)
    {
        var createdUser = await repository.CreateUserAsync(userProfile);
        return Results.Created($"/users/{createdUser.Id}", createdUser);
    }

    private static async Task<IResult> UpdateUser(int id, UserProfile userProfile, IUsersRepository repository)
    {
        var updated = await repository.UpdateUserAsync(id, userProfile);
        return updated ? Results.NoContent() : Results.NotFound();
    }

    private static async Task<IResult> DeleteUser(int id, IUsersRepository repository)
    {
        var deleted = await repository.DeleteUserAsync(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }
}
