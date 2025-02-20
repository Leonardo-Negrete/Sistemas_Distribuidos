using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Models;
using PokemonApi.Repositories;
//Libros clean Code (principalmente), Clean architecture, clean coder

namespace PokemonApi.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;

    //TDD (Test driven developed) y unit test investigar
    public PokemonService(IPokemonRepository pokemonRepository){
        _pokemonRepository = pokemonRepository;
    }

    public async Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetByIdAsync(id, cancellationToken);
        if(pokemon is null){
            throw new FaultException("Pokemon not found :(");
        }
        return pokemon.ToDto();
    }

    public async Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetByIdAsync(id, cancellationToken);
        if(pokemon is null){
            throw new FaultException("Pokemon not found :(");
        }
        await _pokemonRepository.DeleteAsync(pokemon, cancellationToken);
        return true;
    }
    public async Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken){
        return null;
    }
}