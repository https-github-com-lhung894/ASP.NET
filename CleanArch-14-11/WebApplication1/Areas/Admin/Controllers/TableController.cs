using Domain.IActions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Table")]
    public class TableController : Controller
    {
        private readonly IAccountAc accountAc;
        public TableController(IAccountAc accountAc)
        {
            this.accountAc = accountAc;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var acCounts = accountAc.ToList();
            return View(acCounts);
        }
    }
}
