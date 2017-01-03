namespace Ex5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Bank
    {
        public Bank(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public Bank(string name, Account account) : this(name)
        {
            Accounts.Add(account);
        }

        public Bank(string name, Account[] account) : this(name)
        {
            Accounts = account.ToList();
        }

        private List<Account> Accounts { get; set; }

        public string Name { get; private set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (Account acc in Accounts)
            {
                str.Append(acc + "\n");
            }

            return string.Format("Bank: {0} \n {1}", Name, str);
        }
    }
}