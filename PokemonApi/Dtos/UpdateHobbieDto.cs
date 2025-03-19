using System.Runtime.Serialization;

namespace HobbieApi.Dtos;
[DataContract(Name ="UpdateHobbieDto", Namespace ="http://hobbie-api/hobbie-service")]
public class UpdateHobbieDto : HobbieCommonDto{
    [DataMember(Name ="Id", Order = 3)]
    public Guid Id {get; set;}
}