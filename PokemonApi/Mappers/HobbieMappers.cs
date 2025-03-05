using HobbieApi.Dtos;
using HobbieApi.Infrastructure.Entities;
using HobbieApi.Models;

namespace HobbieApi.Mappers;

public static class HobbieMapper {
    public static HobbieEntity ToEntity(this Hobbie hobbie){
        return new HobbieEntity{
            Id = hobbie.Id,
            Name = hobbie.Name,
            Top = hobbie.Top
        };
    }

    public static Hobbie ToModel(this HobbieEntity hobbieEntity){
        if(hobbieEntity is null){
            return null;
        }
        return new Hobbie{
            Id = hobbieEntity.Id,
            Name = hobbieEntity.Name,
            Top = hobbieEntity.Top
        };
    }

    public static HobbieResponseDto ToDto(this Hobbie hobbie){
        return new HobbieResponseDto{
            Id = hobbie.Id,
            Name = hobbie.Name,
            Top = hobbie.Top
        };
    }

    public static Hobbie ToModel(this CreateHobbieDto hobbie)
    {
        return new Hobbie{
            Id=Guid.NewGuid(),
            Name = hobbie.Name,
            Top = hobbie.Top
        };
    }
}
