using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [JsonObject(Description = "teams")]
    public class Team
    {
        //    "name": "Manchester United FC",
        //"shortName": "ManU",
        //"squadMarketValue": "377,250,000 €",
        //"crestUrl": "http://upload.wikimedia.org/wikipedia/de/d/da/Manchester_United_FC.svg"

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "squadMarketValue")]
        public string SquadMarketValue { get; set; }

        [JsonProperty(PropertyName = "crestUrl")]
        public string CrestUrl { get; set; }
    }
}
