using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTestingSamples.Repositories;
using MvcTestingSamples.Models;

namespace MvcTestingSamples.Controllers
{
    public class SampleController : Controller
    {
        public ISampleRepository Repository { get; private set; }

        public SampleController(ISampleRepository repository)
        {
            Repository = repository;
        }

        //
        // GET: /Sample/

        public ActionResult Index()
        {
            return View(Repository.GetSomethings());
        }

        //
        // GET: /Sample/Details/5

        public ActionResult Details(int id)
        {
            return View(Repository.GetSomething(id));
        }

        //
        // POST: /Sample/Create

        [HttpPost]
        public ActionResult Create(Something value)
        {
            try
            {
                Repository.InsertSomething(value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Sample/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Something value)
        {
            try
            {
                Repository.UpdateSomething(value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Sample/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Something value)
        {
            try
            {
                Repository.DeleteSomething(value);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
