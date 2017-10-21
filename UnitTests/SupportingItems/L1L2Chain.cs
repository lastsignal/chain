using Chain;

namespace UnitTests.SupportingItems
{
    public class L1L2Chain : EmptyChain<Message>
    {
        public L1L2Chain()
        {
            AddLink<L1>();
            AddLink<L2>();
        }
    }
}
