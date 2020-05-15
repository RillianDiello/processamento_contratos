using System;
using System.Collections.Generic;
using System.Text;

namespace processamento_contratos.Services
{
    class PaypalService : IOnlinePaymentService
    {
        private const double FeePercentage = 0.02;
        private const double MonthyInterest = 0.01;
        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }

        public double Interest (double amount, int months)
        {
            return amount * MonthyInterest * months;
        }
    }
}
