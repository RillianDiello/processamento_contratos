using processamento_contratos.Services;
using System;
using System.Globalization;

namespace processamento_contratos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumber, contractDate, contractValue); // contstrutor do contrato 

            ContractService contractService = new ContractService(new PaypalService());
            /* aki a magica acontece, pois eu estou instancianod um ContratoService, indicando que o meio de pagamento utilizado
             * será o paypalservice, q é uma implementação da interface do IOnline PaymentService
             */
            contractService.ProcessContract(myContract, months);

            Console.WriteLine("Parcelas:");
            foreach (Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }

        }
    }
}
