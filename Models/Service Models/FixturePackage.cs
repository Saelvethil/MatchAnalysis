using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FixturePackage
    {
        [JsonProperty(PropertyName = "fixture")]
        public Fixture Fixture { get; set; }
    }
}
