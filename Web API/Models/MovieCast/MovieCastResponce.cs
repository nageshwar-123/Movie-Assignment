using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Models.MovieCast
{
    public class MovieCastResponce
    {
        public int Id { get; set; }
        public int CastId { get; set; }

        public int MovieId { get; set; }

        public string Character { get; set; }
    }
}
