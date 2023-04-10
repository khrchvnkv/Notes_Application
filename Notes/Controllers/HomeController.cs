using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DataManager dataManager,
            ILogger<HomeController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DataLayer.Entities.Directory> directories = 
                _dataManager.DirectoriesRepository.GetAllDirectories(true).ToList();
            return View(directories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

