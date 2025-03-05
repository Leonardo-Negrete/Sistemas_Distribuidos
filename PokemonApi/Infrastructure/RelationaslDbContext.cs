using BookApi.Infrastructure.Entities;
using HobbieApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Entities;


namespace PokemonApi.Infrastructure;

public class RelationalDbContext : DbContext
{
    public DbSet<PokemonEntity> Pokemons {get; set;}
    public DbSet<HobbieEntity> Hobbies {get; set;}
    public DbSet<BookEntity> Books {get; set;}
    public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options){
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PokemonEntity>(entity =>{
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.Type).IsRequired().HasMaxLength(50);
            entity.Property(s => s.Level).IsRequired();
            entity.Property(s => s.Attack).IsRequired();
            entity.Property(s => s.Defense).IsRequired();
            entity.Property(s => s.Speed).IsRequired();
            entity.Property(s => s.Weight).IsRequired();
        });

        modelBuilder.Entity<HobbieEntity>(entity => {
           entity.HasKey(s => s.Id);
           entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
           entity.Property(s => s.Top).IsRequired();
        });

        modelBuilder.Entity<BookEntity>(entity => {
           entity.HasKey(s => s.Id);
           entity.Property(s => s.Title).IsRequired().HasMaxLength(100);
           entity.Property(s => s.Author).IsRequired().HasMaxLength(100);
           entity.Property(s => s.PublishedDate).IsRequired().HasColumnType("datetime");
        });
    }
}