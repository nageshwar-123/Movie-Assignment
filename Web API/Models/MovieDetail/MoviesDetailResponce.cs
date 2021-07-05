using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Models.MovieDetail
{
    public class MoviesDetailResponce
    {
        public int MovieDetailId { get; set; }
        public int MovieId { get; set; }
        public string Description { get; set; }
        public string MovieTypeDesc { get; set; }

        public int DurationInMinutes { get; set; }
        public DateTime Release { get; set; }
    }
}
