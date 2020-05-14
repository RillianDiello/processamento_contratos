using System;
using System.Collections.Generic;
using System.Text;

namespace processamento_contratos.Services
{
    class Installment
    {

        public DateTime dueDate { get; set; }

        public double amount { get; set; }

        public Installment(DateTime dueDate, double amount)
        {
            this.dueDate = dueDate;
            this.amount = amount;
        }
    }
}
