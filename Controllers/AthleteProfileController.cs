using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mysegments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mysegments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteProfileController : ControllerBase
    {
        private readonly ILogger<AthleteProfileController> _logger;

        public AthleteProfileController(ILogger<AthleteProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public AthleteProfile Get()
        {
            AthleteProfile athlete =  new AthleteProfile("11112", "brad_head", "https://graph.facebook.com/689357002/picture", "meters");
            athlete.firstName = "Brad";
            athlete.lastName = "H";
            return athlete;
        }
    }
}
