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
        private IContainer _container; // a chain of responsibility
        private IContainer _sequenceControlledContainer56;
        private IContainer _sequenceControlledContainer65;

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

            _sequenceControlledContainer56 = new Container(_ =>
                {
                    _.Scan(s =>
                    {
                        s.TheCallingAssembly();
                        s.AddAllTypesOf<ILinkMarker>();
                    });

                    _.For<ILinkMarker>().Add<L5>();
                    _.For<ILinkMarker>().Add<L6>();
                    
                    _.For<IChain<Message>>()
                        .Use<L5L6Chain>()
                        .Singleton();
                }
            );

            _sequenceControlledContainer65 = new Container(_ =>
                {
                    _.Scan(s =>
                    {
                        s.TheCallingAssembly();
                        s.AddAllTypesOf<ILinkMarker>();
                    });

                    _.For<ILinkMarker>().Add<L6>();
                    _.For<ILinkMarker>().Add<L5>();
                    
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

            Results.Index.ShouldContain("L5: M1");
            Results.Index.ShouldContain("L6: M1");
        }

        [Test]
        public void An_ioc_made_chain_should_should_make_the_5_6_sequence()
        {
            var message = new Message {Name = "M1"};

            var c = _sequenceControlledContainer56.GetInstance<IChain<Message>>();

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L5: M1");
            Results.Index[1].ShouldEqual("L6: M1");
        }

        [Test]
        public void An_ioc_made_chain_should_should_make_the_6_5_sequence()
        {
            var message = new Message {Name = "M1"};

            var c = _sequenceControlledContainer65.GetInstance<IChain<Message>>();

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L6: M1");
            Results.Index[1].ShouldEqual("L5: M1");
        }
    }
}
