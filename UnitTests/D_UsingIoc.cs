using Chain;
using NUnit.Framework;
using Should;
using StructureMap;
using UnitTests.SupportingItems;

namespace UnitTests
{
    [TestFixture]
    public class D_UsingIoc
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
            Results.Reset();

            _container = new Container(_ =>
                _.For<IChain<Message>>()
                    .Use(CreateChain()).Singleton()
            );
        }

        private static IChain<Message> CreateChain()
        {
            var x = new EmptyChain<Message>();
            x.AddLink<L1>();
            x.AddLink<L2>();
            return x;
        }

        [Test]
        public void An_ioc_made_chain_should_respect_to_the_links()
        {
            var message = new Message {Name = "M1"};

            var c = _container.GetInstance<IChain<Message>>();

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L1: M1");
            Results.Index[1].ShouldEqual("L2: M1");
        }
    }
}
