using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    using NUnit.Framework;

    [TestFixture]
    class LinkedListTest
    {
        /**
         * Default constructor for test class LinkedListTest
         */
        public LinkedListTest() { }

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
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(linkedList, Is.Not.Null);
            Assert.That(linkedList.GetSize(), Is.EqualTo(0));
        }

        /**
        * Test the Add method to ensure it returns true
        */
        [Test]
        public void TestAdd()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp = new Employee(1);

            Assert.That(linkedList.Add(emp), Is.True);
        }

        /**
        * Test the Add method to ensure it returns it creates the head property
        */
        [Test]
        public void TestAddHead()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp = new Employee(1);

            linkedList.Add(emp);
            Assert.That(linkedList.Get(), Is.EqualTo(emp));
        }

        /**
         * test the Clear method to ensure it clears the linked list
         */
        [Test]
        public void TestClear()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp = new Employee(1);
            linkedList.Add(emp);

            linkedList.Clear();
            Assert.That(linkedList.GetSize(), Is.EqualTo(0));
        }

        /**
         * test the get method to see if any data is returned
         */
        [Test]
        public void TestGetSuccess()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp = new Employee(1);
            linkedList.Add(emp);

            Employee employeeData = linkedList.Get();
            Assert.That(emp, Is.EqualTo(employeeData));

        }

        /**
         *  Test to see if exception is thrown when linked list has size of 0
         */
        [Test]
        public void TestGet_Throw_Exception_On_Empty_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(() => linkedList.Get(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test the size when linked list has 0 nodes
         */
        [Test]
        public void TestGetSize0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(linkedList.GetSize(), Is.EqualTo(0));
        }

        /**
         * Method to test the size when linked list has multiple nodes
         */
        [Test]
        public void TestGetSizeGreaterThan0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.GetSize(), Is.EqualTo(2));
        }

        /**
         * Boolean method to test when linked list is empty
         */
        [Test]
        public void TestIsEmptyTrue()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(linkedList.IsEmpty(), Is.True);
        }

        /**
         * Boolean method to test when linked list is not empty
         */
        [Test]
        public void TestIsEmptyFalse()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.IsEmpty(), Is.False);
        }

        /**
         * Method to test when linked list removes the head item and that the data returned is that of the head item
         */
        [Test]
        public void TestRemoveSuccess()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Employee oldData = linkedList.Remove();
            Assert.That(emp2, Is.EqualTo(oldData));
        }

        /**
         * Method to test when linked list removes the head item and that the data returned is that of the head item
         */
        [Test]
        public void TestRemove_Throw_Exception_On_Empty_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(() => linkedList.Remove(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test when linked list sets the head item and that the data returned is that of the head item
         */
        [Test]
        public void TestSetSuccess()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);

            Employee oldData = linkedList.Set(emp2);
            Assert.That(emp2, Is.EqualTo(linkedList.Get()));
            Assert.That(emp1, Is.EqualTo(oldData));
        }

        /**
         * Method to test when linked list sets the head item but linked list doesn't have any nodes and throws an exception
         */
        [Test]
        public void TestSet_Throw_Exception_On_Empty_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(() => linkedList.Remove(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test if the GetFirst method returns the head of the linked list
         */
        [Test]
        public void TestGetFirst()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp2));
        }

        /**
         * Method to test if the GetLast method throws an exception when linked list is empty
         */
        [Test]
        public void TestGetLast_Throws_Exception_When_Empty()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(() => linkedList.GetLast(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test if the GetLast method returns the tail of the linked list
         */
        [Test]
        public void TestGetLast_When_List_Greater_Than_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.GetLast(), Is.EqualTo(emp1));
        }

        /**
         * Method to test that the AddFirst method add's to the head of the linked list
         */
        [Test]
        public void TestAddFirst()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.AddFirst(emp2);

            Assert.That(linkedList.Get(), Is.EqualTo(emp2));
        }

        /**
         * Method to test the AddLast method when the size of the linked list is 0
         */
        [Test]
        public void TestAddLast_Size_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);

            linkedList.AddLast(emp1);

            Assert.That(linkedList.Get(), Is.EqualTo(emp1));
        }

        /**
         * Method to test if the AddLast method adds to the tail of the linked list when the linked list size is greater than 0
         */
        [Test]
        public void TestAddLast_Size_Greater_Than_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            linkedList.AddLast(emp3);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test RemoveFirst method and that the head of the linked list is properly set
         */
        [Test]
        public void TestRemoveFirst_Head_Replaced()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            linkedList.RemoveFirst();
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp1));
        }

        /**
         * Method to test RemoveFirst method and that the proper data is returned
         */
        [Test]
        public void TestRemoveFirst_Proper_Data_Returned()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.RemoveFirst(), Is.EqualTo(emp2));
        }

        /**
         * Method to test RemoveLast method when tail is null
         */
        [Test]
        public void TestRemoveLast_Throws_Exception_When_Tail_Null()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();

            Assert.That(() => linkedList.RemoveLast(), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test RemoveLast method properly replaces tail
         */
        [Test]
        public void TestRemoveLast_Tail_Properly_Replaced()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp1);
            linkedList.Add(emp2);
            linkedList.Add(emp3);

            linkedList.RemoveLast();
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp2));
        }

        /**
         * Method to test RemoveLast method that the proper data is returned
         */
        [Test]
        public void TestRemoveLast_Proper_Data_Returned()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp1);
            linkedList.Add(emp2);
            linkedList.Add(emp3);

            Assert.That(linkedList.RemoveLast(), Is.EqualTo(emp1));
        }

        /**
         * Method to test Get position method throws exception when position not valid
         */
        [Test]
        public void TestGetPosition_Throws_Exception_On_Invalid_Position()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);

            linkedList.Add(emp1);
            Assert.That(() => linkedList.Get(2), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test Get position method returns correct data
         */
        [Test]
        public void TestGetPosition_Returns_Correct_Data()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp1);
            linkedList.Add(emp2);

            Assert.That(linkedList.Get(2), Is.EqualTo(emp1));
        }

        /**
         * Method to test InsertData method when linked list size is 0
         */
        [Test]
        public void TestInsertData_Linked_List_Size_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);

            linkedList.InsertData(emp1);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp1));
        }

        /**
         * Method that tests InsertData method when the data that's being inserted in less than the data in the list when compared
         */
        [Test]
        public void TestInsertData_Current_Data_Less_Than_Whats_In_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.Add(emp2);

            linkedList.InsertData(emp1);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp1));
        }

        /**
         * Method to test InsertData properly inserts data in the right places when compared
         */
        [Test]
        public void TestInsertData_Current_Data_Inserted_Middle_Of_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp3);
            linkedList.Add(emp1);

            linkedList.InsertData(emp2);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp2));
        }

        /**
         * Method to test InsertData and that the private Link method works correctly
         */
        [Test]
        public void TestInsertData_Link_Method_Works_Correctly()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp3);
            linkedList.Add(emp1);

            linkedList.InsertData(emp2);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test InsertData properly inserts data in tail position when compared
         */
        [Test]
        public void TestInsertData_LinkTail_When_Data_Is_At_The_End()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp2);
            linkedList.Add(emp1);

            linkedList.InsertData(emp3);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test AddAfter properly adds data to tail when position is equal to size
         */
        [Test]
        public void TestAddAfter_Position_Equals_Size()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp2);
            linkedList.Add(emp1);

            linkedList.AddAfter(emp3, 2);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test AddAfter correctly adds data in the middle of the list
         */
        [Test]
        public void TestAddAfter_Position_In_Middle_Of_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp3);
            linkedList.Add(emp1);

            linkedList.AddAfter(emp2, 1);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp2));
        }

        /**
         * Method to test AddBefore properly adds data to the head when position is equal to 1
         */
        [Test]
        public void TestAddBefore_Position_Equals_1()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp3);
            linkedList.Add(emp2);

            linkedList.AddBefore(emp1, 1);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp1));
        }

        /**
         * Method to test AddBefore correctly adds data in the middle of the list
         */
        [Test]
        public void TestAddBefore_Position_In_Middle_Of_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp3);
            linkedList.Add(emp1);

            linkedList.AddBefore(emp2, 2);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp2));
        }

        /**
         * Method to test Set properly replaces data to tail when position is equal to size
         */
        [Test]
        public void TestSet_Position_Equals_Size()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.Add(emp2);
            linkedList.Add(emp1);

            linkedList.Set(emp3, 2);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test Set correctly replaces data in the middle of the list
         */
        [Test]
        public void TestSet_Position_In_Middle_Of_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);

            linkedList.Set(emp4, 2);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp4));
        }

        /**
         * Method to test Set correctly returns the proper data
         */
        [Test]
        public void TestSet_Return_Correct_Data()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);

            Assert.That(linkedList.Set(emp4, 2), Is.EqualTo(emp2));
        }

        /**
         * Method to test Remove position correctly removes and replaces the head when position is 1
         */
        [Test]
        public void TestRemove_Position_Equals_1()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);

            linkedList.Remove(1);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp2));
        }

        /**
         * Method to test Remove position correctly removes and replaces the tail when position is equal to the size
         */
        [Test]
        public void TestRemove_Position_Equals_Size()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);

            linkedList.Remove(3);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp2));
        }

        /**
         * Method to test Remove position correctly removes the proper node in the middle of the list
         */
        [Test]
        public void TestRemove_Position_Middle_Of_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);
            linkedList.InsertData(emp4);

            linkedList.Remove(2);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp3));
        }

        /**
         * Method to test Remove position correctly returns the data of the node removed
         */
        [Test]
        public void TestRemove_Position_Returns_Correct_Data()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);
            linkedList.InsertData(emp4);

            Assert.That(linkedList.Remove(2), Is.EqualTo(emp2));
        }

        /**
         * Method to test AddAfter throws an exception when node is null
         */
        [Test]
        public void TestAddAfter_Throw_Exception_When_Null()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);

            Assert.That(() => linkedList.AddAfter(emp3, emp4), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test AddAfter when the old data is the tail node
         */
        [Test]
        public void TestAddAfter_Node_Is_Tail()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);

            linkedList.AddAfter(emp3, emp2);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }

        /**
         * Method to test AddAfter when the node is in the middle of the list
         */
        [Test]
        public void TestAddAfter_Node_Is_In_The_Middle_Of_The_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp4);

            linkedList.AddAfter(emp3, emp2);
            Assert.That(linkedList.Get(3), Is.EqualTo(emp3));
        }

        /**
         * Method to test AddBefore throws an exception when node is null
         */
        [Test]
        public void TestAddBefore_Throw_Exception_When_Null()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);

            Assert.That(() => linkedList.AddBefore(emp3, emp4), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test AddBefore when the old data is the head node
         */
        [Test]
        public void TestAddBefore_Node_Is_Head()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp2);
            linkedList.InsertData(emp3);

            linkedList.AddBefore(emp1, emp2);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp1));
        }

        /**
         * Method to test AddBefore when the node is in the middle of the list
         */
        [Test]
        public void TestAddBefore_Node_Is_In_The_Middle_Of_The_List()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);
            linkedList.InsertData(emp4);

            linkedList.AddBefore(emp3, emp4);
            Assert.That(linkedList.Get(3), Is.EqualTo(emp3));
        }

        /**
         * Method to test Get data throws exception when node is null
         */
        [Test]
        public void TestGetData_Throws_Exception_When_Node_Is_Null()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.InsertData(emp1);

            Assert.That(() => linkedList.Get(emp2), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test the Get data returns the proper data
         */
        [Test]
        public void TestGetData_Returns_Proper_Data()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);

            Assert.That(linkedList.Get(emp1), Is.EqualTo(emp1));
        }

        /**
         * Method to test Set data throws exception when node is null
         */
        [Test]
        public void TestSet_Data_OldData_Throws_Exception_When_Node_Is_Null()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp1);

            Assert.That(() => linkedList.Set(emp2, emp3), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test Set when old data is in the middle of the list
         */
        [Test]
        public void TestSet_Data_OldData_Replaces_Node()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp3);
            linkedList.InsertData(emp4);

            linkedList.Set(emp2, emp3);
            Assert.That(linkedList.Get(2), Is.EqualTo(emp2));
        }

        /**
         * Method to test Set that it returns the proper data
         */
        [Test]
        public void TestSet_Data_OldData_Returns_Correct_Data()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);
            Employee emp4 = new Employee(4);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp3);
            linkedList.InsertData(emp4);

            Assert.That(linkedList.Set(emp2, emp3), Is.EqualTo(emp3));
        }

        /**
         * Method to test SetFirst throws an exception when the list size is 0
         */
        [Test]
        public void TestSetFirst_Throws_Exception_When_Size_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);

            Assert.That(() => linkedList.SetFirst(emp1), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test SetFirst works correctly
         */
        [Test]
        public void TestSetFirst_Success()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);

            linkedList.InsertData(emp1);

            linkedList.SetFirst(emp2);
            Assert.That(linkedList.GetFirst(), Is.EqualTo(emp2));
        }

        /**
         * Method to test SetLast throws an exception when the list size is 0
         */
        [Test]
        public void TestSetLast_Throws_Exception_When_Size_0()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);

            Assert.That(() => linkedList.SetLast(emp1), Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        /**
         * Method to test SetLast works correctly
         */
        [Test]
        public void TestSetLast_Success()
        {
            LinkedList<Employee> linkedList = new LinkedList<Employee>();
            Employee emp1 = new Employee(1);
            Employee emp2 = new Employee(2);
            Employee emp3 = new Employee(3);

            linkedList.InsertData(emp1);
            linkedList.InsertData(emp2);

            linkedList.SetLast(emp3);
            Assert.That(linkedList.GetLast(), Is.EqualTo(emp3));
        }
    }
}
