using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Application.Controllers;

public class HomeController : Controller
{
    private ISQLiteRepository _repository;

    public HomeController(ISQLiteRepository repository) => _repository = repository;

    public ViewResult Index() => View(_repository.Get<City>());
}
