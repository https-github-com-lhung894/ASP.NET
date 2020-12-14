using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        private readonly IDashboardSv dashboardSv;
        public DashboardController(IDashboardSv dashboardSv)
        {
            this.dashboardSv = dashboardSv;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            Dashboard dashboard = dashboardSv.Get();
            
            return View(dashboard);
        }
    }
}
