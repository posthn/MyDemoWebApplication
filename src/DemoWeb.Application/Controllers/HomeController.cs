using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Application.Controllers;

public class HomeController : Controller
{
    private ICommandDispatcher _commandDispatcher;
    private IQueryDispatcher _queryDispatcher;

    public HomeController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public ViewResult Index() =>
        View(_queryDispatcher.Execute<GetAllQuery<City>, City>(new GetAllQuery<City>()));

    public ViewResult AddCity() => View();

    [HttpPost]
    public ActionResult AddCity(City newCity)
    {
        _commandDispatcher.Execute<CreateCommand<City>, City>(new CreateCommand<City>(newCity));

        return RedirectToAction(nameof(Index));
    }
}
