using System;

namespace Ex5
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Account[] arrAccount = new Account[]
            {
                new DepositAccount(new IndividualCustomer("RaymondLe"), 1000000, 0.005),
                new LoanAccount(new IndividualCustomer("RaymondLe"), 2000, 0.007),
                new MortgageAccount(new IndividualCustomer("RaymondLe"), 8000, 0.006),

                new DepositAccount(new CompanyCustomer("ANguyenVan"), 5000000, 0.007),
                new LoanAccount(new CompanyCustomer("ANguyenVan"), 4000, 0.0085),
                new MortgageAccount(new CompanyCustomer("ANguyenVan"), 6000, 0.006),
            };

            Bank bankABC = new Bank("ABC Bank", arrAccount);
            Console.WriteLine(bankABC);
            Console.WriteLine("****************************");
            ////
            DepositAccount dpa = (DepositAccount)arrAccount[0];
            dpa.Deposit(500000);
            Console.WriteLine(dpa);
            dpa.WithDraw(200000);
            Console.WriteLine(dpa);
            ////
            Console.WriteLine("****************************");
            Console.WriteLine(arrAccount[1].InterestAmount(3));
            Console.WriteLine(arrAccount[1].InterestAmount(4));
            Console.WriteLine(arrAccount[2].InterestAmount(6));
            Console.WriteLine(arrAccount[2].InterestAmount(7));
            Console.WriteLine(arrAccount[5].InterestAmount(12));
            Console.WriteLine(arrAccount[5].InterestAmount(14));
            Console.ReadLine();
        }
    }
}