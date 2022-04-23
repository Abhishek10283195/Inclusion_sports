using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Inclusion_sports.Models;

namespace Inclusion_sports.Controllers
{
    public class ReportingController : Controller
    {
        ReportingEntities context;
        public ReportingController()
        {
            context = new ReportingEntities();
        }

        // GET: Reporting
        public ActionResult Index()
        {
            return View(context.Reportings.ToList());
        }

        public ActionResult Create()
        {
            Reporting model = new Reporting();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Reporting model)
        {
            if (ModelState.IsValid)
            {
              context.Reportings.Add(new Reporting() { Answer = model.Answer, Email = model.Email, Name = model.Name });
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}