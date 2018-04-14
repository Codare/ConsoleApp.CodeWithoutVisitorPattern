using System.Collections.Generic;
using Finance.Domain.VisitiorPatternApplied.Contracts;

namespace Finance.Domain.VisitiorPatternApplied.Implementations.Entities
{
    public class Person : IAsset
    {
        public List<IAsset> Assets = new List<IAsset>();

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
            {
                asset.Accept(visitor);
            }
        }
    }
}
