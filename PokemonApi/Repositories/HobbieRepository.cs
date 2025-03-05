using HobbieApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using HobbieApi.Mappers;

namespace HobbieApi.Repositories;

public class HobbieRepository : IHobbieRepository{
    private readonly RelationalDbContext _context;
    public HobbieRepository(RelationalDbContext context){
        _context = context;
    }

    public async Task<Hobbie> GetByIdAsync(Guid id, CancellationToken cancellationToken){
        var hobbie = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        return hobbie.ToModel();
    }

    public async Task DeleteAsync(Hobbie hobbie, CancellationToken cancellationToken){
        _context.Hobbies.Remove(hobbie.ToEntity()); 
        await _context.SaveChangesAsync(cancellationToken); 
    }

    public async Task<List<Hobbie>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        //Buscamos en la base de datos todos los hobbies cuyo nombre contenga la cadena 'name'.
        var hobbyEntities = await _context.Hobbies.AsNoTracking().Where(h => h.Name.Contains(name)) .ToListAsync(cancellationToken);

        //Convertimos cada 'HobbieEntity' a nuestro modelo de dominio 'Hobbie'.
        //Si 'hobbyEntities' es null o está vacío, devolvemos una lista vacía.
        return hobbyEntities?.Select(hobbyEntity => hobbyEntity.ToModel()).ToList() ?? new List<Hobbie>();
    }

    public async Task AddAsync(Hobbie hobbie, CancellationToken cancellationToken){
        await _context.Hobbies.AddAsync(hobbie.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Hobbie hobbie, CancellationToken cancellationToken){
        _context.Hobbies.Update(hobbie.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }
}