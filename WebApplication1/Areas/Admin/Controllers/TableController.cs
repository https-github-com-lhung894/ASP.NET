using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/table")]
    public class TableController : Controller
    {
        private readonly IAccountAc accountAc;
        public TableController(IAccountAc accountAc)
        {
            this.accountAc = accountAc;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var acCounts = accountAc.ToList();
            return View(acCounts);
        }
    }
}
