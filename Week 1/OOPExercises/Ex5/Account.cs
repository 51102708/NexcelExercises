namespace Ex5
{
    public abstract class Account
    {
        protected Account(Customer customer, double balance, double interestRate)
        {
            Customer = customer;
            Balance = balance;
            InterestRate = interestRate;
        }

        public Customer Customer { get; private set; }

        public double Balance { get; protected set; }

        public double InterestRate { get; private set; }

        public string Deposit(double money)
        {
            Balance += money;
            return "Deposit money done!";
        }

        public virtual double CalculateInterestAmount(int period)
        {
            if (period > 0)
            {
                return Balance * InterestRate * period;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} | AccountType: {3} | Balance: {1} | Interest Rate: {2}.", Customer, Balance, InterestRate, GetType());
        }
    }
}