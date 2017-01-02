namespace Ex5
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int period)
        {
            if (Customer is CompanyCustomer)
            {
                if (period <= 12)
                {
                    return base.CalculateInterestAmount(period) / 2;
                }
                else
                {
                    return base.CalculateInterestAmount(period - 12) + (base.CalculateInterestAmount(12) / 2);
                }
            }

            if (Customer is IndividualCustomer)
            {
                return base.CalculateInterestAmount(period - 6);
            }

            return base.CalculateInterestAmount(period);
        }
    }
}