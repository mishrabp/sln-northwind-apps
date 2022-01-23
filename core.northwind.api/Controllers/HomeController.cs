using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace core.northwind.api.Controllers
{
    [Route("/index")]
    [Produces("text/html")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Redirect("~/swagger");
            var rHtml = "<html>";
            rHtml = rHtml + "<head>Web API: core.northwind.api</head>";
            rHtml = rHtml + "<body>";
            rHtml = rHtml + "<h1>Web API: core.northwind.api</h1>";
            rHtml = rHtml + "<br/>";
            rHtml = rHtml + "<h2>";
            rHtml = rHtml + "<a href='/swagger'>Swagger Documentation</a>";
            rHtml = rHtml + "</h2>";

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = rHtml
            };
        }
    }
}
