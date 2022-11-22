using EmployeeTimeTicketApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimeTicketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeTimeTicketContext _dbContext;

        public HomeController(ILogger<HomeController> logger, EmployeeTimeTicketContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
    }
}