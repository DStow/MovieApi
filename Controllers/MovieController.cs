using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("Movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MetadataController> _logger;
        private readonly Services.IMovieService _movieService;

        public MovieController(ILogger<MetadataController> logger, Services.IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]

        [Route("stats")]
        public ActionResult<List<Dtos.MovieStatsDto>> Get()
        {
            var results = _movieService.GetMovieStats();

            return results.OrderByDescending(x => x.Watches).ThenByDescending(x => x.ReleaseYear).ToList();
        }
    }
}
