using Finance.Domain.VisitiorPatternApplied.Contracts;

namespace Finance.Domain.VisitiorPatternApplied.Implementations.Entities
{
    public class RealEstate : IAsset
    {
        public decimal EstimatedValue { get; set; }
        public decimal MonthlyRent { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}