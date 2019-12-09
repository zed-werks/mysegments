
//-------------------------------------------------------------------------
// Copyright © 2019 Zed Werks Inc.
//
// Licensed under the GNU General Public License, Version 3.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.gnu.org/licenses/gpl-3.0.en.html
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using mysegments.OAuth.Provider.Strava;

namespace mysegments.Controllers
{
    public class StravaController : Controller
    {
        private ILogger<StravaController> logger;
        private IConfiguration configuration;

        public StravaController(IConfiguration configuration, ILogger<StravaController> logger)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet("/Strava/Connect")]
        [AllowAnonymous]
        public IActionResult Connect(string returnUrl = "/Strava/Connected")
        {
            // Clear the existing external cookie to ensure a clean login process
            //await HttpContext.SignOutAsync();

            this.logger.LogDebug("Issuing Strava Connect Challenge");
            this.logger.LogDebug("Redirecting to {0}", returnUrl);

            var props = new AuthenticationProperties()
            {
                RedirectUri = Url.Action(returnUrl),
                Items =
                {
                    { "returnUrl", returnUrl },
                    { "scheme", StravaDefaults.AuthenticationScheme },
                }
            };
            return new ChallengeResult(StravaDefaults.AuthenticationScheme, props);
        }

        [HttpGet]
        public IActionResult Connected()
        {
            this.logger.LogInformation("/Strava/Connected");
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Disconnect()
        {
            return new SignOutResult(new[] { StravaDefaults.AuthenticationScheme, "Cookies" });
        }
    }
}
