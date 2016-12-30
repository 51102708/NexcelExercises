namespace Ex5
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double InterestAmount(int period)
        {
            if (Customer is CompanyCustomer)
            {
                if (period <= 12)
                {
                    return base.InterestAmount(period) / 2;
                }
                else
                {
                    return base.InterestAmount(period - 12) + (base.InterestAmount(12) / 2);
                }
            }

            if (Customer is IndividualCustomer)
            {
                return base.InterestAmount(period - 6);
            }

            return base.InterestAmount(period);
        }
    }
}