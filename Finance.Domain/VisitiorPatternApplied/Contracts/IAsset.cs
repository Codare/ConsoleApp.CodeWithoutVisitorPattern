namespace Finance.Domain.VisitiorPatternApplied.Contracts
{
    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }
}
