using MoventureApi.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moventureapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moventureapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCastController : ControllerBase
    {
        private IMovieCastService _MovieCastService;
        public MovieCastController(IMovieCastService movieCastService)
        {
            _MovieCastService = movieCastService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _MovieCastService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var movieCost = _MovieCastService.GetById(id);
            return Ok(movieCost);
        }
    }
}
