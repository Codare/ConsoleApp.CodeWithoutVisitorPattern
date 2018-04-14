using Finance.Domain.VisitiorPatternApplied.Contracts;

namespace Finance.Domain.VisitiorPatternApplied.Implementations.Entities
{
    public class Loan : IAsset
    {
        public decimal Owed { get; set; }
        public decimal MonthlyPayment { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}