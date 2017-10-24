using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    using NUnit.Framework;

    [TestFixture]
    class EmployeeTest
    {
        /**
         * Default constructor for test class EmployeeTest
         */
        public EmployeeTest() { }

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
         * Test the id arg constructor, make sure the data is there and other properties are null
         */
        [Test]
        public void TestIdArgContructor()
        {
            Employee emp1 = new Employee(1);

            Assert.That(emp1, Is.Not.Null);
            Assert.That(emp1.GetEmployeeId(), Is.EqualTo(1));
            Assert.That(emp1.GetFirstName(), Is.Null);
            Assert.That(emp1.GetLastName(), Is.Null);
        }

        /**
         * Test the all arg constructor, make sure the proerties are set
         */
        [Test]
        public void TestAllArgContructor()
        {
            Employee emp1 = new Employee(1, "Tom", "Smith");

            Assert.That(emp1, Is.Not.Null);
            Assert.That(emp1.GetEmployeeId(), Is.EqualTo(1));
            Assert.That(emp1.GetFirstName(), Is.EqualTo("Tom"));
            Assert.That(emp1.GetLastName(), Is.EqualTo("Smith"));
        }

        /**
         * Test the GetEmployeeId method to determine if the proper id is returned
         */
        [Test]
        public void TestGetEmployeeId()
        {
            Employee emp1 = new Employee(1);

            Assert.That(emp1.GetEmployeeId(), Is.EqualTo(1));
        }

        /**
         * Test the GetFirstName method to determine if the proper name is returned
         */
        [Test]
        public void TestGetFirstName()
        {
            Employee emp1 = new Employee(1, "Tom", "Smith");

            Assert.That(emp1.GetFirstName(), Is.EqualTo("Tom"));
        }

        /**
         * Test the GetLastName method to determine if the proper name is returned
         */
        [Test]
        public void TestGetLastName()
        {
            Employee emp1 = new Employee(1, "Tom", "Smith");

            Assert.That(emp1.GetLastName(), Is.EqualTo("Smith"));
        }

        /**
         * Test the ToString method to determine if the proper string is returned
         */
        [Test]
        public void TestToString()
        {
            Employee emp1 = new Employee(1, "Tom", "Smith");

            Assert.That(emp1.ToString(), Is.EqualTo("1 Tom Smith"));
        }

        /**
         * Test the CompareTo method to determine if the proper int is returned when first emp id is less than second
         */
        [Test]
        public void TestCompareToLess()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            Assert.That(emp1.CompareTo(emp2), Is.EqualTo(-1));
        }

        /**
         * Test the CompareTo method to determine if the proper int is returned when second emp id is more than the first
         */
        [Test]
        public void TestCompareToMore()
        {
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            Assert.That(emp2.CompareTo(emp1), Is.EqualTo(1));
        }

        /**
         * Test the CompareTo method to determine if the proper int is returned when first emp id is compared to itself
         */
        [Test]
        public void TestCompareToEqual()
        {
            Employee emp1 = new Employee(1);

            Assert.That(emp1.CompareTo(emp1), Is.EqualTo(0));
        }
    }
}
