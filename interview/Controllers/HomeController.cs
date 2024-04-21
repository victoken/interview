using interview.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        practiceContext _context;
        public HomeController(ILogger<HomeController> logger, practiceContext context)
        {
            ;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var netBankUsers = (from nbu in _context.NetBankUsers
                                join a in _context.Accounts on nbu.UserGuid equals a.OwnerGuid
                                where nbu.NationalID == "K188888886"
                                select new ViewModel
                                {
                                    NationalID = nbu.NationalID,
                                    BranchID = a.BranchID,
                                    AcctSerialID = a.AcctSerialID
                                }).ToList();

            return View(netBankUsers);
        }
            
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
