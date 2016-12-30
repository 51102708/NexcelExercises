namespace Ex5
{
    public abstract class Customer
    {
        public Customer(string fname)
        {
            FullName = fname;
        }

        public string FullName { get; protected set; }

        public override string ToString()
        {
            return string.Format("Customer (FullName: {0}, Type: {1})", FullName, GetType());
        }
    }
}