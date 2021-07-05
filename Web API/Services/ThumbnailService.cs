using Microsoft.Extensions.Options;
using MoventureApi.Entities;
using MoventureApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Services
{
   

    public interface IThumbnailService
    {
        IEnumerable<Thumbnail> GetAll();
        Thumbnail GetById(int id);
    }
    public class ThumbnailService : IThumbnailService
    {
        private DataContext _context;

        private readonly AppSettings _appSettings;

        public ThumbnailService(DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Thumbnail> GetAll()
        {
            return _context.Thumbnails.ToList();
        }

        public Thumbnail GetById(int id)
        {
            return _context.Thumbnails.Find(id);
        }
    }
}
