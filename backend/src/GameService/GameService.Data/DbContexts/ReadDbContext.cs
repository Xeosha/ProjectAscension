using GameService.CORE.Entities;
using GameService.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data.DbContexts
{   
    public class ReadDbContext : DbContext, IReadDbContext
    {

        public IQueryable<CharacterEntity> Characters => Set<CharacterEntity>();

        public IQueryable<TeamEntity> Teams => Set<TeamEntity>();

        public IQueryable<UserEntity> Users => Set<UserEntity>();

        public IQueryable<UserCharacterEntity> UserCharacters => Set<UserCharacterEntity>();

        public IQueryable<ProffesionEntity> Proffesions => Set<ProffesionEntity>();

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(WriteDbContext).Assembly,
                type => type.FullName?.Contains("Configurations.Write") ?? false);

            modelBuilder
                .Entity<InventoryEntity>()
                .HasMany(c => c.Clothings)
                .WithMany(s => s.Inventories)
                .UsingEntity<InventoryClothingEntity>(
                   j => j
                    .HasOne(pt => pt.Clothing)
                    .WithMany(t => t.InventoryClothings)
                    .HasForeignKey(pt => pt.ClothingId),
                    j => j
                        .HasOne(pt => pt.Inventory)
                        .WithMany(p => p.InventoryClothings)
                        .HasForeignKey(pt => pt.InventoryId),
                    j =>
                    {
                        j.ToTable("InventoryClothings");
                    });

            modelBuilder
                .Entity<UserEntity>()
                .HasMany(c => c.Characters)
                .WithMany(s => s.Users)
                .UsingEntity<UserCharacterEntity>(
                   j => j
                    .HasOne(pt => pt.Character)
                    .WithMany(t => t.UserCharacters)
                    .HasForeignKey(pt => pt.CharacterId),
                   j => j
                    .HasOne(pt => pt.User)
                    .WithMany(p => p.UserCharacters)
                    .HasForeignKey(pt => pt.UserId),
                   j =>
                   {
                       j.Property(pt => pt.Health);
                       j.Property(pt => pt.Defense);
                       j.Property(pt => pt.Attack);
                       j.Property(pt => pt.Exp);
                       j.Property(pt => pt.Level);

                       j.ToTable("UserCharacters");
                   }
                );

            modelBuilder.Entity<UserCharacterEntity>()
                .HasOne(uc => uc.Proffesion)          // UserCharacter имеет одну Profession
                .WithMany(p => p.UserCharacters)      // Profession имеет много UserCharacters
                .HasForeignKey(uc => uc.ProffesionId) // Внешний ключ
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
