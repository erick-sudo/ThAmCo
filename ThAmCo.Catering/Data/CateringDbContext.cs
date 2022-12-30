using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        //Database Sets
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }

        private readonly IHostEnvironment _hostEnv;
        private readonly string DbPath;

        public CateringDbContext(DbContextOptions options, IHostEnvironment env) : base(options)
        {
            _hostEnv = env;

            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ThAmCo.Catering.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .HasKey(k => k.MenuId);

            modelBuilder.Entity<FoodBooking>()
                .HasKey(k => k.FoodBookingId);

            modelBuilder.Entity<MenuFoodItem>()
                .HasKey(k => k.MenuFoodItemId);
                

            modelBuilder.Entity<FoodItem>()
                .HasKey(k => k.FoodItemId);

            //Load some data
            modelBuilder.Entity<FoodBooking>()
                .HasData(
                    new FoodBooking { FoodBookingId = 1, ClientReferenceId = 780, NumberOfGuests = 76, MenuId = 848384 },
                    new FoodBooking { FoodBookingId = 2, ClientReferenceId = 466, NumberOfGuests = 89, MenuId = 455455 },
                    new FoodBooking { FoodBookingId = 3, ClientReferenceId = 533, NumberOfGuests = 46, MenuId = 455455 },
                    new FoodBooking { FoodBookingId = 4, ClientReferenceId = 987, NumberOfGuests = 97, MenuId = 536345 },
                    new FoodBooking { FoodBookingId = 5, ClientReferenceId = 476, NumberOfGuests = 53, MenuId = 848384 },
                    new FoodBooking { FoodBookingId = 6, ClientReferenceId = 734, NumberOfGuests = 45, MenuId = 455455 },
                    new FoodBooking { FoodBookingId = 7, ClientReferenceId = 874, NumberOfGuests = 97, MenuId = 455455 },
                    new FoodBooking { FoodBookingId = 8, ClientReferenceId = 775, NumberOfGuests = 37, MenuId = 864666 }
                );
            modelBuilder.Entity<Menu>()
                .HasData(
                    new Menu
                    {
                        MenuId = 848384,
                        MenuName = "Ramen Rater"
                    },
                    new Menu
                    {
                        MenuId = 455455,
                        MenuName = "Wincer"
                    },
                    new Menu
                    {
                        MenuId = 536345,
                        MenuName = "Marine"
                    },
                    new Menu
                    {
                        MenuId = 864666,
                        MenuName = "Rose Mont"
                    }
                );

            modelBuilder.Entity<MenuFoodItem>()
                .HasData(
                    new MenuFoodItem { MenuFoodItemId = 1, FoodItemId = 107, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 2, FoodItemId = 101, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 3, FoodItemId = 100, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 4, FoodItemId = 109, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 5, FoodItemId = 100, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 6, FoodItemId = 104, MenuId = 848384 },
                    new MenuFoodItem { MenuFoodItemId = 7, FoodItemId = 102, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 8, FoodItemId = 101, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 9, FoodItemId = 103, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 10, FoodItemId = 104, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 11, FoodItemId = 100, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 12, FoodItemId = 105, MenuId = 455455 },
                    new MenuFoodItem { MenuFoodItemId = 13, FoodItemId = 102, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 14, FoodItemId = 106, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 15, FoodItemId = 107, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 16, FoodItemId = 108, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 17, FoodItemId = 100, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 18, FoodItemId = 103, MenuId = 536345 },
                    new MenuFoodItem { MenuFoodItemId = 19, FoodItemId = 104, MenuId = 864666 },
                    new MenuFoodItem { MenuFoodItemId = 20, FoodItemId = 105, MenuId = 864666 },
                    new MenuFoodItem { MenuFoodItemId = 21, FoodItemId = 107, MenuId = 864666 },
                    new MenuFoodItem { MenuFoodItemId = 22, FoodItemId = 102, MenuId = 864666 },
                    new MenuFoodItem { MenuFoodItemId = 23, FoodItemId = 108, MenuId = 864666 },
                    new MenuFoodItem { MenuFoodItemId = 24, FoodItemId = 106, MenuId = 864666 }
                );

            modelBuilder.Entity<FoodItem>()
                .HasData(
                    new FoodItem { FoodItemId = 101, FoodItemName = "Dark Green Vegetables", Description = "Eat dark green vegetables at least three to four times a week. Good options include broccoli, peppers, brussel sprouts and leafy greens like kale and spinach.", UnitPrice = 23.76F },
                    new FoodItem { FoodItemId = 102, FoodItemName = "Whole Grains", Description = "A good source of fiber has 3 to 4 grams of fiber per serving.", UnitPrice = 45.65F },
                    new FoodItem { FoodItemId = 103, FoodItemName = "Beans and Lentils", Description = "legumes, including beans and lentils, to soups, stews, casseroles, salads and dips", UnitPrice = 65.89F },
                    new FoodItem { FoodItemId = 104, FoodItemName = "Fish", Description = "A serving consists of 3 to 4 ounces of cooked fish. Good choices are salmon, trout, herring, bluefish, sardines and tuna.", UnitPrice = 56.78F },
                    new FoodItem { FoodItemId = 105, FoodItemName = "Berries", Description = "Berries such as raspberries, blueberries, blackberries and strawberries.", UnitPrice = 75.66F },
                    new FoodItem { FoodItemId = 106, FoodItemName = "Winter Squash", Description = "Eat butternut and acorn squash as well as other richly pigmented dark orange and green colored vegetables like sweet potato, cantaloupe and mango.", UnitPrice = 67.87F },
                    new FoodItem { FoodItemId = 107, FoodItemName = "Flaxseed, Nuts and Seeds", Description = "Ground flaxseed or other seeds to food each day ", UnitPrice = 75.54F },
                    new FoodItem { FoodItemId = 108, FoodItemName = "Organic Yogurt", Description = "Men and women between 19 and 50 years of age need 1000 milligrams of calcium a day and 1200 milligrams if 50 or older.", UnitPrice = 67.54F },
                    new FoodItem { FoodItemId = 109, FoodItemName = "Samp", Description = "Try a traditional umngqusho samp and beans dish to suit your taste buds.", UnitPrice = 78.34F },
                    new FoodItem { FoodItemId = 110, FoodItemName = "Pilchards in tins", Description = "You wouldn’t believe the amazing things you can do with tinned fish, so we’re showing you with our curried pilchard rotis.\r\n\r\n", UnitPrice = 23.45F }
                );
        }
    }
}
