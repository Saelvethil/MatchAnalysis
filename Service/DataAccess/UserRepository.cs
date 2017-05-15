using Models;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Service.DataAccess
{
    public static class UserRepository
    {
        public static String GetUserRole(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                var user = context.Users.Where(x => x.Email == username).FirstOrDefault();
                if (user == null)
                    return "anonymous";

                var userRole = user.Roles.First();
                string role = context.Roles.Where(x => x.Id == userRole.RoleId).First().Name;
                return role;
            }
        }

        public static List<UserWithRole> GetUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var usersWithRole = from user in context.Users
                                    from role in context.Roles
                                    from userRole in user.Roles
                                    where userRole.RoleId == role.Id
                                    orderby user.UserName
                                    select new UserWithRole { UserId = user.Id, UserName = user.UserName, RoleName = role.Name };

                return usersWithRole.ToList();
            }
        }

        public static bool RemoveUser(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var userToRemove = context.Users.SingleOrDefault(x => x.Id == userId);
                if (userToRemove == null)
                    return false;

                var reviews = context.Reviews.Include(x=>x.Comments).Where(x => x.User.Id == userId).ToList();
                var reviewsComments = new List<Comment>();
                reviews.ForEach(x => reviewsComments.AddRange(x.Comments));
                var reviewRatings = new List<Rating>();
                reviews.ForEach(x => reviewRatings.AddRange(x.Ratings));
                var userRatings = context.Ratings.Where(x => x.User.Id == userId).ToList();
                var userComments = context.Comments.Where(x => x.User.Id == userId).ToList();

                context.Reviews.RemoveRange(reviews);
                context.Ratings.RemoveRange(reviewRatings);
                context.Ratings.RemoveRange(userRatings);
                context.Comments.RemoveRange(reviewsComments);
                context.Comments.RemoveRange(userComments);
                context.Users.Remove(userToRemove);
                context.SaveChanges();
                return true;
            }
        }

        public static bool UpdateUser(string userId, string roleName)
        {
            using (var context = new ApplicationDbContext())
            {
                var userToUpdate = context.Users.SingleOrDefault(x => x.Id == userId);
                if (userToUpdate == null)
                    return false;

                var role = context.Roles.Single(x => x.Name == roleName);
                userToUpdate.Roles.Clear();
                userToUpdate.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole() { RoleId = role.Id, UserId = userToUpdate.Id});
                context.SaveChanges();
                return true;
            }
        }
    }
}