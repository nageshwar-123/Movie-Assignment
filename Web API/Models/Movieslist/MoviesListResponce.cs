using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Models.Movieslist
{
    public class MoviesListResponce
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }

        public string coverPath { get; set; }
    }
}
