using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moventureapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoventureApi.Authorization;

namespace Moventureapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThumbnailController : ControllerBase
    {
        private IThumbnailService _ThumbnailService;
        public ThumbnailController(IThumbnailService thumbnailService)
        {
            _ThumbnailService = thumbnailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _ThumbnailService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var thumbnail = _ThumbnailService.GetById(id);
            return Ok(thumbnail);
        }
    }
}
