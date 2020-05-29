using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpensesWebApp.Utilities;

namespace ExpensesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExpenseController : ControllerBase

    {
        private readonly ILogger<ExpenseController> _logger;

        public IExpenseManager _expenseManager;

        public ExpenseController(ILogger<ExpenseController> logger, IExpenseManager expenseManager)
        {
            _logger = logger;
            _expenseManager = expenseManager;
        }
        
        [HttpGet]
        public IEnumerable<ExpenseItem> Get()
        {
            return Enumerable.Range(1, 1).Select(index => new ExpenseItem
            {
                Expenses = 10
            })
            .ToArray();
        }
        [HttpPost]
        public void Post (ExpenseItem expenseItem)
        {
            _expenseManager.Insert(expenseItem);
        }

    }
}