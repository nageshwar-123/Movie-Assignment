//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using MoventureApi.Entities;
//using MoventureApi.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


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
    public interface ICastService
    {
        IEnumerable<Cast> GetAll();
        object GetById(int id);
    }
    public class CastService : ICastService
    {
        private DataContext _context;

        private readonly AppSettings _appSettings;

        public CastService(DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Cast> GetAll()
        {
            return _context.CastList.Include(t => t.Thumbnails.Where(x => x.IsCover == true)).ToList();
        }

        public object GetById(int id)
        {
            //return _context.CastList.Include(m => m.Movies).FirstOrDefault(x => x.CastId==id);

            var result = from movieCast in _context.MovieCastMaping 

                         join castlist in _context.CastList on movieCast.CastId equals castlist.CastId
                         where (movieCast.MovieId == id)
                         select new
                         {
                             castlist.CastId,
                             castlist.CastName,
                             castlist.Thumbnails,
                             movieCast.Character

                         };

            return result;
        }
    }
}
