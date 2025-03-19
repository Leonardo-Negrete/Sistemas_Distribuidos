using System.ServiceModel;
using HobbieApi.Models;


namespace HobbieApi.Validators;

public static class HobbieValidator{
    public static Hobbie ValidateName(this Hobbie hobbie)=>
    string.IsNullOrEmpty(hobbie.Name) ?
    throw new FaultException("Hobbie name is required") : hobbie;

    public static Hobbie ValidateTop(this Hobbie hobbie) =>
    hobbie.Top <= 0 || hobbie.Top > 10 ? throw new FaultException("Hobbie top is required, no more than 10") : hobbie;
}