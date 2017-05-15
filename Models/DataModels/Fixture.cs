using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [JsonObject(Description = "fixtures")]
    public class Fixture
    {
        //"id": 149461,
        //    "competitionId": 406,
        //    "date": "2014-07-08T20:00:00Z",
        //    "matchday": 6,
        //    "homeTeamName": "Brazil",
        //    "homeTeamId": 764,
        //    "awayTeamName": "Germany",
        //    "awayTeamId": 759,
        //    "result":
        //    {
        //        "goalsHomeTeam": 1,
        //        "goalsAwayTeam": 7
        //    }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "competitionId")]
        public int CompetitionId { get; set; }

        [JsonProperty(PropertyName = "matchday")]
        public int Matchday { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "homeTeamName")]
        public string HomeTeamName { get; set; }

        [JsonProperty(PropertyName = "homeTeamId")]
        public int HomeTeamId { get; set; }

        [JsonProperty(PropertyName = "awayTeamName")]
        public string AwayTeamName { get; set; }

        [JsonProperty(PropertyName = "awayTeamId")]
        public int AwayTeamId { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Result FixtureResult { get; set; }

        [JsonProperty(PropertyName = "homeTeam")]
        public Team HomeTeam { get; set; }

        [JsonProperty(PropertyName = "awayTeam")]
        public Team AwayTeam { get; set; }
    }
}
