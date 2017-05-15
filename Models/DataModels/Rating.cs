using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rating
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public short Value { get; set; }
        public Review Review { get; set; }
    }
}
