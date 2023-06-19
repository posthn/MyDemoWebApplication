using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Application.Controllers;

public class HomeController : Controller
{
    private IDispatcher _dispatcher;

    public HomeController(IDispatcher dispatcher) => _dispatcher = dispatcher;

    public ViewResult Index() => View(_dispatcher.ExecuteQuery(new GetAllQuery<City>()));

    public ViewResult AddCity() => View();

    [HttpPost]
    public ActionResult AddCity(City newCity)
    {
        _dispatcher.ExecuteCommand(new CreateCommand<City>(newCity));

        return RedirectToAction(nameof(Index));
    }
}
