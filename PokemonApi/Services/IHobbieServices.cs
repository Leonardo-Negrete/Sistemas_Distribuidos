using System.ServiceModel;
using HobbieApi.Dtos;

namespace HobbieApi.Services;

[ServiceContract(Name = "HobbieService", Namespace ="http://hobbie-api/hobbie-service")]

public interface IHobbieService{
    [OperationContract] 
    Task<HobbieResponseDto> GetHobbieById(Guid id, CancellationToken cancellationToken); 
    [OperationContract]
    Task<bool> DeleteHobbie(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<List<HobbieResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken);
}