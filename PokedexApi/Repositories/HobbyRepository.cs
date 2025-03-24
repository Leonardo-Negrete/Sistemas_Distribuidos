using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class HobbyRepository : IHobbyRepository
{
    private readonly ILogger<HobbyRepository> _logger;
    private readonly IHobbyService _hobbyService;

    public HobbyRepository(ILogger<HobbyRepository>logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbyServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbyService = new ChannelFactory<IHobbyService>(binding, endpoint).CreateChannel();
    }

    public async Task<Hobby?> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            var hobby = await _hobbyService.GetHobbyById(id, cancellationToken);
            return hobby.ToModel();
        }
        catch(FaultException ex) when (ex.Message =="Hobby not found :(")
        {
            _logger.LogWarning(ex, "Failed to get hobby with id: {id}", id);
            return null;
        }
    }

    public async Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var hobby = await _hobbyService.GetHobbyByName(name, cancellationToken);
            return hobby.ToModelList();
        }
        catch(FaultException ex) when (ex.Message == "Hobby not found :(")
        {
            _logger.LogWarning(ex, "Failed to get hobby with name: {name}", name);
            return new List<Hobby>();
        }
    }

    public async Task<bool> DeleteHobbyByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            await _hobbyService.DeleteHobby(id, cancellationToken);
            return true;
        }
        catch(FaultException ex) when (ex.Message =="Hobby not found :(")
        {
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete hobby with id: {id}", id);
            throw;
        }
    }
}