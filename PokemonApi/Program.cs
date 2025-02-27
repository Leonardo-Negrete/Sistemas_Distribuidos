using BookApi.Repositories;
using BookApi.Services;
using HobbieApi.Repositories;
using HobbieApi.Services;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Repositories;
using PokemonApi.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();

builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

//Hobbie
builder.Services.AddSingleton<IHobbieService, HobbieService>();
builder.Services.AddScoped<IHobbieRepository, HobbieRepository>();

//Book
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbieService>("/LeonardoNegreteHobbiesService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IBookService>("/BookService.svc", new SoapEncoderOptions());

app.Run();