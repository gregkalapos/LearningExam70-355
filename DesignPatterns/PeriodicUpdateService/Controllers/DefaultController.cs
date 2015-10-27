using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PeriodicUpdateService.Controllers
{
    public class DefaultController : ApiController
    {
        public HttpResponseMessage Get(int position)
        {
            var msg = string.Format("Received request for position {0}", position);
            Console.WriteLine(msg);

            var tileTitle = string.Format("Backend Noti {0}", position);
            var tilesSubtitle = DateTime.UtcNow.AddHours(position);

            var result = Generator.Generate(tileTitle, tilesSubtitle);

            var response = Request.CreateResponse(HttpStatusCode.OK, result);
            response.Headers.Add("X-WNS-Expires", tilesSubtitle.AddMinutes(15).ToString("r"));
            response.Headers.Add("X-WNS-Tag", position.ToString());

            return response;
        }
    }
}
