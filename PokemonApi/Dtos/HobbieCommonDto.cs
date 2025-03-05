using System.Runtime.Serialization;

namespace HobbieApi.Dtos;

[DataContract(Name ="HobbieCommonDto", Namespace ="http://hobbie-api/hobbie-service")]
[KnownType(typeof(CreateHobbieDto))]
[KnownType(typeof(UpdateHobbieDto))]
public class HobbieCommonDto{
    [DataMember(Name ="Name", Order = 1)] 
    public string Name {get; set;}
    [DataMember(Name ="Top", Order = 2)] 
    public int Top {get; set;}
}