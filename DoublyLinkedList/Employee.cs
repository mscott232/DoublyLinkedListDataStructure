using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Employee : IComparable<Employee>
    {
        private int employeeId;
        private string firstName;
        private string lastName;

        /// <summary>
        /// Id arg employee constructor
        /// </summary>
        /// <param name="EmployeeId">The employees Id number</param>
        public Employee(int employeeId)
        {
            this.employeeId = employeeId;
        }

        /// <summary>
        /// All arg employee constructor
        /// </summary>
        /// <param name="EmployeeId">The employees Id number</param>
        /// <param name="FirstName">The employees first name</param>
        /// <param name="LastName">The employees last name</param>
        public Employee(int employeeId, string firstName, string lastName)
        {
            this.employeeId = employeeId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Returns the employees Id property
        /// </summary>
        /// <returns>The employee id</returns>
        public int GetEmployeeId()
        {
            return employeeId;
        }

        /// <summary>
        /// Returns the employees first name property
        /// </summary>
        /// <returns>The employees first name</returns>
        public string GetFirstName()
        {
            return firstName;
        }

        /// <summary>
        /// Returns the employees last name property
        /// </summary>
        /// <returns>The employees last name</returns>
        public string GetLastName()
        {
            return lastName;
        }

        /// <summary>
        /// Overrides the ToString method for an employee
        /// </summary>
        /// <returns>The employee string</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", employeeId, firstName, lastName);
        }

        /// <summary>
        /// Returns an int based on a comparison between this employee and another
        /// </summary>
        /// <param name="other">The employee to be compared to</param>
        /// <returns>-1 if other is greater, 0 if equal, 1 if this is greater</returns>
        public int CompareTo(Employee other)
        {
            return this.employeeId.CompareTo(other.GetEmployeeId());
        }
    }
}
