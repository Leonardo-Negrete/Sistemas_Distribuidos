using System.ServiceModel;
using HobbyApi.Models;


namespace HobbyApi.Validators;

public static class HobbyValidator{
    public static Hobby ValidateName(this Hobby hobby)=>
    string.IsNullOrEmpty(hobby.Name) ?
    throw new FaultException("Hobby name is required") : hobby;

    public static Hobby ValidateTop(this Hobby hobby) =>
    hobby.Top <= 0 || hobby.Top > 10 ? throw new FaultException("Hobby top is required, no more than 10") : hobby;
}