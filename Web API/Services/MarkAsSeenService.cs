using Microsoft.Extensions.Options;
using MoventureApi.Entities;
using MoventureApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Services
{
    
    public interface IMarkAsSeenService
    {
        IEnumerable<MarkAsSeen> GetAll();
        MarkAsSeen GetById(int id);
    }
    public class MarkAsSeenService : IMarkAsSeenService
    {
        private DataContext _context;

        private readonly AppSettings _appSettings;

        public MarkAsSeenService(DataContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<MarkAsSeen> GetAll()
        {
            throw new NotImplementedException();
        }

        public MarkAsSeen GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
