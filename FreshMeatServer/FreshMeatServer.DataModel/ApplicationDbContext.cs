using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FreshMeatServer.DataModel
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<ChildAttribute> ChildAttributes { get; set; }
        public DbSet<ChildAttributeSelection> ChildAttributeSelections { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Matcher> Matchers { get; set; }
        public DbSet<ParentAttribute> ParentAttributes { get; set; }
        public DbSet<ParentAttributeSelection> ParentAttributeSelections { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //Auto Guid
            builder.Entity<Character>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ChildAttribute>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ChildAttributeSelection>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Inventory>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Master>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Match>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Matcher>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ParentAttribute>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ParentAttributeSelection>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Player>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Status>().Property(prop => prop.Id)
                .ValueGeneratedOnAdd();

            //unique user
            builder.Entity<Master>().HasIndex(prop => prop.UserId).IsUnique();
            builder.Entity<Player>().HasIndex(prop => prop.UserId).IsUnique();

            //required
            builder.Entity<Character>().Property(prop => prop.CharName)
                .IsRequired();
            builder.Entity<Character>().Property(prop => prop.PlayerId)
                .IsRequired();

            builder.Entity<ChildAttribute>().Property(prop => prop.AttributeName)
                .IsRequired();
            builder.Entity<ChildAttribute>().Property(prop => prop.ParentAttributeId)
                .IsRequired();

            builder.Entity<ChildAttributeSelection>().Property(prop => prop.Level)
                .IsRequired();
            builder.Entity<ChildAttributeSelection>().Property(prop => prop.ChildAttributeId)
                .IsRequired();
            builder.Entity<ChildAttributeSelection>().Property(prop => prop.ParentAttributeSelectionId)
                .IsRequired();

            builder.Entity<Inventory>().Property(prop => prop.ItemQuantity)
                .IsRequired();
            builder.Entity<Inventory>().Property(prop => prop.ItemId)
                .IsRequired();
            
            builder.Entity<Item>().Property(prop => prop.ItemName)
                .IsRequired();
            
            builder.Entity<Master>().Property(prop => prop.UserId)
                .IsRequired();

            builder.Entity<Match>().Property(prop => prop.MasterId)
                .IsRequired();

            builder.Entity<Matcher>().Property(prop => prop.CharacterId)
                .IsRequired();
            builder.Entity<Matcher>().Property(prop => prop.MatchId)
                .IsRequired();

            builder.Entity<ParentAttribute>().Property(prop => prop.AttributeName)
                .IsRequired();
            builder.Entity<ParentAttribute>().Property(prop => prop.MaxValue)
                .IsRequired();
            builder.Entity<ParentAttribute>().Property(prop => prop.MinValue)
                .IsRequired();

            builder.Entity<ParentAttributeSelection>().Property(prop => prop.Level)
                .IsRequired();
            builder.Entity<ParentAttributeSelection>().Property(prop => prop.ParentAttributeId)
                .IsRequired();

            builder.Entity<Player>().Property(prop => prop.UserId)
                .IsRequired();

            builder.Entity<Status>().Property(prop => prop.StatusName)
                .IsRequired();
            builder.Entity<Status>().Property(prop => prop.IconType)
                .IsRequired();

            //rels
            builder.Entity<Match>()
                .HasMany(prop=>prop.Matchers)
                .WithOne(prop=>prop.Match).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Character>()
                .HasMany(prop => prop.Matchers)
                .WithOne(prop => prop.Character).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Character>()
                .HasMany(prop => prop.ParentAttributeSelections)
                .WithOne(prop => prop.Character).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ParentAttributeSelection>()
                .HasMany(prop => prop.ChildAttributeSelections)
                .WithOne(prop => prop.ParentAttributeSelection).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ParentAttribute>()
                .HasMany(prop => prop.ChildAttributes)
                .WithOne(prop => prop.ParentAttribute).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Player>()
                .HasMany(prop => prop.Characters)
                .WithOne(prop => prop.Player).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
