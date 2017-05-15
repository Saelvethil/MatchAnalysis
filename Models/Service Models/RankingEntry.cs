using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RankingEntry
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public double Value { get; set; }
        public int RatingsCount { get; set; }
    }
}
