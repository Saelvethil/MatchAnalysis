using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        // 1 - host 2 - guest 0 - draw
        public short Prediction { get; set; }
        public int FixtureId { get; set; }
        public double Rating { get; set; }
        public int RatingsCount { get; set; }
        public List<ReviewComment> Comments { get; set; }
    }
}
