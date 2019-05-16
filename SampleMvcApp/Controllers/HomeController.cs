using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
//A Controller in MVC is a class that implements an interface called IController. Alternatively it can be derived from a class called ControllerBase or Controller. ControllerBase is an abstract class and Controller is a concrete class...
//Controller contains Methods what we call it as Actions in MVC.  Actions are the methods created to handle individual requests made by the HTTP. 
//Controller is responsible for processing the HTTP Requests and return a HTTP Response to that request. HTTP is Text based Technology. 
namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Welcome()
        {
            return "Hello MVC App!!!!";
        }

        public Employee CEODetails()
        {
            return new Employee
            {
                EmpId = 1,
                EmpAddress = "Bangalore",
                EmpName = "Ashok Soota",
                EmpSalary = 540000
            };
        }

        public ViewResult OurCEO()
        {
            //create the Model that U want to display//
            var emp = new Employee
            {
                EmpId = 1,
                EmpAddress = "Bangalore",
                EmpName = "Ashok Soota",
                EmpSalary = 540000
            };
            //View is a built in method of the Controller class that returns the Default View associated with the action...
            return View(emp);
        }
    }
}