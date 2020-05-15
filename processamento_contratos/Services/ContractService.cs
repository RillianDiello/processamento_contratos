using System;
using System.Collections.Generic;
using System.Text;

namespace processamento_contratos.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }
        public void ProcessContract( Contract contract, int months)
        {
            double basicQuota = contract.totalValue / months; // divide o valor total pelo numero de cotas

            for (int i = 1; i <= months; i++)
            {
                DateTime dt = contract.date.AddMonths(i); // esse valor é adicionado a cada data de pagamento de cota
                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i); //
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallments(new Installment(dt, fullQuota));
            }

        }
    }
}
