using System.Web.Mvc;
using DelegatingController.Sample.Handlers.Home;

namespace DelegatingController.Sample.Controllers
{
    public class HomeController : DelegatingController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var vm = Invoker.Execute<HomeIndexViewModel>();

            return View(vm);
        }

        public ActionResult About()
        {
            //Used for sample instead of hitting db.
            var terms = (string)TempData["terms"];

            var vm = Invoker.Execute<string, AboutPageViewModel>(terms);
            return View(vm);
        }

        [HttpPost]
        public ActionResult About(AboutPageInputModel input)
        {
            if (!ModelState.IsValid)
                return About();
                
            Invoker.Execute(input);
            
            //Used for sample instead of hitting db.
            TempData["terms"] = input.Terms;

            return RedirectToAction("About");
        }
    }
}
