using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoventureApi.Entities;
using MoventureApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Services
{
   

    public interface IMovieCastService
    {
        IEnumerable<MovieCast> GetAll();
        MovieCast GetById(int id);
    }
    public class MovieCastService : IMovieCastService
    {
        private DataContext _context;

        private readonly AppSettings _appSettings;

        public MovieCastService(DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<MovieCast> GetAll()
        {
            return _context.MovieCastMaping;
            //throw new NotImplementedException();
        }

        public MovieCast GetById(int id)
        {
            var moviecast = _context.MovieCastMaping.Find(id);
            if (moviecast == null) throw new KeyNotFoundException("User not found");
            return moviecast;
            //throw new NotImplementedException();
        }
    }
}
