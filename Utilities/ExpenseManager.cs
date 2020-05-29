using System.Data.SqlClient;

namespace ExpensesWebApp.Utilities
{
    public class ExpenseManager : IExpenseManager
    {
        public IConnectionToDB _connection;
        public ExpenseManager(IConnectionToDB connection)
        {
            _connection = connection;
        }
        public void Insert(ExpenseItem expenseItem)
        {
            string query = "USE Expenses ";
            query += "INSERT INTO dbo.expenses (date, expenses, expense_type_ID, user_ID) ";
            query += "VALUES (@date, @expenses, @expense_type_ID, @user_ID)";
            var insert = new SqlCommand(query, _connection.Connect());
            insert.Parameters.AddWithValue("@date", expenseItem.ExpenseDate);
            insert.Parameters.AddWithValue("@expenses", expenseItem.Expenses);
            insert.Parameters.AddWithValue("@expense_type_ID", expenseItem.Expense_type_ID);
            insert.Parameters.AddWithValue("@user_ID", expenseItem.User_ID);
            insert.ExecuteNonQuery();
        }
    }
}
