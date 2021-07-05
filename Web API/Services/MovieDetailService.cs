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
   

    public interface IMovieDetailService
    {
        IEnumerable<MovieDetail> GetAll();
        object GetById(int id);
    }
    public class MovieDetailService : IMovieDetailService
    {
        private DataContext _context;

        private readonly AppSettings _appSettings;

        public MovieDetailService(DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<MovieDetail> GetAll()
        {
            return _context.MovieDetail.ToList();
        }

        public object GetById(int id)
        {
           // MovieDetail _movieDetail = null;
            //_movieDetail = _context.MovieDetail.FirstOrDefault(x => x.MovieId == id);

            var result = (from moviedetail in _context.MovieDetail  
                         join movielist in _context.MoviesList on moviedetail.MovieId equals movielist.MovieId 
                         join thumbnail in _context.Thumbnails on movielist.MovieId equals thumbnail.ParentId
                         where (moviedetail.MovieId == id) //&& !thumbnail.IsCover
                          // join cast in _context.CastList on moviedetail.MovieId equals cast.Movies..ParentId
                          select new
                         {
                             moviedetail.MovieDetailId,
                             moviedetail.Movie.MovieName,
                             moviedetail.MovieId,
                             moviedetail.MovieTypeDesc,
                             moviedetail.Release,
                             moviedetail.Genre,
                             moviedetail.DurationInMinutes,
                             moviedetail.Description,
                             thumbnail.ThumbnailPath,
                             thumbnail.ThumbnailName
                         }).Distinct();
                        return result;
        }


        
    }
}
