using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex5
{
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
            StringBuilder str = new StringBuilder();
            foreach (Account acc in Accounts)
            {
                str.Append(acc.ToString() + "\n");
            }

            return string.Format("Bank: {0} \n {1}", Name, str.ToString());
        }
    }
}