namespace Ex5
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Withdraw(double money)
        {
            Balance -= money;
        }

        public override double CalculateInterestAmount(int period)
        {
            if ((Balance >= 0) && (Balance < 1000))
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(period);
            }
        }
    }
}