﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineMovieStore.Web.Data;

namespace OnlineMovieStore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime?>("ModifiedOn");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<double>("Balance");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.GenreMovie", b =>
                {
                    b.Property<int>("MovieId");

                    b.Property<int>("GenreId");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreMovies");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<double>("Price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<short>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Order", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("MovieId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.WatchedMovies", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("MovieId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("WatchedMovies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.GenreMovie", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.Genre", "Genre")
                        .WithMany("Genres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMovieStore.Models.Models.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Movie", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.Actor", "Actor")
                        .WithMany("Movie")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.Order", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.Movie", "Movie")
                        .WithMany("Orders")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineMovieStore.Models.Models.WatchedMovies", b =>
                {
                    b.HasOne("OnlineMovieStore.Models.Models.Movie", "Movie")
                        .WithMany("Movies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineMovieStore.Models.Models.ApplicationUser", "User")
                        .WithMany("WatchedMovies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
