using Chain;
using NUnit.Framework;
using Should;
using UnitTests.SupportingItems;

namespace UnitTests
{
    [TestFixture]
    public class B_SimpleChain
    {
        [SetUp]
        public void SetUp()
        {
            Results.Reset();
        }

        [Test]
        public void When_single_node_added_should_add_to_the_results_correctly()
        {
            var message = new Message { Name = "M1" };

            var c = new PlainChain<Message>(new ILink<Message>[]
            {
                new L1(),
            });

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(1);

            Results.Index[0].ShouldEqual("L1: M1");
        }

        [Test]
        public void When_two_node_added_should_add_to_the_results_correctly()
        {
            var message = new Message { Name = "M1" };

            var c = new PlainChain<Message>(new ILink<Message>[]
            {
                new L1(),
                new L2(),
            });

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L1: M1");
            Results.Index[1].ShouldEqual("L2: M1");
        }
    }
}
