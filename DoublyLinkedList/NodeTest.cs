using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    using NUnit.Framework;

    [TestFixture]
    class NodeTest
    {
        /**
         * Default constructor for test class NodeTest
         */
        public NodeTest() { }

        /**
         * Sets up the test fixture.
         *
         * Called before every test case method.
         */
        [SetUp]
        public void SetUp() { }

        /**
         * Tears down the test fixture.
         *
         * Called after every test case method.
         */
        [TearDown]
        public void TearDown() { }

        /**
        * Test the NoArg constructor, first to make sure it is there and that is sets properties properly.
        */
        [Test]
        public void TestNoArgConstructor()
        {
            Node<Employee> node1 = new Node<Employee>();

            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.GetData, Is.Null);
            Assert.That(node1.GetNext, Is.Null);
            Assert.That(node1.GetPrevious, Is.Null);
        }

        /**
         * Test the data arg constructor, make sure the data is there and other properties are null
         */
        [Test]
        public void TestDataArgContructor()
        {
            Employee emp1 = new Employee(1);
            Node<Employee> node1 = new Node<Employee>(emp1);

            Assert.That(node1, Is.Not.Null);
            Assert.That(node1.GetData(), Is.EqualTo(emp1));
            Assert.That(node1.GetNext(), Is.Null);
            Assert.That(node1.GetPrevious(), Is.Null);
        }

        /**
         * Test the all arg constructor, make sure the data is there and other properties are set
         */
        [Test]
        public void TestAllArgContructor()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Node<Employee> node1 = new Node<Employee>(emp1);
            Node<Employee> node2 = new Node<Employee>(emp2);
            Node<Employee> testNode = new Node<Employee>(emp3, node1, node2);

            Assert.That(testNode, Is.Not.Null);
            Assert.That(testNode.GetData(), Is.EqualTo(emp3));
            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
            Assert.That(testNode.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the GetData method to determine if the proper data is returned
         */
        [Test]
        public void TestGetData()
        {
            Employee emp1 = new Employee(1);
            Node<Employee> node1 = new Node<Employee>(emp1);

            Assert.That(node1.GetData(), Is.EqualTo(emp1));
        }

        /**
         * Test the SetData method to determine if the proper data is added to the node
         */
        [Test]
        public void TestSetData()
        {
            Employee emp1 = new Employee(1);
            Node<Employee> node1 = new Node<Employee>();

            node1.SetData(emp1);
            Assert.That(node1.GetData(), Is.EqualTo(emp1));
        }

        /**
         * Test the GetPrevious method to determine if the proper data is returned
         */
        [Test]
        public void TestGetPrevious()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Node<Employee> node1 = new Node<Employee>(emp1);
            Node<Employee> node2 = new Node<Employee>(emp2, node1, null);

            Assert.That(node2.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the SetPrevious method to determine if the proper data is added to the node
         */
        [Test]
        public void TestSetPrevious()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Node<Employee> node1 = new Node<Employee>(emp1);
            Node<Employee> node2 = new Node<Employee>(emp2);

            node2.SetPrevious(node1);
            Assert.That(node2.GetPrevious(), Is.EqualTo(node1));
        }

        /**
         * Test the GetNext method to determine if the proper data is returned
         */
        [Test]
        public void TestGetNext()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Node<Employee> node1 = new Node<Employee>(emp1);
            Node<Employee> node2 = new Node<Employee>(emp2);
            Node<Employee> testNode = new Node<Employee>(emp3, node1, node2);

            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
        }

        /**
         * Test the SetNext method to determine if the proper data is returned
         */
        [Test]
        public void TestSetNext()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Node<Employee> node1 = new Node<Employee>(emp1);
            Node<Employee> node2 = new Node<Employee>(emp2);
            Node<Employee> testNode = new Node<Employee>(emp3, node1, null);

            testNode.SetNext(node2);
            Assert.That(testNode.GetNext(), Is.EqualTo(node2));
        }
    }
}
