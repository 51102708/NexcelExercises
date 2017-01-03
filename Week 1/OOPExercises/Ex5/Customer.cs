namespace Ex5
{
    public abstract class Customer
    {
        protected Customer(string fname)
        {
            FullName = fname;
        }

        public string FullName { get; private set; }

        public override string ToString()
        {
            return string.Format("Customer (FullName: {0}, Type: {1})", FullName, GetType());
        }
    }
}