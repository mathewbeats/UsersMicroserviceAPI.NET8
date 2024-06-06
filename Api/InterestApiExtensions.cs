using UsersMicroserviceAPI.Repository.IRepository;

namespace UsersMicroserviceAPI.Api;

public static class InterestApiExtensions
{


    public static void MapInterest(IEndpointRouteBuilder map)
    {
        map.MapGet("/interest", async (IInterestRepository repository) => await GetInterestAsync(repository));
    }


    private static async  Task<IResult> GetInterestAsync(IInterestRepository repository)
    {
        var Interest = await repository.GetAllInterestAsync();

        return Results.Ok(Interest);

    }
    
}