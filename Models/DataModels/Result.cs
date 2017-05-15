using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [JsonObject(Description = "result")]
    public struct Result
    {

        //    "result":
        //    {
        //        "goalsHomeTeam": 1,
        //        "goalsAwayTeam": 7
        //    }

        [JsonProperty(PropertyName = "goalsAwayTeam")]
        public int? GoalsAwayTeam { get; set; }

        [JsonProperty(PropertyName = "goalsHomeTeam")]
        public int? GoalsHomeTeam { get; set; }
    }
}
