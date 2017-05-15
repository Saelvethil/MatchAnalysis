using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Competition
    {

        //"id": 394,
        //"caption": "1. Bundesliga 2015/16",
        //"league": "BL1",
        //"year": "2015",
        //"numberOfTeams": 18,
        //"numberOfGames": 306,
        //"lastUpdated": "2015-10-25T19:06:29Z"

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "league")]
        public string League { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "numberOfTeams")]
        public int NumberOfTeams { get; set; }

        [JsonProperty(PropertyName = "numberOfGames")]
        public int NumberOfGames { get; set; }
    }
}
