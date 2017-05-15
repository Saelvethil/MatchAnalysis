using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReviewComment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Body { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
