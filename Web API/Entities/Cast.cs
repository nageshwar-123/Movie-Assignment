using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoventureApi.Entities
{
    public class Cast
    {
        [Key]
        public int CastId { get; set; }
        public string CastName { get; set; }
        // public string Age { get; set; }
        // public string CastDesc { get; set; }
        // public int CastType { get; set; }

        public ICollection<Thumbnail> Thumbnails { get; set; }
        [JsonIgnore]
        public ICollection<MovieDetail> Movies { get; set; }
        

    }
}
