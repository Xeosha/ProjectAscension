﻿// <auto-generated />
using System;
using GameService.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameService.Data.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
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

            modelBuilder.Entity("GameService.CORE.Entities.ProffesionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Proffesions", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserCharacterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Attack")
                        .HasColumnType("bigint");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<long>("Defense")
                        .HasColumnType("bigint");

                    b.Property<long>("Exp")
                        .HasColumnType("bigint");

                    b.Property<long>("Health")
                        .HasColumnType("bigint");

                    b.Property<long>("Level")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("ProffesionId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ProffesionId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCharacters", (string)null);
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
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
                        .WithMany()
                        .HasForeignKey("UserCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clothing");

                    b.Navigation("Inventory");

                    b.Navigation("UserCharacter");
                });

            modelBuilder.Entity("GameService.CORE.Entities.TeamEntity", b =>
                {
                    b.HasOne("GameService.CORE.Entities.UserEntity", "User")
                        .WithMany("Teams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserCharacterEntity", b =>
                {
                    b.HasOne("GameService.CORE.Entities.CharacterEntity", "Character")
                        .WithMany("UserCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameService.CORE.Entities.ProffesionEntity", "Proffesion")
                        .WithMany("UserCharacters")
                        .HasForeignKey("ProffesionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameService.CORE.Entities.TeamEntity", "Team")
                        .WithMany("Characters")
                        .HasForeignKey("TeamId");

                    b.HasOne("GameService.CORE.Entities.UserEntity", "User")
                        .WithMany("UserCharacters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Proffesion");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameService.CORE.Entities.CharacterEntity", b =>
                {
                    b.Navigation("UserCharacters");
                });

            modelBuilder.Entity("GameService.CORE.Entities.ClothingEntity", b =>
                {
                    b.Navigation("InventoryClothings");
                });

            modelBuilder.Entity("GameService.CORE.Entities.InventoryEntity", b =>
                {
                    b.Navigation("InventoryClothings");
                });

            modelBuilder.Entity("GameService.CORE.Entities.ProffesionEntity", b =>
                {
                    b.Navigation("UserCharacters");
                });

            modelBuilder.Entity("GameService.CORE.Entities.TeamEntity", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("GameService.CORE.Entities.UserEntity", b =>
                {
                    b.Navigation("Teams");

                    b.Navigation("UserCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}
