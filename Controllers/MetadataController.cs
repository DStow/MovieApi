using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase
    {
        private readonly ILogger<MetadataController> _logger;
        private readonly Services.IMetadataService _metadataService;

        public MetadataController(ILogger<MetadataController> logger, Services.IMetadataService metadataService)
        {
            _logger = logger;
            _metadataService = metadataService;
        }

        [HttpGet]
        public ActionResult<List<Models.Metadata>> Get(int movieId)
        {
            var results = _metadataService.GetMetadatas(movieId);

            if (results == null)
                return NotFound();
            else
                return results.OrderBy(x => x.Language).ToList();
        }

        [HttpPost]
        public ActionResult Post(Models.Metadata metadata)
        {
            _metadataService.AddMetadata(metadata);

            return Ok();
        }
    }
}
