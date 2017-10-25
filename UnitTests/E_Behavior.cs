﻿using Chain;
using NUnit.Framework;
using Should;
using UnitTests.SupportingItems;

namespace UnitTests
{
    [TestFixture]
    public class E_Behavior
    {
        [SetUp]
        public void SetUp()
        {
            Results.Reset();
        }

        [Test]
        public void L3_should_stop_propagation()
        {
            var message = new Message { Name = "M1" };

            var c = new PlainChain<Message>(new ILink<Message>[]
            {
                new L3(),
                new L1(),
            });

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(1);

            Results.Index[0].ShouldEqual("L3: M1");
        }

        [Test]
        public void L3_should_not_stop_execution()
        {
            var message = new Message { Name = "M1" };

            var c = new PlainChain<Message>(new ILink<Message>[]
            {
                new L3(),
                new L1(),
            });

            c.SetClosingAction(m =>
            {
                Results.Add("ClosingMessage");
            });

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(2);

            Results.Index[0].ShouldEqual("L3: M1");
            Results.Index[1].ShouldEqual("ClosingMessage");
        }

        [Test]
        public void L4_should_stop_execution()
        {
            var message = new Message { Name = "M1" };

            var c = new PlainChain<Message>(new ILink<Message>[]
            {
                new L4(),
                new L1(),
            });

            c.SetClosingAction(m =>
            {
                Results.Add("ClosingMessage");
            });

            c.ExecuteAll(message);

            Results.Count.ShouldEqual(1);

            Results.Index[0].ShouldEqual("L4: M1");
        }
    }
}
