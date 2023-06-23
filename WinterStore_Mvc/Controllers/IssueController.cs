using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WinterStore_Mvc.Models;

namespace WinterStore_Mvc.Controllers
{
    public class IssueController : Controller
    {
        Issue issueObj = new Issue();
        // GET: Issue
        public ActionResult Index()
        {
            issueObj = new Issue();
            List<Issue> issue = issueObj.getData();
            return View(issue);
        }
        public ActionResult AddContactus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContactUs(Issue issue)
        {
            bool res;
            //if (ModelState.IsValid)
            //{
            issueObj = new Issue();

            res = issueObj.Insert(issue);
            if (res)
            {
                TempData["msg"] = "Added successfully";
            }
            //}
            else
            {
                TempData["msg"] = "Not Added. something went wrong..!!";
            }
            return View("Index");
        }

    }
}