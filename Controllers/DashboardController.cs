using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestãoFinancas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestãoFinancas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var dashboard = _dashboardService.GetDashboard();
            return Ok(dashboard);
        }
    }

}