using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoventureApi.Entities
{
    public class Thumbnail
    {
        [Key]
        public int ThumbnailId { get; set; }
        
        public int ParentId { get; set; }
        public string ThumbnailName { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsCover { get; set; }        
        public int ParentType { get; set; }


        [JsonIgnore]
        public Movie MoviesList { get; set; }
        [JsonIgnore]
        public Cast cast { get; set; }
    }        
}
