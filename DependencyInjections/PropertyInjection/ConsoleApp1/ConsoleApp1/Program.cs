using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeBL = new EmployeeBL();
            employeeBL.employeeDataObject = new EmployeeDAL(); //property injection
            var ListEmployee = employeeBL.GetAllEmployees();
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
        private IEmployeeDAL employeeDAL;  //property using interface. 
        public IEmployeeDAL employeeDataObject
        {
            set  {  employeeDAL = value; }
            get
            {
                if (employeeDataObject == null)
                    throw new Exception("Employee is not initialized");
                
                return employeeDAL;
            }
        }
        public List<Employee> GetAllEmployees()
        {
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
