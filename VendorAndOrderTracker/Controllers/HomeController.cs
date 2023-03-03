using Microsoft.AspNetCore.Mvc;

namespace VendorAndOrderTracker.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
      
      // Pictures: <link rel="stylesheet" type="text/css" href="~/css/styles.css" />
      [Route("/favorite_photos")]
      public ActionResult FavoritePhotos()
      {
        return View();
      }
    }
}