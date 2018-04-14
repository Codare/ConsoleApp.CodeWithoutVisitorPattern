using Finance.Domain.VisitiorPatternApplied.Implementations.Entities;

namespace Finance.Domain.VisitiorPatternApplied.Contracts
{
    public interface IVisitor
    {
        void Visit(RealEstate realEstate);
        void Visit(BankAccount bankAccount);
        void Visit(Loan loan);
    }
}
