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
    public class CastController : ControllerBase
    {
        private ICastService _CastService;
        public CastController(ICastService castService)
        {
            _CastService = castService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var list = _CastService.GetAll();
            return Ok(list);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var cast = _CastService.GetById(id);
            return Ok(cast);
        }
    }
}
