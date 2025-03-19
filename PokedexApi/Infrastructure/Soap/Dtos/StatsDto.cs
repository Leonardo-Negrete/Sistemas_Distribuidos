using System.Runtime.Serialization; //Esta línea importa el namespace System.Runtime.Serialization, el cual proporciona atributos y utilidades para la serialización y deserialización de objetos en C#

namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name = "StatsDto", Namespace = "http://pokemon-api/pokemon-service")] //esto es lo que le dara un orden (serializara) al documento xml
public class StatsDto{
    [DataMember(Name = "Attack", Order = 1)] //Hara que en el xml aparezca asi: "Attack": 55 y el order=1 Especifica el orden en que aparecerá en la salida serializada.
    public int Attack {get; set;}
    [DataMember(Name = "Defense", Order = 2)]
    public int Defense {get; set;}
    [DataMember(Name = "Speed", Order = 3)]
    public int Speed {get; set;}
    [DataMember(Name = "Weight", Order = 4)]
    public int Weight {get; set;}
}