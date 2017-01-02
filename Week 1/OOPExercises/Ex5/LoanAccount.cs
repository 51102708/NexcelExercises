namespace Ex5
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int period)
        {
            if (Customer is IndividualCustomer)
            {
                return base.CalculateInterestAmount(period - 3);
            }

            if (Customer is CompanyCustomer)
            {
                return base.CalculateInterestAmount(period - 2);
            }

            return base.CalculateInterestAmount(period);
        }
    }
}