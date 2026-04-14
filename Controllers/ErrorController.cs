using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult Status(int statusCode)
        {
            if (statusCode == 404)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            Response.StatusCode = statusCode;
            return View("ServerError");
        }

        [Route("Error/ServerError")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}
