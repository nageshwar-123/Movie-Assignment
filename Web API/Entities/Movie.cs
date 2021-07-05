using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoventureApi.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string category { get; set; }
        public MovieDetail MovieDetails { get; set; }

        public ICollection<Thumbnail> Thumbnails { get; set; }

    }
}
