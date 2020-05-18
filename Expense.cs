using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesWebApp
{
    public class ExpenseItem
    {
        public DateTime ExpenseDate { get; set; }
        public double Expenses { get; set; }
        public int Expense_type_ID { get; set; }
        public int User_ID { get; set; }
    }
}
