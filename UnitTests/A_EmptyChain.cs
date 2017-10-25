using Chain;
using NUnit.Framework;
using Should;
using UnitTests.SupportingItems;

namespace UnitTests
{
    [TestFixture]
    public class A_EmptyChain
    {
        [SetUp]
        public void SetUp()
        {
            Results.Reset();
        }

        [Test]
        public void Executing_an_empty_chain_should_not_throw_exception()
        {
            var emptyChain = new PlainChain<Message>(new ILink<Message>[0]);

            var message = new Message();

            Assert.DoesNotThrow(() => emptyChain.ExecuteAll(message));
        }

        [Test]
        public void Executing_am_empty_chain_should_not_result_anything()
        {
            var emptyChain = new PlainChain<Message>(new ILink<Message>[0]);

            var message = new Message();

            emptyChain.ExecuteAll(message);

            Results.Count.ShouldEqual(0);
        }

        [Test]
        public void Executing_an_emtpy_chain_should_run_closing_action()
        {
            var emptyChain = new PlainChain<Message>(new ILink<Message>[0]);

            emptyChain.SetClosingAction(m =>
            {
                Results.Add($"Closed: {m.Name}");
            });

            var message = new Message{Name = "SomeMessage"};

            emptyChain.ExecuteAll(message);

            Results.Count.ShouldEqual(1);
            Results.Index[0].ShouldEqual("Closed: SomeMessage");
        }
    }
}
