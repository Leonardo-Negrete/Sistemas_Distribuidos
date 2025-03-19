using HobbyApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using HobbyApi.Mappers;

namespace HobbyApi.Repositories;

public class HobbyRepository : IHobbyRepository{
    private readonly RelationalDbContext _context;
    public HobbyRepository(RelationalDbContext context){
        _context = context;
    }

    public async Task<Hobby> GetByIdAsync(Guid id, CancellationToken cancellationToken){
        var hobby = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return hobby.ToModel();
    }

    public async Task DeleteAsync(Hobby hobby, CancellationToken cancellationToken){
        _context.Hobbies.Remove(hobby.ToEntity()); 
        await _context.SaveChangesAsync(cancellationToken); 
    }

    public async Task<List<Hobby>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        //Buscamos en la base de datos todos los hobbies cuyo nombre contenga la cadena 'name'.
        var hobbyEntities = await _context.Hobbies.AsNoTracking().Where(h => h.Name.Contains(name)) .ToListAsync(cancellationToken);

        //Convertimos cada 'HobbyEntity' a nuestro modelo de dominio 'Hobby'.
        //Si 'hobbyEntities' es null o está vacío, devolvemos una lista vacía.
        return hobbyEntities.ToModelList();
    }

    public async Task AddAsync(Hobby hobby, CancellationToken cancellationToken){
        await _context.Hobbies.AddAsync(hobby.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken){
        _context.Hobbies.Update(hobby.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }
}