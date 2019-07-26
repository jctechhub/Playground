using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeBL = new EmployeeBL();
            var ListEmployee = employeeBL.GetAllEmployees(new EmployeeDAL());  //inject the actual type into the method. 
            foreach (var emp in ListEmployee) { Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department); }
            Console.Read();
        }
    }
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            var ListEmployees = new List<Employee>();
            ListEmployees.Add(new Employee { ID = 1, Name = "Pranaya", Department = "IT" });
            ListEmployees.Add(new Employee { ID = 2, Name = "Kumar", Department = "HR" });
            ListEmployees.Add(new Employee { ID = 3, Name = "Rout", Department = "Payroll" });
            return ListEmployees;
        }
    }
    public class EmployeeBL
    {
        private IEmployeeDAL employeeDAL;  //holding object for injected value
        public List<Employee> GetAllEmployees(IEmployeeDAL _employeeDal)  //this is the setup for method injection. 
        {
            employeeDAL = _employeeDal;
            return employeeDAL.SelectAllEmployees();
        }
    }
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }



    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}
