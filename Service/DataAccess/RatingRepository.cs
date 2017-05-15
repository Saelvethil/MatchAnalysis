using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Models;
using Service.Models;

namespace Service.DataAccess
{
    public static class RatingRepository
    {
        public static List<RankingEntry> GetRanking()
        {
            var ranking = new List<RankingEntry>();

            using (var context = new ApplicationDbContext())
            {
                var ratings = from rating in context.Ratings
                              from review in context.Reviews
                              from user in context.Users
                              where rating.Review.User.Id == user.Id
                              && rating.Review.Id == review.Id
                              orderby user.UserName
                              select new { UserId = user.Id, user.UserName, rating.Value };
                var ratingsCollection = ratings.ToList().GroupBy(x => x.UserId);

                foreach (var group in ratingsCollection)
                {
                    RankingEntry entry = new RankingEntry();
                    entry.Value = group.Average(x => x.Value);
                    entry.RatingsCount = group.Count();
                    entry.UserId = group.First().UserId;
                    entry.UserName = group.First().UserName;
                    ranking.Add(entry);
                }
            }

            return ranking.OrderByDescending(x => x.Value).ToList();
        }

        public static bool IsAvailableToRate(int reviewId, string name)
        {
            using (var context = new ApplicationDbContext())
            {
                var review = context.Reviews.Where(x => x.Id == reviewId).Include(x => x.User).FirstOrDefault();
                if (review == null)
                    return false;

                if (review.User.UserName == name)
                {
                    //cant rate own review
                    return false;
                }

                return !context.Ratings.Any(x => x.Review.Id == reviewId && x.User.UserName == name);
            }
        }

        public static void RateReview(int reviewId, int value, string name)
        {
            using (var context = new ApplicationDbContext())
            {
                var review = context.Reviews.Where(x => x.Id == reviewId).Include(x => x.User).FirstOrDefault();
                var user = context.Users.FirstOrDefault(x => x.UserName == name);
                if (review == null || user == null)
                    return;

                Rating rating = new Rating();
                rating.Review = review;
                rating.User = user;
                rating.Value = (short)value;
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }
    }
}