using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HalalBakersShop.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        public DbSet<AppUser> AppUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Fruit Cakes" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Cheese Biscuits" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Mixed Biscuits" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Pizza's" });

            //seed Itemss

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 1,
                Name = "Apple Cake",
                Price = 12.95M,
                ShortDescription = "Our famous apple Cake!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "/Images/c1.jpg",
                InStock = true,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl = "/Images/c1.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 2,
                Name = "Blueberry Cheese Cake",
                Price = 18.95M,
                ShortDescription = "You'll love it!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "/Images/c2.jpg",
                InStock = true,
                IsItemsOfTheWeek = false,
                ImageThumbnailUrl =
                    "/Images/c2.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 3,
                Name = "Cheese Cake",
                Price = 18.95M,
                ShortDescription = "Plain cheese cake. Plain pleasure.",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "/Images/c3.jpg",
                InStock = true,
                IsItemsOfTheWeek = false,
                ImageThumbnailUrl = "/Images/c3.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 4,
                Name = "Cherry Cake",
                Price = 15.95M,
                ShortDescription = "A summer classic!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "/Images/c4.jpg",
                InStock = true,
                IsItemsOfTheWeek = false,
                ImageThumbnailUrl = "/Images/c4.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 5,
                Name = "Christmas Apple Cake",
                Price = 13.95M,
                ShortDescription = "Happy holidays with this Items!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 1,
                ImageUrl = "/Images/c5.jpg",
                InStock = true,
                IsItemsOfTheWeek = false,
                ImageThumbnailUrl =
                    "/Images/c5.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 6,
                Name = "Simple Biscuits",
                Price = 17.95M,
                ShortDescription = "A Christmas favorite",
                LongDescription =
                    "Icing carrot Biscuits jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                ImageUrl = "/Images/c1.jpg",
                InStock = true,
                IsItemsOfTheWeek = false,
                ImageThumbnailUrl = "/Images/b1.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 7,
                Name = "Mixed Biscuits",
                Price = 15.95M,
                ShortDescription = "Sweet as peach",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 2,
                ImageUrl = "/Images/b2.jpg",
                InStock = false,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl = "/Images/b2.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 8,
                Name = "Mixed Biscuits",
                Price = 12.95M,
                ShortDescription = "Our Mixed Biscuits",
                LongDescription =
                    "Icing carrot Biscuits jelly-o Biscuits. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 3,
                ImageUrl = "/Images/b3.jpg",
                InStock = true,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl = "/Images/b3.jpg",
                AllergyInformation = ""
            });


            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 9,
                Name = "Mixed Biscuits",
                Price = 15.95M,
                ShortDescription = "My God, so sweet!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 3,
                ImageUrl = "/Images/b4.jpg",
                InStock = true,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl = "/Images/b4.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 10,
                Name = "Cheese Pizza",
                Price = 15.95M,
                ShortDescription = "Our delicious strawberry Pizza!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 4,
                ImageUrl = "/Images/p1.jpg",
                InStock = true,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl = "/Images/p1.jpg",
                AllergyInformation = ""
            });

            modelBuilder.Entity<Items>().HasData(new Items
            {
                ItemsId = 11,
                Name = "Simple Pizza",
                Price = 18.95M,
                ShortDescription = "You'll love it!",
                LongDescription =
                    "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake Items chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon Items muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart Items cake danish lemon drops. Brownie cupcake dragée gummies.",
                CategoryId = 4,
                ImageUrl = "/Images/p2.jpg",
                InStock = true,
                IsItemsOfTheWeek = true,
                ImageThumbnailUrl =
                    "/Images/p2.jpg",
                AllergyInformation = ""
            });
        }
    }
}
