using System.Runtime.Serialization;

namespace PokemonApi.Dtos;
[DataContract(Name ="CreatePokemonDto", Namespace ="http://pokemon-api/pokemon-service")]//decorador para que sepa como debe de serializar
public class CreatePokemonDto{
    [DataMember(Name ="Name", Order = 1)] // Esto es un decorador
    public string Name {get; set;}
    [DataMember(Name ="Type", Order = 2)] 
    public string Type {get; set;}
    [DataMember(Name ="Level", Order = 3)] 
    public int Level {get; set;}
    [DataMember(Name ="Stats", Order = 4)] 
    public StatsDto Stats {get; set;}
}