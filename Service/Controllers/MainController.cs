using Models;
using Models.Service_Models;
using Newtonsoft.Json;
using Service.DataAccess;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/MainController")]
    public class MainController : ApiController
    {
        //get competitions
        //get Fixtures(id cpt)
        //get Fixtures(id cpt, int matchday)
        //get Fixture(id fxt)
        //get Team(id team)
        //----------
        //get Reviews()
        //get/post/put/delete Review(id rvw)
        //get Reviews(id usr)
        //get Reviews(id fxt)

        //get/post Comments(id rvw)
        //put/delete Comment(id cmt)

        //get Ratings(id rvw)
        //set Rating(id rvw, id usr) 


        [HttpGet]
        [Route("Competitions")]
        [AllowAnonymous]
        public async Task<List<Competition>> GetCompetitions()
        {
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("v1/competitions/?season=" + 2016);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Competition>>(stringResponse);
                    return list;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }

        [HttpGet]
        [Route("Fixtures")]
        [AllowAnonymous]
        public async Task<List<Fixture>> GetAllFixtures()
        {
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("/v1/fixtures/");
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var aggregator = JsonConvert.DeserializeObject<FixtureAggregator>(stringResponse);
                    return aggregator.Fixtures;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }

        [HttpGet]
        [Route("Fixtures/competitionId/{competitionId:int}")]
        [AllowAnonymous]
        public async Task<List<Fixture>> GetFixtures(int competitionId)
        {
            List<Fixture> fixtureRes;
            List<Team> teamRes;
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("/v1/competitions/" + competitionId + "/fixtures");
                if (response.IsSuccessStatusCode)
                {
                    fixtureRes = new List<Fixture>();
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var aggregator = JsonConvert.DeserializeObject<FixtureAggregator>(stringResponse);
                    fixtureRes = aggregator.Fixtures.Where(x => x.Date > DateTime.Now && x.Date < DateTime.Now.AddDays(7)).OrderBy(x => x.Date).ToList();
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
                var teamsResponse = await client.GetAsync("v1/competitions/" + competitionId + "/teams");
                if (teamsResponse.IsSuccessStatusCode)
                {
                    teamRes = new List<Team>();
                    var stringResponse = await teamsResponse.Content.ReadAsStringAsync();
                    var aggregator = JsonConvert.DeserializeObject<TeamAggregator>(stringResponse);
                    teamRes = aggregator.Teams;
                    foreach (var fixture in fixtureRes)
                    {
                        foreach (var team in teamRes)
                        {
                            if (fixture.AwayTeamName == team.Name)
                                fixture.AwayTeam = team;
                            if (fixture.HomeTeamName == team.Name)
                                fixture.HomeTeam = team;
                        }
                    }
                    return fixtureRes;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }
        [HttpGet]
        [Route("Fixtures/competitionId/{competitionId:int}/matchday/{matchday:int}")]
        [AllowAnonymous]
        public async Task<List<Fixture>> GetFixtures(int competitionId, int matchday)
        {
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("/v1/competitions/" + competitionId + "/fixtures?matchday=" + matchday);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<FixtureAggregator>(stringResponse);
                    return list.Fixtures;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }

        [HttpGet]
        [Route("Fixtures/fixtureId/{fixtureId:int}")]
        [AllowAnonymous]
        public async Task<Fixture> GetFixture(int fixtureId)
        {
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("/v1/fixtures/" + fixtureId);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var fixturePackage = JsonConvert.DeserializeObject<FixturePackage>(stringResponse);
                    return fixturePackage.Fixture;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }
        [HttpGet]
        [Route("Teams/teamId/{teamId:int}")]
        [AllowAnonymous]
        public async Task<Team> GetTeam(int teamId)
        {
            using (var client = MyClient.GetClient())
            {
                var response = await client.GetAsync("/v1/teams/" + teamId);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var team = JsonConvert.DeserializeObject<Team>(stringResponse);
                    return team;
                }
                else
                {
                    throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
                }
            }
        }
        //get Reviews()
        //get/post/put/delete Review(id rvw)
        //get Reviews(id usr)
        //get Reviews(id fxt)

        [HttpGet]
        [Route("Reviews/reviewId/{reviewId:int}")]
        [AllowAnonymous]
        public UserReview GetReview(int reviewId)
        {
            var result = ReviewRepository.Get(reviewId);
            if (result != null) return result;
            else throw new Exception(System.Reflection.MethodBase.GetCurrentMethod().Name + " Exception");
        }

        [HttpGet]
        [Route("Reviews/userId/{userId:int}")]
        [AllowAnonymous]
        public async Task<List<Review>> GetUserReviews(int userId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("Reviews/fixtureId/{fixtureId:int}")]
        [AllowAnonymous]
        public List<Review> GetFixturesReviews(int fixtureId)
        {
            var reviews = ReviewRepository.GetFixtureReviews(fixtureId);
            return reviews;
        }

        [HttpPost]
        [Route("Reviews")]
        [Authorize]
        public HttpResponseMessage CreateReview([FromBody]Review review)
        {
            if (ReviewRepository.Create(review, HttpContext.Current.User.Identity.Name))
                return Request.CreateResponse<bool>(HttpStatusCode.Created, false);
            return Request.CreateResponse<bool>(HttpStatusCode.Created, true);
        }

        [HttpPut]
        [Route("Reviews")]
        [AllowAnonymous]
        public HttpResponseMessage UpdateReview(Review review)
        {
            if (ReviewRepository.Update(review))
                return Request.CreateResponse<bool>(HttpStatusCode.OK, false);
            else
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
        }

        [HttpDelete]
        [Route("Reviews/{reviewId:int}")]
        [AllowAnonymous]
        public HttpResponseMessage DeleteReview(int reviewId)
        {
            if (ReviewRepository.Remove(reviewId))
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            else
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("Ranking")]
        [AllowAnonymous]
        public List<RankingEntry> GetRanking()
        {
            List<RankingEntry> result = RatingRepository.GetRanking();
            return result;
        }

        [HttpGet]
        [Route("Rated/{reviewId}")]
        public bool IsAvailableToRate(int reviewId)
        {
            bool result = RatingRepository.IsAvailableToRate(reviewId, HttpContext.Current.User.Identity.Name);
            return result;
        }

        [HttpPost]
        [Route("Rating/{reviewId}/{value}")]
        public void RateReview(int reviewId, int value)
        {
            RatingRepository.RateReview(reviewId, value, HttpContext.Current.User.Identity.Name);
        }

        [HttpPost]
        [Route("Comment")]
        [Authorize]
        public HttpResponseMessage CreateComment([FromBody]Comment comment)
        {
            if (CommentRepository.Create(comment, HttpContext.Current.User.Identity.Name))
                return Request.CreateResponse<bool>(HttpStatusCode.Created, false);
            return Request.CreateResponse<bool>(HttpStatusCode.Created, true);
        }

        [HttpDelete]
        [Route("Comment/{commentId:int}")]
        [AllowAnonymous]
        public HttpResponseMessage DeleteComment(int commentId)
        {
            if (CommentRepository.Remove(commentId))
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            else
                return Request.CreateResponse<bool>(HttpStatusCode.OK, true);
        }
    }
}