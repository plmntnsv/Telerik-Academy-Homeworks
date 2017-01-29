namespace _04.OOP_Principles___Part_1.StudentsAndWorkers
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public int WeekSalary { get; private set; }

        public int WorkHoursPerDay { get; private set; }

        public double MoneyPerHour()
        {
            double moneyPerHour = (double)this.WeekSalary / (this.WorkHoursPerDay * 5);
            return moneyPerHour;
        }
    }
}
