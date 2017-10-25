using Chain;

namespace UnitTests.SupportingItems
{
    public class L1L2Chain : PlainChain<Message>
    {
        public L1L2Chain() : base(
            new ILink<Message>[]
            {
                new L1(),
                new L2(),
            })
        {}
    }
}
