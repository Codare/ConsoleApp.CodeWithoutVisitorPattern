using System;
using Finance.Domain.NoVisitorPatternApplied;
using Finance.Domain.VisitiorPatternApplied.Implementations.Entities.Visitors;
using visitorPatternEntities = Finance.Domain.VisitiorPatternApplied.Implementations.Entities;

namespace ConsoleApp.CodeWithoutVisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatePersonsNetWorthWithoutTheVisitorPattern();

            CalculatePersonsNetWorthWithTheVisitorPattern();

            Console.ReadLine();
        }

        private static void CalculatePersonsNetWorthWithTheVisitorPattern()
        {
            var person = new visitorPatternEntities.Person();
            person.Assets.Add(new visitorPatternEntities.BankAccount {Amount = 1000, MonthlyInterest = 0.01m});
            person.Assets.Add(new visitorPatternEntities.BankAccount {Amount = 2000, MonthlyInterest = 0.02m});
            person.Assets.Add(new visitorPatternEntities.RealEstate {EstimatedValue = 79000, MonthlyRent = 500m});
            person.Assets.Add(new visitorPatternEntities.Loan {Owed = 40000, MonthlyPayment = 40});


            //the logic is encapsulated into one place and the operations of now and in the future can be stored in one place.
            //they are not scattered amongst the classes of now [BankAccount, Loan, RealEstate].  
            //In the future if new classes came on board and they need to contribute to the networth calculation. They would simple need to implement the IAsset interface.
            var netWorthVisitor = new NetWorthVisitor();
            var incomeVisitor = new IncomeVisitor();

            person.Accept(netWorthVisitor);
            person.Accept(incomeVisitor);

            Console.WriteLine($"netWorthVisitor.Total {netWorthVisitor.Total}");
            Console.WriteLine($"incomeVisitor.Amount {incomeVisitor.Amount}");
        }

        private static void CalculatePersonsNetWorthWithoutTheVisitorPattern()
        {
            Console.WriteLine("Code without the benefit of the visitor pattern!");

            var person = new Person();
            person.BankAccounts.Add(new BankAccount {Amount = 1000, MonthlyInterest = 0.01m});
            person.BankAccounts.Add(new BankAccount {Amount = 2000, MonthlyInterest = 0.02m});
            person.RealEstates.Add(new RealEstate {EstimatedValue = 79000, MonthlyRent = 500m});
            person.Loans.Add(new Loan {Owed = 40000, MonthlyPayment = 40});

            //The reason that the visitor pattern is an improvement is because this client code below is extracted away and allows the calculations to change.
            //Have the code afford us the ability to calculate the netWorth by a mechanism of the visitor pattern.
            //We don't want the logic to be below and we also dont want the logic to be part of the class and the reason why.
            //This allows us to seperate the operation from the data structure.

            decimal netWorth = 0;
            foreach (var bankAccount in person.BankAccounts)
            {
                netWorth += bankAccount.Amount;
            }

            foreach (var realEstate in person.RealEstates)
            {
                netWorth += realEstate.EstimatedValue;
            }

            foreach (var loan in person.Loans)
            {
                netWorth -= loan.Owed;
            }

            Console.WriteLine(netWorth);
        }
    }
}
