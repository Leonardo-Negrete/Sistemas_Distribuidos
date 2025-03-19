using System.ServiceModel;
using HobbyApi.Dtos;
using HobbyApi.Repositories;
using HobbyApi.Mappers;
using HobbyApi.Validators;

namespace HobbyApi.Services;

public class HobbyService : IHobbyService
{
    private readonly IHobbyRepository _hobbyRepository;

    public HobbyService(IHobbyRepository hobbyRepository){
        _hobbyRepository = hobbyRepository;
    }

    public async Task<HobbyResponseDto> GetHobbyById(Guid id, CancellationToken cancellationToken){
        var hobby = await _hobbyRepository.GetByIdAsync(id, cancellationToken);
        if(hobby is null){
            throw new FaultException("Hobby not found :(");
        }
        return hobby.ToDto();
    }

    public async Task<bool> DeleteHobby(Guid id, CancellationToken cancellationToken){
        var hobby = await _hobbyRepository.GetByIdAsync(id, cancellationToken);
        if(hobby is null){
            throw new FaultException("Hobby not found :(");
        }
        await _hobbyRepository.DeleteAsync(hobby, cancellationToken);
        return true;
    }
    public async Task<List<HobbyResponseDto>> GetHobbyByName(string name, CancellationToken cancellationToken)
    {
        var hobbies = await _hobbyRepository.GetByNameAsync(name, cancellationToken);
        return hobbies.ToDtoList();
    }
    public async Task<HobbyResponseDto> CreateHobby(CreateHobbyDto createHobbyDto, CancellationToken cancellationToken){
        var hobbyToCreate = createHobbyDto.ToModel();

        hobbyToCreate.ValidateName().ValidateTop();

        await _hobbyRepository.AddAsync(hobbyToCreate, cancellationToken);
        return hobbyToCreate.ToDto();
    }

    public async Task<HobbyResponseDto> UpdateHobby(UpdateHobbyDto hobby, CancellationToken cancellationToken){
        var hobbyToUpdate = await _hobbyRepository.GetByIdAsync(hobby.Id, cancellationToken);
        if(hobbyToUpdate is null){
            throw new FaultException("Hobby not found :(");
        }
        hobbyToUpdate.Name = hobby.Name;
        hobbyToUpdate.Top = hobby.Top;

        await _hobbyRepository.UpdateAsync(hobbyToUpdate, cancellationToken);
        return hobbyToUpdate.ToDto();
    }
}