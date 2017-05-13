using NUnit.Framework;

namespace System.Monads.Tests
{
    [TestFixture]
    public class ActionsTests
    {
        internal class ActionMock
        {
            public event Action TestAction;

            public void InvokeAction()
            {
                TestAction.Execute();
            }
        }

        internal class ActionTMock<T>
        {
            public event Action<T> TestAction;

            public void InvokeAction(T arg)
            {
                TestAction.Execute(arg);
            }
        }

        [Test]
        public void ExecuteNotGenericWithNull()
        {
            var eventMock = new ActionMock();
            eventMock.InvokeAction();
        }

        [Test]
        public void ExecuteNotGenericWithNotNull()
        {
            bool executed = false;

            var eventMock = new ActionMock();
            eventMock.TestAction += () => executed = true;

            eventMock.InvokeAction();

            Assert.IsTrue(executed);
        }

        [Test]
        public void ExecuteGenericWithNull()
        {
            var eventMock = new ActionTMock<string>();
            eventMock.InvokeAction("Test");
        }

        [Test]
        public void ExecuteGenericWithNotNull()
        {
            var executed = false;

            var eventMock = new ActionTMock<string>();
            eventMock.TestAction += arg => executed = arg == "Test";

            eventMock.InvokeAction("Test");

            Assert.IsTrue(executed);
        }
    }
}