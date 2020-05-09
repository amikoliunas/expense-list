using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExpensesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController (ILogger<ExpenseController> logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IEnumerable<expense> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new expense
            {
                ExpenseSum = 10
            })
            .ToArray();
        }

    }
}