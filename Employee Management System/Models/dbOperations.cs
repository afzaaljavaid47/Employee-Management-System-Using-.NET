using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class dbOperations
    {
        public int AddUser(UserModel user)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                User userModel = new User()
                {
                    username = user.username,
                    email = user.email,
                    password= user.password,
                    gender= user.gender
                };
                dbContext.Users.Add(userModel);
                dbContext.SaveChanges();
                return userModel.id;
            }
        }
        public int AddEployee(EmployeeModel employee)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                Employee employeeModel = new Employee()
                {
                    name = employee.name,
                    gender = employee.gender,
                    email = employee.email,
                    address = employee.address,
                    phonenumber = employee.phonenumber,
                    zipcode = employee.zipcode,
                    state = employee.state,
                    userID = (int)HttpContext.Current.Session["UserId"]
                };
                dbContext.Employees.Add(employeeModel);
                dbContext.SaveChanges();
                return employeeModel.id;
            }
        }
        public bool DeleteEployee(int id)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                Employee employeeModel = new Employee()
                {
                    id=id
                };
                dbContext.Entry(employeeModel).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
                return true;
            }
        }
        public List<EmployeeModel> searchEployee(string search)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                int userId = (int)HttpContext.Current.Session["UserId"];
                List<Employee> employees = dbContext.Employees.Where(x => x.userID == userId && x.name.Contains(search)).ToList();
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                foreach (Employee employee in employees)
                {
                    EmployeeModel employeeModel = new EmployeeModel
                    {
                        id = employee.id,
                        name = employee.name,
                        gender = employee.gender,
                        email = employee.email,
                        address = employee.address,
                        phonenumber = employee.phonenumber,
                        zipcode = employee.zipcode,
                        state = employee.state,
                        userID = employee.userID
                    };
                    employeeModels.Add(employeeModel);
                }
                return employeeModels;
            }
        }

        public EmployeeModel EditEmployee(int id)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                Employee employee = dbContext.Employees.Where(x=>x.id==id).ToList().FirstOrDefault();
                EmployeeModel employeeModel = new EmployeeModel()
                {
                    id = employee.id,
                    name = employee.name,
                    gender = employee.gender,
                    email = employee.email,
                    address = employee.address,
                    phonenumber = employee.phonenumber,
                    zipcode = employee.zipcode,
                    state = employee.state,
                    userID = employee.userID
                };     
                return employeeModel;
            }
        }
        public bool UpdateEmployee(EmployeeModel employee)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                Employee employeeModel = new Employee()
                {
                    id = employee.id,
                    name = employee.name,
                    gender = employee.gender,
                    email = employee.email,
                    address = employee.address,
                    phonenumber = employee.phonenumber,
                    zipcode = employee.zipcode,
                    state = employee.state,
                    userID = employee.userID
                };
                dbContext.Entry(employeeModel).State=System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
        }

        public List<EmployeeModel> getEmployees()
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
                int userId = (int)HttpContext.Current.Session["UserId"];
                List<Employee> employees = dbContext.Employees.Where(x=>x.userID== userId).ToList();
                List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                foreach (Employee employee in employees)
                {
                    EmployeeModel employeeModel = new EmployeeModel
                    {
                        id= employee.id,
                        name = employee.name,
                        gender = employee.gender,
                        email = employee.email,
                        address = employee.address,
                        phonenumber = employee.phonenumber,
                        zipcode = employee.zipcode,
                        state = employee.state,
                        userID=employee.userID
                    };
                    employeeModels.Add(employeeModel);
                }
                return employeeModels;
            }
        }
        public int validateUser(UserModel user)
        {
            using (EMSEntities dbContext = new EMSEntities())
            {
               var findUser = dbContext.Users.Where(x => x.username == user.username && x.password == user.password).ToList().FirstOrDefault();
               if(findUser.id>0)
                {
                    return findUser.id;
                }
               return 0;
            }
        }
    }
}