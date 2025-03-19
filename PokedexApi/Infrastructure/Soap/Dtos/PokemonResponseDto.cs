using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos; //El punto Dtos se refiere a la carpeta donde esta

[DataContract(Name = "PokemonResponseDto", Namespace = "http://Pokemon-api/pokemon-service")]
public class PokemonResponseDto // Todo lo que ver y pedimos al usuario
{
    [DataMember(Name = "Id", Order = 1)]
    public Guid Id {get; set;} //Guid (Global Unique Identifier) se utiliza para crear identificadores únicos que no se repiten, ideal para IDs en bases de datos o APIs.
    [DataMember(Name = "Name", Order = 2)]
    public string Name {get; set;} //{ get; set; }: Define una propiedad auto-implementada que permite obtener (get) y asignar (set) el valor
    [DataMember(Name = "Type", Order = 3)]
    public string Type {get; set;}
   [DataMember(Name = "Level", Order = 4)]
    public int Level {get; set;}
    [DataMember(Name = "Stats", Order = 5)]
    public StatsDto Stats {get; set;}
}