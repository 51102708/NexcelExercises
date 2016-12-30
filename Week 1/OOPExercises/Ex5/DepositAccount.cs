namespace Ex5
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public void WithDraw(double money)
        {
            Balance -= money;
        }

        public override double InterestAmount(int period)
        {
            if ((Balance >= 0) && (Balance < 1000))
            {
                return 0;
            }
            else
            {
                return base.InterestAmount(period);
            }
        }
    }
}