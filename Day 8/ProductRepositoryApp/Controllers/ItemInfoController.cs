using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductRepositoryApp.Controllers
{
    public class ItemInfoController : Controller
    {
        // GET: ItemInfo
        public ActionResult Home()
        {
            return View();
        }

        public PartialViewResult AllItems()
        {
            IBusinessComponent com = new BusinessObject();
            //get the Model
            var model = com.GetItems();
            return PartialView(model);
        }

        public PartialViewResult AddItem()
        {
            var item = new Item();
            return PartialView(item);
        }
        [HttpPost]
        public ActionResult AddItem(Item postedData)
        {
            try
            {
                var com = new BusinessObject();
                com.AddNewItem(postedData);
                return RedirectToAction("Home");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PartialViewResult search(string searchItem)
        {
            try
            {
                var com = new BusinessObject();
                var searchedRecords = com.FindItems(searchItem);
                return PartialView("AllItems", searchedRecords);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}