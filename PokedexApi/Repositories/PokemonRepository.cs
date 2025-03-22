using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class PokemonRepository : IPokemonRepository {
    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokedexService;

    public PokemonRepository(ILogger<PokemonRepository>logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _pokedexService = new ChannelFactory<IPokemonService>(binding, endpoint).CreateChannel();
    }

    public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            var pokemon = await _pokedexService.GetPokemonById(id, cancellationToken);
            return pokemon.ToModel();
        }
        catch(FaultException ex) when (ex.Message =="Pokemon not found :(")
        {
            _logger.LogWarning(ex, "Failed to get pokemon with id: {id}", id);
            return null;
        }
    }

    public async Task<List<Pokemon>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
    {
        try
        {
            var pokemon = await _pokedexService.GetPokemonByName(name, cancellationToken);
            return pokemon.ToModelList();
        }
        catch(FaultException ex) when (ex.Message == "Pokemon not found :(")
        {
            _logger.LogWarning(ex, "Failed to get pokemon with name: {name}", name);
            return new List<Pokemon>();
        }
    }

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try
        {
            await _pokedexService.DeletePokemon(id, cancellationToken);
            return true;
        }
        catch(FaultException ex) when (ex.Message =="Pokemon not found :(")
        {
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete pokemon with id: {id}", id);
            throw;
        }
    }
}