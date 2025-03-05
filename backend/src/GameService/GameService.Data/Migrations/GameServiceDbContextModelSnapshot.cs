﻿// <auto-generated />
using System;
using GameService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameService.Data.Migrations
{
    [DbContext(typeof(GameServiceDbContext))]
    partial class GameServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameService.CORE.Entities.CharacterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("MaxLevel")
                        .HasColumnType("bigint");

                    b.Property<long>("MinLevel")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rarity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Characters", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.CharacterProffesionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("CharacterProfessions");
                });

            modelBuilder.Entity("GameService.CORE.Entities.ClothingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("BonusDamage")
                        .HasColumnType("bigint");

                    b.Property<long>("BonusDefense")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Clothings", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.InventoryClothingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClothingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserCharacterId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ClothingId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("UserCharacterId");

                    b.ToTable("InventoryClothings", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.InventoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Inventories", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Power")
                        .HasColumnType("bigint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserCharacterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProffesionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeamEntityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ProffesionId");

                    b.HasIndex("TeamEntityId");

                    b.ToTable("UserCharacters");
                });

            modelBuilder.Entity("GameService.CORE.Entities.InventoryClothingEntity", b =>
                {
                    b.HasOne("GameService.CORE.Entities.ClothingEntity", "Clothing")
                        .WithMany("InventoryClothings")
                        .HasForeignKey("ClothingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.CORE.Entities.InventoryEntity", "Inventory")
                        .WithMany("InventoryClothings")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.CORE.Entities.UserCharacterEntity", "UserCharacter")
                        .WithMany("Clothings")
                        .HasForeignKey("UserCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothing");

                    b.Navigation("Inventory");

                    b.Navigation("UserCharacter");
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserCharacterEntity", b =>
                {
                    b.HasOne("GameService.CORE.Entities.CharacterEntity", "Character")
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.CORE.Entities.CharacterProffesionEntity", "Proffesion")
                        .WithMany()
                        .HasForeignKey("ProffesionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.CORE.Entities.TeamEntity", null)
                        .WithMany("Characters")
                        .HasForeignKey("TeamEntityId");

                    b.Navigation("Character");

                    b.Navigation("Proffesion");
                });

            modelBuilder.Entity("GameService.CORE.Entities.ClothingEntity", b =>
                {
                    b.Navigation("InventoryClothings");
                });

            modelBuilder.Entity("GameService.CORE.Entities.InventoryEntity", b =>
                {
                    b.Navigation("InventoryClothings");
                });

            modelBuilder.Entity("GameService.CORE.Entities.TeamEntity", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserCharacterEntity", b =>
                {
                    b.Navigation("Clothings");
                });
#pragma warning restore 612, 618
        }
    }
}
