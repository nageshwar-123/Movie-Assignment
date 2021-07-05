using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Models.MarkAsSeen
{
    public class MarkAsSeenResponce
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int IsSeen { get; set; }
    }
}
