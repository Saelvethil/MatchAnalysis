using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            CreateRolesandUsers(context);

            var user1 = context.Users.Where(x => x.Email == "user@gmail.com").First();
            var user2 = context.Users.Where(x => x.Email == "user2@gmail.com").First();
            var user3 = context.Users.Where(x => x.Email == "user3@gmail.com").First();

            var review = new Review();
            review.Body = "BODEBODEBODEBODEBODE\nBODEBODEBODEBODEBODEBODEBODEBODEBODEBODEBODE\n\n\n\nBODEBODE\n";
            review.FixtureId = 152116;
            review.Prediction = 1;
            review.User = user1;
            review.Title = "WIELKI MECZ";
            review.LastUpdate = DateTime.Now;
            context.Reviews.Add(review);

            var rating = new Rating();
            rating.Review = review;
            rating.User = user2;
            rating.Value = 6;
            context.Ratings.Add(rating);

            review = new Review();
            review.Body = "TO JE 2 ANALIZA";
            review.FixtureId = 152116;
            review.Prediction = 2;
            review.User = user2;
            review.LastUpdate = DateTime.Now;
            review.Title = "WIELKI MECZ ANALIZA 2";
            context.Reviews.Add(review);

            review = new Review();
            review.Body = "TO JE 2 ANALIZA UZYTKOWNIKA USER2";
            review.FixtureId = 152116;
            review.Prediction = 2;
            review.User = user2;
            review.LastUpdate = DateTime.Now;
            review.Title = "NIE TAK BARDZO WIELKI MECZ ANALIZA 2";
            context.Reviews.Add(review);

            rating = new Rating();
            rating.Review = review;
            rating.User = user1;
            rating.Value = 8;
            context.Ratings.Add(rating);

            rating = new Rating();
            rating.Review = review;
            rating.User = user3;
            rating.Value = 7;
            context.Ratings.Add(rating);

            var comment = new Comment();
            comment.Body = "taka jest moja koncepcja, tak ja to widzę";
            comment.Review = review;
            comment.LastUpdate = DateTime.Now.AddDays(-1);
            comment.User = user2;
            context.Comments.Add(comment);

            comment = new Comment();
            comment.Body = "też tak myślę";
            comment.Review = review;
            comment.User = user1;
            comment.LastUpdate = DateTime.Now.AddHours(-1);
            context.Comments.Add(comment);

            comment = new Comment();
            comment.Body = "też tak myślę i ja";
            comment.Review = review;
            comment.LastUpdate = DateTime.Now;
            comment.User = user3;            
            context.Comments.Add(comment);
            
            

            context.SaveChanges();
        }

        private void CreateRolesandUsers(ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);
            }

            // add admin
            var admin = new ApplicationUser();
            admin.UserName = "admin@gmail.com";
            admin.Email = "admin@gmail.com";

            string adminPWD = "Welcome1!";

            var chkAdmin = UserManager.Create(admin, adminPWD);

            if (chkAdmin.Succeeded)
            {
                var result1 = UserManager.AddToRole(admin.Id, "Admin");
            }

            // add mod
            var mod = new ApplicationUser();
            mod.UserName = "mod@gmail.com";
            mod.Email = "mod@gmail.com";

            string modPWD = "Welcome1!";

            var chkMod = UserManager.Create(mod, modPWD);

            if (chkMod.Succeeded)
            {
                var result1 = UserManager.AddToRole(mod.Id, "Moderator");
            }

            var user = new ApplicationUser();
            user.UserName = "user@gmail.com";
            user.Email = "user@gmail.com";
            string userPWD = "Welcome1!";
            var chkUser = UserManager.Create(user, userPWD);

            if (chkUser.Succeeded)
            {
                UserManager.AddToRole(user.Id, "User");
            }

            var user2 = new ApplicationUser();
            user2.UserName = "user2@gmail.com";
            user2.Email = "user2@gmail.com";
            string user2PWD = "Welcome1!";
            var chkUser2 = UserManager.Create(user2, user2PWD);

            if (chkUser2.Succeeded)
            {
                UserManager.AddToRole(user2.Id, "User");
            }

            var user3 = new ApplicationUser();
            user3.UserName = "user3@gmail.com";
            user3.Email = "user3@gmail.com";
            string user3PWD = "Welcome1!";
            var chkUser3 = UserManager.Create(user3, user3PWD);

            if (chkUser3.Succeeded)
            {
                UserManager.AddToRole(user3.Id, "User");
            }
        }
    }
}