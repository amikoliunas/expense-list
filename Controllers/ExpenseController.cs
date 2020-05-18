using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ExpensesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ExpenseController : ControllerBase

    {
        private readonly ILogger<ExpenseController> _logger;
        public IConfiguration Configuration { get; }

        public ExpenseController (ILogger<ExpenseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
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
        public void Post()
        {
            string connStr = Configuration.GetConnectionString("DatabaseConnectionString");
            using var conn = new SqlConnection(connStr);
            conn.Open();
            ExpenseItem one = new ExpenseItem
            {
                ExpenseDate = new DateTime(2000, 1, 1),
                Expenses = 20.01,
                Expense_type_ID = 2,
                User_ID = 1
            };
            SqlCommand useDB = new SqlCommand("USE Expenses", conn);
            useDB.ExecuteNonQuery();
            string query = "INSERT INTO dbo.expenses (date, expenses, expense_type_ID, user_ID) ";
            query += "VALUES (@date, @expenses, @expense_type_ID, @user_ID)";
            SqlCommand insert = new SqlCommand(query, conn);
            insert.Parameters.AddWithValue("@date", one.ExpenseDate);
            insert.Parameters.AddWithValue("@expenses", one.Expenses);
            insert.Parameters.AddWithValue("@expense_type_ID", one.Expense_type_ID);
            insert.Parameters.AddWithValue("@user_ID", one.User_ID);
            insert.ExecuteNonQuery();
            conn.Close();
        }

    }
}