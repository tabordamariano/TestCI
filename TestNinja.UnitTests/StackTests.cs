using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {

        [Test]
        public void Stack_CheckStackEmpty_ReturnsZeroCount()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Stack_PushElement_ReturnsCountPlusOne()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();
            var initialCount = stack.Count;
            stack.Push("mariano");
            Assert.That(stack.Count, Is.EqualTo(initialCount+1));
        }

        [Test]
        public void Stack_PeekElement_ReturnsCountAndElement()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();            
            stack.Push("mariano");
            var Count = stack.Count;
            var element = stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(Count));
            Assert.That(element, Is.EqualTo("mariano"));

        }

        [Test]
        public void Stack_PopElement_ReturnsCountMinosOneAndElement()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();            
            stack.Push("mariano");
            stack.Push("valentina");
            var Count = stack.Count;
            var element = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(Count - 1));
            Assert.That(element, Is.EqualTo("valentina"));

        }

        [Test]
        public void Stack_PopElementWhenStackIsEmpty_ReturnsInvalidOperationException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();            

            Assert.That(stack.Pop, Throws.InvalidOperationException);

        }

        [Test]
        public void Stack_PeekElementWhenStackIsEmpty_ReturnsInvalidOperationException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();

            Assert.That(stack.Peek, Throws.InvalidOperationException);

        }

        [Test]
        public void Stack_PushNullElement_ReturnsArgumentNullException()
        {
            var stack = new TestNinja.Fundamentals.Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);

        }

    }
}
