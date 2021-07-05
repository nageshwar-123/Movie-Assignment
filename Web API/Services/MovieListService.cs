using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moventureapi.Models.Movieslist;
using MoventureApi.Entities;
using MoventureApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Services
{

    public interface IMovieListService
    {
        
        
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<IGrouping<string, Movie>> GetAllGroupByCatagory();
    }

    public class MovieListService : IMovieListService
    {
        private DataContext _context;
        
        private readonly AppSettings _appSettings;

        public MovieListService(
            DataContext context,            
            IOptions<AppSettings> appSettings)
        {
            _context = context;            
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.MoviesList.Include(t => t.Thumbnails.Where(x => x.IsCover == true)).ToList();
        }

        public Movie GetById(int id)
        {
            return _context.MoviesList
                .Include(t => t.Thumbnails)
                .Include(m => m.MovieDetails)
                .ThenInclude(c => c.Casts)
                .FirstOrDefault(x => x.MovieId == id);


        }
        public IEnumerable<IGrouping<string, Movie>> GetAllGroupByCatagory()
        {
            return _context.MoviesList.Include(t => t.Thumbnails.Where(x => x.IsCover == true)).GroupBy(x => x.category).ToList();
        }
    }
}
