namespace _05.OOP_Principles___Part_2.BankAccounts
{
    public class Mortgage : Account, IDeposit
    {
        public Mortgage(double interestRate, CustomerType customerType)
            : base(interestRate, customerType)
        {
        }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(double months)
        {
            if (this.CustomerType == CustomerType.Company && months <= 12)
            {
                // You are paying the FULL interest rate for HALF of the 12 or less months period which is the same as HALF the interest rate for the WHOLE 12 or less months
                return base.CalculateInterest(months / 2);
            }
            else if (this.CustomerType == CustomerType.Company && months > 12)
            {
                return base.CalculateInterest(months - 12) + base.CalculateInterest(6);
            }
            else if (this.CustomerType == CustomerType.Individual && months <= 6)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterest(months - 6);
            }
        }
    }
}
