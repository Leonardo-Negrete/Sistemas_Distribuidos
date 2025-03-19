using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos;
[DataContract(Name ="CreatePokemonDto", Namespace ="http://pokemon-api/pokemon-service")]//decorador para que sepa como debe de serializar
public class CreatePokemonDto : PokemonCommonDto{
    
}