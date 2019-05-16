using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
        //GET
        public ActionResult Index()
        {
            MathOperation op = new MathOperation();
            return View(op);//Injecting the Data into the View....
        }

        [HttpPost]
        public ActionResult Index(MathOperation postedData)
        {
            switch (postedData.Operand)
            {
                case "-":
                    postedData.ResultValue = postedData.FirstValue - postedData.SecondValue;
                    break;
                case "X":
                    postedData.ResultValue = postedData.FirstValue * postedData.SecondValue;
                    break;
                case "/":
                    postedData.ResultValue = postedData.FirstValue / postedData.SecondValue;
                    break;
                default:
                    postedData.ResultValue = postedData.FirstValue + postedData.SecondValue;
                    break;
            }            
            return View(postedData);
        }
    }
}