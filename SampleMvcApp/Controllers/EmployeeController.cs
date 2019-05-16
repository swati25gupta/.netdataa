using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            //Model is the list<EmpTable>
            var com = new EmpDataEntities();//The Auto Generated class for accessing data
            var data = com.EmpTables.ToList();//All the dta is converted to List<EmpTable>
            return View(data);
        }

        public ActionResult Edit(string id)
        {
            int empId = int.Parse(id);
            var com = new EmpDataEntities();
            var foundedEmp = com.EmpTables.FirstOrDefault(e => e.EmpID == empId);//    
            if (foundedEmp != null)
                return View(foundedEmp);
            else
                throw new Exception("No Employee found to edit");
        }

        [HttpPost]
        public ActionResult Edit(EmpTable postedEmp)
        {
            //get the Entity FM
            var com = new EmpDataEntities();
            //Find UR EMployee
            var emp = com.EmpTables.FirstOrDefault(e => e.EmpID == postedEmp.EmpID);
            if (emp == null) throw new Exception("Employee not found");
            //SEt the new details
            emp.EmpName = postedEmp.EmpName;
            emp.EmpAddress = postedEmp.EmpAddress;
            emp.EmpSalary = postedEmp.EmpSalary;
            com.SaveChanges();
            //update
            return RedirectToAction("Index");
        }
    }
}