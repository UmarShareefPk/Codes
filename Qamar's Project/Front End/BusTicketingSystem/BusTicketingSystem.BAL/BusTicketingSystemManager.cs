using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusTicketingSystem.DAL;
using BusTicketingSystem.CL;
using BusTicketingSystem.DAL.BusTicketingSystemDataSetTableAdapters;

namespace BusTicketingSystem.BAL
{
    public class BusTicketingSystemManager
    {
       public User GetUserDetail(string username , string password)
       {
           var user = new User();
           var userTa = new UsersTableAdapter();

           var userTable = userTa.GetUserInformation(username, password);

           if(userTable.Rows.Count == 0)
           {
               user.IsValidUser = false;
               return user;
           }

           user.IsValidUser = true;
           user.Id = userTable.Rows[0]["Id"].ToString();
           user.Username = userTable.Rows[0]["Username"].ToString();
           user.Password = userTable.Rows[0]["Password"].ToString();
           user.CreationDate = DateTime.Parse(userTable.Rows[0]["CreationDate"].ToString());
           user.LastLogin = DateTime.Parse(userTable.Rows[0]["LastLogin"].ToString());
           user.Role = GetRoleById(userTable.Rows[0]["Role_Id"].ToString());
           user.IsEmployee = userTable.Rows[0]["IsEmployee"] == null || userTable.Rows[0]["IsEmployee"].ToString() == "" ? false : bool.Parse(userTable.Rows[0]["IsEmployee"].ToString());
           user.EmployeementInformation = GetEmployeeById(userTable.Rows[0]["Employee_Id"].ToString());
           user.CustomerInformation = GetCustomerById(userTable.Rows[0]["Customer_Id"].ToString());
           
           return user;
       }


        public Employee GetEmployeeById (string id)
        {
            var employee = new Employee();
            var employeeTa = new EmployeesTableAdapter();

            if (string.IsNullOrEmpty(id))
                return null;
            
            var employeeTable = employeeTa.GetEmployeeById(int.Parse(id));

            if (employeeTable.Rows.Count == 0)
                return null;

            employee.Id = employeeTable.Rows[0]["Id"].ToString();
            employee.Name = employeeTable.Rows[0]["Name"].ToString();
            employee.Designation = employeeTable.Rows[0]["Designation"].ToString();
            employee.Phone = employeeTable.Rows[0]["Phone"].ToString();
            employee.Salary = float.Parse(employeeTable.Rows[0]["Salary"].ToString());
            employee.HireDate = DateTime.Parse(employeeTable.Rows[0]["HireDate"].ToString());
            employee.TerminalInformation = GetTerminalById(employeeTable.Rows[0]["Terminal_Id"].ToString());
            return employee;
        }

        public Terminal GetTerminalById( string id)
        {
            var terminalTa = new TerminalsTableAdapter();
            var terminal = new Terminal();

            if (string.IsNullOrEmpty(id))
                return null;

            var terminalTable = terminalTa.GetTerminalById(int.Parse(id));

            if (terminalTable.Rows.Count == 0)
                return null;

            terminal.Id = terminalTable.Rows[0]["Id"].ToString();
            terminal.Location = terminalTable.Rows[0]["Location"].ToString();
            terminal.City = terminalTable.Rows[0]["City"].ToString();
            terminal.Phone = terminalTable.Rows[0]["Phone"].ToString();

            return terminal;
        }


        public UserRole GetRoleById (string id)
        {
            var userRoleTa = new UserRolesTableAdapter();
            var role = new UserRole();

            if (string.IsNullOrEmpty(id))
                return null;

            var userRoleTable = userRoleTa.GetUserRoleById(int.Parse(id));

            if (userRoleTable.Rows.Count == 0)
                return null;

            role.Id = userRoleTable.Rows[0]["Id"].ToString();
            role.Name = userRoleTable.Rows[0]["Name"].ToString();

            return role;
        }

        public Customer GetCustomerById (string id)
        {
            var customerTa = new CustomersTableAdapter();
            var customer = new Customer();

            if (string.IsNullOrEmpty(id))
                return null;

            var customerTable = customerTa.GetCustomerById(int.Parse(id));

            if (customerTable.Rows.Count == 0)
                return null;

            customer.Id = customerTable.Rows[0]["Id"].ToString();
            customer.Name = customerTable.Rows[0]["Name"].ToString();
            customer.Phone = customerTable.Rows[0]["Phone"].ToString();
            customer.Email = customerTable.Rows[0]["Email"].ToString();
            customer.CustomerSince = DateTime.Parse(customerTable.Rows[0]["CustomerSince"].ToString());
            customer.CNIC = customerTable.Rows[0]["CNIC"].ToString();
            customer.Active = bool.Parse(customerTable.Rows[0]["Active"].ToString());
            return customer;
        }

    }// end class
}// end namespace
