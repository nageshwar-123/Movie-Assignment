using MoventureApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Models.Thumbnail
{
    public class ThumbnailResponce
    {
        public int ThumbnailId { get; set; }
        public int ParentId { get; set; }
        public string ThumbnailName { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsCover { get; set; }
        public int ParentType { get; set; }



        public Movie MoviesList { get; set; }
    }
}
