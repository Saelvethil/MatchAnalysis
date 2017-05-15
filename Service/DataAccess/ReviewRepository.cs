using Models;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Service.DataAccess
{
    public static class ReviewRepository
    {
        public static UserReview Get(int reviewId)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = (from review in context.Reviews
                              from user in context.Users
                              where review.Id == reviewId
                              && review.User.Id == user.Id
                              select new { review = review, userName = user.UserName }).First();
                if (result != null)
                {
                    UserReview uReview = new UserReview
                    {
                        Title = result.review.Title,
                        Body = result.review.Body,
                        Prediction = result.review.Prediction,
                        Id = result.review.Id,
                        FixtureId = result.review.FixtureId,
                        UserName = result.userName,
                        LastUpdate = result.review.LastUpdate,
                        RatingsCount = result.review.Ratings.Count(),
                        Comments = new List<ReviewComment>()
                    };
                    if (uReview.RatingsCount > 0) uReview.Rating = result.review.Ratings.Average(x => x.Value);
                    else uReview.Rating = 0;
                    var comments = from comment in context.Comments
                                   where comment.Review.Id == reviewId
                                   select new ReviewComment() { Id = comment.Id, UserName = comment.User.UserName, Body = comment.Body, LastUpdate = comment.LastUpdate };
                    foreach (ReviewComment cmt in comments)
                    {
                        uReview.Comments.Add(cmt);
                    }
                    return uReview;
                }
                else return null;
            }
        }

        public static bool Create(Review review, string userName)
        {
            review.LastUpdate = DateTime.Now;

            using (var context = new ApplicationDbContext())
            {
                review.User = context.Users.First(x => x.Email == userName);
                var result = context.Reviews.Add(review);
                context.SaveChanges();
                if (result == null)
                    return false;
            }
            return true;
        }

        public static bool Update(Review review)
        {
            using (var context = new ApplicationDbContext())
            {
                var result = context.Reviews.Where(x => x.Id == review.Id).FirstOrDefault();
                if (result == null)
                    return false;

                result.Body = review.Body;
                result.Title = review.Title;
                result.LastUpdate = DateTime.Now;

                context.SaveChanges();

            }
            return true;
        }

        public static List<Review> GetFixtureReviews(int fixtureId)
        {
            using (var context = new ApplicationDbContext())
            {
                var res = context.Reviews.Where(x => x.FixtureId == fixtureId).ToList();
                List<Review> reviews = new List<Review>();
                foreach (var review in res)
                {
                    reviews.Add(new Review
                    {
                        Id = review.Id,
                        Body = review.Body,
                        Comments = null,
                        Prediction = review.Prediction,
                        Ratings = null,
                        Title = review.Title
                    });
                }
                return reviews;
            }
        }

        public static bool Remove(int reviewId)
        {
            using (var context = new ApplicationDbContext())
            {
                var reviewToRemove = context.Reviews.Include(x=>x.Comments).Include(x=>x.Ratings).Where(x => x.Id == reviewId).SingleOrDefault();
                if (reviewToRemove == null)
                    return false;
                var reviewComments = new List<Comment>();
                reviewComments.AddRange(reviewToRemove.Comments);
                var reviewRatings = new List<Rating>();
                reviewRatings.AddRange(reviewToRemove.Ratings);

                context.Reviews.Remove(reviewToRemove);
                context.Comments.RemoveRange(reviewComments);
                context.Ratings.RemoveRange(reviewRatings);
                context.SaveChanges();
                return true;


            }
        }



    }
}