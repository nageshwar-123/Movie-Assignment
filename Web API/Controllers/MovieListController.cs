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
    public class MovieListController : ControllerBase
    {
        private IMovieListService _movieListService;
        public MovieListController (IMovieListService movieListService)
        {
            _movieListService = movieListService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _movieListService.GetAll();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetAllGroupByCatagory")]
        public IActionResult GetAllGroupByCatagory()
        {
            var list = _movieListService.GetAllGroupByCatagory();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieListService.GetById(id);
            return Ok(movie);
        }

    }
}
