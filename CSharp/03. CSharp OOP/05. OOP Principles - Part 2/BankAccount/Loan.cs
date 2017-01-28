namespace _05.OOP_Principles___Part_2.BankAccounts
{
    public class Loan : Account, IDeposit
    {
        public Loan(double interestRate, CustomerType customerType)
            : base(interestRate, customerType)
        {
        }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(double months)
        {
            if ((this.CustomerType == CustomerType.Individual && months <= 3)
                || (this.CustomerType == CustomerType.Company && months <= 2))
            {
                return 0;
            }
            else if (this.CustomerType == CustomerType.Individual)
            {
                return base.CalculateInterest(months - 3);
            }
            else
            {
                return base.CalculateInterest(months - 2);
            }
        }
    }
}
