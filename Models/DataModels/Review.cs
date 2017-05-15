using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        // 1 - host 2 - guest 0 - draw
        public short Prediction { get; set; }
        public int FixtureId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
