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
                {
                    _.Scan(s =>
                    {
                        s.TheCallingAssembly();
                        s.AddAllTypesOf<ILinkMarker>();
                    });

                    _.For<IChain<Message>>()
                        .Use<L5L6Chain>()
                        .Singleton();
                }
            );
        }

        [Test]
        public void An_ioc_made_chain_should_respect_to_the_links()
        {
            var message = new Message {Name = "M1"};

            var c = _container.GetInstance<IChain<Message>>();

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L5: M1");
            Results.Index[1].ShouldEqual("L6: M1");
        }
    }
}
