using System.Collections.Generic;

namespace Finance.Domain.NoVisitorPatternApplied
{
    public class Person
    {
        public List<RealEstate> RealEstates = new List<RealEstate>();
        public List<BankAccount> BankAccounts = new List<BankAccount>();
        public List<Loan> Loans = new List<Loan>();
    }
}