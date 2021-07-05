using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoventureApi.Entities
{
    public class MovieDetail
    {
        [Key]
        public int MovieDetailId { get; set; }
        public int MovieId { get; set; }
        public string Description { get; set; }

        public string Genre { get; set; }

        public string MovieTypeDesc { get; set; }

        public int DurationInMinutes { get; set; }
        public DateTime Release { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; }
        public ICollection<Cast> Casts { get; set; }

    }
}
