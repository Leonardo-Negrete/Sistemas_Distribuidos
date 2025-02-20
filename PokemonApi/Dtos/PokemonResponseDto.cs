namespace PokemonApi.Dtos; //El punto Dtos se refiere a la carpeta donde esta

public class PokemonResponseDto // Todo lo que ver y pedimos al usuario
{
    public Guid Id {get; set;} //Guid (Global Unique Identifier) se utiliza para crear identificadores únicos que no se repiten, ideal para IDs en bases de datos o APIs.
    public string Name {get; set;} //{ get; set; }: Define una propiedad auto-implementada que permite obtener (get) y asignar (set) el valor
    public string Type {get; set;}
    public int Level {get; set;}
    public StatsDto Stats {get; set;}
}