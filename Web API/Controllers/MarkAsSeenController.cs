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
    public class MarkAsSeenController : ControllerBase
    {
        private IMarkAsSeenService _MarkAsSeenService;
        public MarkAsSeenController(IMarkAsSeenService markAsSeenService)
        {
            _MarkAsSeenService = markAsSeenService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _MarkAsSeenService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var markasseen = _MarkAsSeenService.GetById(id);
            return Ok(markasseen);
        }
    }
}
