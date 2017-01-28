namespace _05.OOP_Principles___Part_2.BankAccounts
{
    public class Deposit : Account, IWithdraw, IDeposit
    {
        public Deposit(double interestRate, CustomerType customerType) 
            : base(interestRate, customerType)
        {
        }

        public override void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithDrawMoney(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(double months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}
