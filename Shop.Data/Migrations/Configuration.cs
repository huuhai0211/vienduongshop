namespace Shop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Data.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;// lúc vừa bạn thêm cái này này
        }

        protected override void Seed(Shop.Data.ShopDbContext context)
        {
            CreateAdmin(context);
            //CreateSlide(context);
            
        }

        private void CreateAdmin(Shop.Data.ShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "anhpham", 
                Email =  "anhpham@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = ""

            };

            manager.Create(user, "041095");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("anhpham@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(Shop.Data.ShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
        private void CreateFooter(Shop.Data.ShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string Content = "";
            }
        }

        private void CreateSlide(ShopDbContext context)
        {
            if(context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {Name = "Slide 1", DisplayOrder = 1, Status = true, URL = "#", Image = "/Assets/client/images/bag.jpg" },
                    new Slide() {Name = "Slide 2", DisplayOrder = 2, Status = true, URL = "#", Image = "/Assets/client/images/bag1.jpg" },
                    new Slide() {Name = "Slide 1", DisplayOrder = 1, Status = true, URL = "#", Image = "/Assets/client/images/bag.jpg" }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}
