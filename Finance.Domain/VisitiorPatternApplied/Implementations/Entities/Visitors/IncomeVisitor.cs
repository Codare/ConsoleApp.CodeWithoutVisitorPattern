using Finance.Domain.VisitiorPatternApplied.Contracts;

namespace Finance.Domain.VisitiorPatternApplied.Implementations.Entities.Visitors
{
    public class IncomeVisitor : IVisitor
    {
        public decimal Amount;

        public void Visit(RealEstate realEstate)
        {
            Amount += realEstate.MonthlyRent;
        }

        public void Visit(BankAccount bankAccount)
        {
            Amount += bankAccount.Amount * bankAccount.MonthlyInterest;
        }

        public void Visit(Loan loan)
        {
            Amount -= loan.MonthlyPayment;
        }
    }
}
