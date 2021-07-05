using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoventureApi.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }
        public int CastId { get; set; }

        public int MovieId { get; set; }
        public string Character { get; set; }
        //public int CastType { get; set; }

    }
}
