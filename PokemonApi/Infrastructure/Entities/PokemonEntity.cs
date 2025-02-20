namespace PokemonApi.Infrastructure.Entities;

public class PokemonEntity //Todo lo que tiene que ver con la base de datos
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Type {get; set;}
    public int Level {get; set;}
    public int Attack {get; set;}
    public int Defense {get; set;}
    public int Speed {get; set;}
    public int Weight {get; set;}
}