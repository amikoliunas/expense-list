using System.Collections.Generic;
using System.Linq;
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
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new Expense
            {
                ExpenseSum = 10
            })
            .ToArray();
        }

    }
}