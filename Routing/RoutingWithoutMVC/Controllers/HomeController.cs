using Microsoft.AspNetCore.Mvc;

namespace RoutingWithoutMVC.Controllers
{
    //[Route("AttributeRoute")]   // this is treated as prefix of the all routes which are define into this controller
    //[Route("[controller]")]     // name of the Token can be anything , [controller] this is token name
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("~/Home")]
        //[Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("{id?}")]
        public int Details(int id)
        {
            return id;
        }
        //[Route("~/")]
        //[Route("Index/{id?}")]  // when we define route into the controller like that then this is called as attribute Routing
        [Route("{id?}")]
        public int AttributeRouting(int? id)
        {
            return id ?? 1;
        }
        //[Route("[action]")]
        public string Token()
        {
            return "Hi This is token";
        }
    }
}
