using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Employee_Management_System.Models;

namespace Employee_Management_System.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

        dbOperations dbOperations = null;
        public EmployeeController()
        {
            dbOperations = new dbOperations();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        public ActionResult EditEmployee(int id)
        {
            EmployeeModel employee=dbOperations.EditEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel employee)
        {
            bool isUpdated= dbOperations.UpdateEmployee(employee);
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            int id= dbOperations.AddEployee(employee);
            ModelState.Clear();
            ViewBag.condition = true;
            return View();
        }
        [HttpPost]
        public ActionResult SearchEmployee(string search)
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();
            employee = dbOperations.searchEployee(search);
            return View("Employees",employee);
        }
        public ActionResult DeleteEmployee(int id)
        {
            bool isDeleted=dbOperations.DeleteEployee(id);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            List<EmployeeModel> employee = new List<EmployeeModel>();
            employee = dbOperations.getEmployees();
            return View("Employees",employee);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Users");
        }
    }
}