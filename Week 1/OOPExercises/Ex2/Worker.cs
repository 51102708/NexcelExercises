namespace Ex2
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        public double CalculateMoneyPerHour()
        {
            double daySalary = WeekSalary / 5;
            return daySalary / WorkHoursPerDay;
        }

        public override string ToString()
        {
            var baseString = base.ToString();

            return string.Format("{0}, MoneyPerHour: {1}", baseString, CalculateMoneyPerHour());
        }
    }
}