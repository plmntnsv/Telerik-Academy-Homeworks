namespace _05.OOP_Principles___Part_2.BankAccounts
{
    using System;

    public abstract class Account : IDeposit
    {
        private decimal balance;

        /*For creating an account, you will only need the interest rate and the customer type. 
         *The balance by default/initially is 0 and then you can add money. Made more sense to me doing it that way.*/
        public Account(double interestRate, CustomerType customerType)
        {
            this.InterestRate = interestRate;
            this.CustomerType = customerType;
            this.Balance = 0;
        }

        public double InterestRate { get; private set; }

        public CustomerType CustomerType { get; private set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("You don't have enough money in the your account for this operation!");
                }

                this.balance = value;
            }
        }

        public virtual decimal CalculateInterest(double months)
        {
            decimal interest = (decimal)months * ((decimal)this.InterestRate / 100);
            return interest;
        }

        public abstract void DepositMoney(decimal amount);
    }
}
