using System.ServiceModel;
using HobbieApi.Dtos;
using HobbieApi.Repositories;
using HobbieApi.Mappers;

namespace HobbieApi.Services;

public class HobbieService : IHobbieService
{
    private readonly IHobbieRepository _hobbieRepository;

    public HobbieService(IHobbieRepository hobbieRepository){
        _hobbieRepository = hobbieRepository;
    }

    public async Task<HobbieResponseDto> GetHobbieById(Guid id, CancellationToken cancellationToken){
        var hobbie = await _hobbieRepository.GetByIdAsync(id, cancellationToken);
        if(hobbie is null){
            throw new FaultException("hobbie not found :(");
        }
        return hobbie.ToDto();
    }

    public async Task<bool> DeleteHobbie(Guid id, CancellationToken cancellationToken){
        var hobbie = await _hobbieRepository.GetByIdAsync(id, cancellationToken);
        if(hobbie is null){
            throw new FaultException("hobbie not found :(");
        }
        await _hobbieRepository.DeleteAsync(hobbie, cancellationToken);
        return true;
    }
    public async Task<List<HobbieResponseDto>> GetHobbieByName(string name, CancellationToken cancellationToken)
    {
        var hobbies = await _hobbieRepository.GetByNameAsync(name, cancellationToken);
        return hobbies.Select(h => h.ToDto()).ToList();
    }
}