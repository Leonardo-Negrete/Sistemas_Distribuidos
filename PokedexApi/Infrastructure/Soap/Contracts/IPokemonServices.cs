//Windows Communication Foundation (WCF) es un framework de Microsoft para construir aplicaciones distribuidas, es decir,
//servicios web que pueden comunicarse entre sí a través de SOAP, HTTP, TCP, entre otros.
using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Dtos; //Esto importa el namespace System.ServiceModel, que contiene atributos y clases para crear servicios WCF en C#.


namespace PokedexApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name = "PokemonService", Namespace ="http://pokemon-api/pokemon-service")]/*Esto es un atributo de WCF que marca la interfaz como un contrato de servicio. Define cómo se expone el servicio a otros clientes.
// Marca la interfaz como un contrato de servicio de WCF.*/
public interface IPokemonService
{
    [OperationContract] /*Marca el método como una operación de servicio en WCF.
Define que este método estará disponible para llamadas remotas.*/
    Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken); // indica que el método es asincrónico (usa async y await en la implementación).
    // es el DTO que representa la respuesta con datos de un Pokémon, como su nombre, tipo, nivel y estadísticas.
    // Esto significa que el método devolverá un objeto de datos de un Pokémon cuando se complete la tarea. 
    // Guid id Es el parámetro de entrada que representa el ID único del Pokémon.
    // CancellationToken cancellationToken: Permite cancelar la operación asincrónica si es necesario, por ejemplo, si el cliente cierra la conexión o el tiempo de espera expira.
    [OperationContract]
    Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemon, CancellationToken cancellationToken);
    [OperationContract]
    Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken);
}
