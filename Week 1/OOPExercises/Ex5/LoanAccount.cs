namespace Ex5
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double InterestAmount(int period)
        {
            if (Customer is IndividualCustomer)
            {
                return base.InterestAmount(period - 3);
            }

            if (Customer is CompanyCustomer)
            {
                return base.InterestAmount(period - 2);
            }

            return base.InterestAmount(period);
        }
    }
}