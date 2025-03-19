using HobbyApi.Dtos;
using HobbyApi.Infrastructure.Entities;
using HobbyApi.Models;

namespace HobbyApi.Mappers;

public static class HobbyMapper {
    public static HobbyEntity ToEntity(this Hobby hobby){
        return new HobbyEntity{
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
        };
    }

    public static Hobby ToModel(this HobbyEntity hobbyEntity){
        if(hobbyEntity is null){
            return null;
        }
        return new Hobby{
            Id = hobbyEntity.Id,
            Name = hobbyEntity.Name,
            Top = hobbyEntity.Top
        };
    }

    public static HobbyResponseDto ToDto(this Hobby hobby){
        return new HobbyResponseDto{
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
        };
    }

    public static Hobby ToModel(this CreateHobbyDto hobby)
    {
        return new Hobby{
            Id=Guid.NewGuid(),
            Name = hobby.Name,
            Top = hobby.Top
        };
    }

    public static List<Hobby> ToModelList(this List<HobbyEntity> entities)
    {
        return entities?.Select(e => e.ToModel()).ToList() ?? new List<Hobby>();
    }
    public static List<HobbyResponseDto> ToDtoList(this List<Hobby> hobby)
    {
        return hobby?.Select(b => b.ToDto()).ToList() ?? new List<HobbyResponseDto>();
    }
}
