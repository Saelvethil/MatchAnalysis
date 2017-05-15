using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Comment
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Body { get; set; }
        public DateTime LastUpdate { get; set; }
        public Review Review { get; set; }
    }
}
