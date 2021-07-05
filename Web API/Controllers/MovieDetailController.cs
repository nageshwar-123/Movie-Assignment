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
    public class MovieDetailController : ControllerBase
    {
        private IMovieDetailService _MovieDetailService;
        public MovieDetailController(IMovieDetailService moviedetailService)
        {
            _MovieDetailService = moviedetailService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _MovieDetailService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var Detail = _MovieDetailService.GetById(id);          
            return Ok(Detail);
        }
    }
}
