using NUnit.Framework;

namespace System.Monads.Tests
{
    [TestFixture]
    public class EventsTests
    {
        internal class EventMock
        {
            public void InvokeEvent()
            {
                TestEvent.Execute(this, EventArgs.Empty);
            }

            public event EventHandler TestEvent;
        }

        internal class EventMock<TArgs>
            where TArgs : EventArgs
        {
            public void InvokeEvent(TArgs arg)
            {
                TestEvent.Execute(this, arg);
            }

            public event EventHandler<TArgs> TestEvent;
        }

        public class EventArgsMock : EventArgs
        {
            public string Message { get; private set; }

            public EventArgsMock(string message)
            {
                Message = message;
            }
        }

        [Test]
        public void ExecuteNotGenericWithNull()
        {
            var eventMock = new EventMock();
            eventMock.InvokeEvent();
        }

        [Test]
        public void ExecuteNotGenericWithNotNull()
        {
            bool executed = false;

            var eventMock = new EventMock();
            eventMock.TestEvent += (s, e) => { executed = true; };

            eventMock.InvokeEvent();

            Assert.IsTrue(executed);
        }

        [Test]
        public void ExecuteGenericWithNull()
        {
            var eventMock = new EventMock<EventArgsMock>();
            eventMock.InvokeEvent(new EventArgsMock("Test"));
        }

        [Test]
        public void ExecuteGenericWithNotNull()
        {
            bool executed = false;

            var eventMock = new EventMock<EventArgsMock>();
            eventMock.TestEvent += (s, e) => { executed = e.Message == "Test"; };

            eventMock.InvokeEvent(new EventArgsMock("Test"));

            Assert.IsTrue(executed);
        }
    }
}