using Models;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.DataAccess
{
    public static class CommentRepository
    {
        public static bool Create(Comment comment, string userName)
        {
            comment.LastUpdate = DateTime.Now;

            using (var context = new ApplicationDbContext())
            {
                comment.User = context.Users.First(x => x.Email == userName);
                comment.Review = context.Reviews.Find(comment.Review.Id);
                var result = context.Comments.Add(comment);
                context.SaveChanges();
                if (result == null)
                    return false;
            }
            return true;
        }

        public static bool Remove(int commentId)
        {
            using (var context = new ApplicationDbContext())
            {
                var commentToRemove = context.Comments.Find(commentId);
                if (commentToRemove == null) return false;
                context.Comments.Remove(commentToRemove);
                context.SaveChanges();
                return true;
            }
        }
    }
}