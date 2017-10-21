using NUnit.Framework;
using Should;
using UnitTests.SupportingItems;

namespace UnitTests
{
    [TestFixture]
    public class C_CustomChainClasses
    {
        [SetUp]
        public void SetUp()
        {
            Results.Reset();
        }

        [Test]
        public void A_custom_made_chain_should_respect_to_the_links()
        {
            var message = new Message {Name = "M1"};

            var c = new L1L2Chain();

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L1: M1");
            Results.Index[1].ShouldEqual("L2: M1");
        }
    }
}
