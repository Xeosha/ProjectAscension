﻿using GameService.CORE.Entities;
using GameService.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GameService.Data
{
    public class GameServiceDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserCharacterEntity> UserCharacters { get; set; }
        public DbSet<CharacterEntity> Characters { get; set; }
        public DbSet<ProffesionEntity> CharacterProfessions { get; set; }

        public DbSet<ClothingEntity> Clothings { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }

        public DbSet<TeamEntity> TeamEntities { get; set; }


        public GameServiceDbContext(DbContextOptions<GameServiceDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new ClothingConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
            modelBuilder.ApplyConfiguration(new ProffesionConfiguration());

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
