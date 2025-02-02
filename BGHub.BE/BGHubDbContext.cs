using BGHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BGHub.BE
{
    public class BGHubDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<EventGame> EventGames { get; set; }
        public BGHubDbContext(DbContextOptions<BGHubDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User() 
                {
                    Id = 1,
                    Name = "Rich",
                    BGGUsername = "Gandolfini"
                },
                new User()
                {
                    Id = 2,
                    Name = "Haz",
                    BGGUsername = "Mallionaire"
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 3, Name = "February 2025", StartDate = new DateTime(2025, 2, 6), EndDate = new DateTime(2025, 2, 10), LocationLink = "https://www.airbnb.co.uk/rooms/603983959452545227?source_impression_id=p3_1738253168_P3ZOU_a5XDDs_UeN" },
                new Event { Id = 2, Name = "October 2024", StartDate = new DateTime(2024, 10, 27), EndDate = new DateTime(2024, 10, 31), LocationLink = "The Manor" },
                new Event { Id = 1, Name = "February 2024", StartDate = new DateTime(2024, 2, 6), EndDate = new DateTime(2024, 2, 10), LocationLink = "The Manor" }
            );

            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 5, Name = "Blood on the Clocktower", OwnerId = 1, BGGId = 240980, ImageUrl = "https://cf.geekdo-images.com/HINb2nkFn5IiZxAlzQIs4g__original/img/e7izEwSmnBPiErsIF6hlWbgybBE=/0x0/filters:format(jpeg)/pic7009391.jpg" },
                new Game { Id = 4, Name = "Legendary Encounters: An Alien Deck Building Game", OwnerId = 1, BGGId = 146652, ImageUrl = "https://cf.geekdo-images.com/jSz_KRUxsjGYitoqx9YH1Q__original/img/nrvJtT-4tYTD0fp3Cr57SKpfMfw=/0x0/filters:format(jpeg)/pic2225180.jpg" },
                new Game { Id = 3, Name = "Nova Luna", OwnerId = 2, BGGId = 284435, ImageUrl = "https://cf.geekdo-images.com/k8OZeKYMN2vVSVCl5FD-UA__original/img/XiytG0d5nHtdoN4Kq3pCM6VcSac=/0x0/filters:format(jpeg)/pic5382418.jpg" },
                new Game { Id = 2, Name = "Slay the Spire", OwnerId = 1, BGGId = 338960, ImageUrl = "https://cf.geekdo-images.com/PQzVclEoOQ_wr4e1V86kxA__original/img/KXOf1hP1cIJQLabKhZulWP-e9wI=/0x0/filters:format(png)/pic8157856.png" },
                new Game { Id = 1, Name = "Terraforming Mars", OwnerId = 1, BGGId = 167791, ImageUrl = "https://cf.geekdo-images.com/wg9oOLcsKvDesSUdZQ4rxw__original/img/thIqWDnH9utKuoKVEUqveDixprI=/0x0/filters:format(jpeg)/pic3536616.jpg" }
            );

            modelBuilder.Entity<EventGame>().HasData(
                new EventGame { Id = 1, EventId = 1, GameId = 1 },
                new EventGame { Id = 2, EventId = 2, GameId = 2 },
                new EventGame { Id = 3, EventId = 3, GameId = 1 },
                new EventGame { Id = 4, EventId = 3, GameId = 2 },
                new EventGame { Id = 5, EventId = 3, GameId = 3 }
            );
        }
    }

}
