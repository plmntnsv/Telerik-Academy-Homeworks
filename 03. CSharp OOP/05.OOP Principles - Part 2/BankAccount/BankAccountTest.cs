namespace _05.OOP_Principles___Part_2.BankAccounts
{
    using System;

    public static class BankAccountTest
    {
        public static void Test()
        {
            Deposit depositAccInd = new Deposit(12, CustomerType.Individual);
            Deposit depositAccCom = new Deposit(12, CustomerType.Company);
            Loan loanAccInd = new Loan(12, CustomerType.Individual);
            Loan loanAccCom = new Loan(12, CustomerType.Company);
            Mortgage mortgageAccInd = new Mortgage(12, CustomerType.Individual);
            Mortgage mortgageAccCom = new Mortgage(12, CustomerType.Company);

            depositAccCom.DepositMoney(20);

            // Uncomment to cause an exception when you withdraw more than you have in your account
            ////depositAccCom.WithDrawMoney(20.1m); 
            Account[] accounts = new Account[] { depositAccCom, depositAccInd, loanAccCom, loanAccInd, mortgageAccCom, mortgageAccInd };

            foreach (Account acc in accounts)
            {
                Console.WriteLine(
                        string.Format(
                        "Account: {0} - Client: {1} - Period: 12 months with {2}% - Interest rate for the period: {3}%",
                        acc.GetType().Name, 
                        acc.CustomerType, 
                        acc.InterestRate,
                        acc.CalculateInterest(12)));
            }
        }
    }
}
