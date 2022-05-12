using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inclusion_sports.Models;
using LinqToExcel;

namespace Inclusion_sports.Controllers
{
    public class CaloriesController : Controller
    {
        private CalorieEntities2 db = new CalorieEntities2();
		public JsonResult GetSportNames(string term)

		{

			List<string> SportNames = db.Calories.Where(s => s.SportName.StartsWith(term))

				.Select(x => x.SportName).Distinct().ToList();

			return Json(SportNames, JsonRequestBehavior.AllowGet);
		}

        public JsonResult GetDegree(string term)

        {

            List<string> SDegree = db.Calories.Where(s => s.Degree.StartsWith(term))

                .Select(x => x.Degree).Distinct().ToList();

            return Json(SDegree, JsonRequestBehavior.AllowGet);
        }

        // GET: Calories
        public ActionResult Index()
        {
            return View(db.Calories.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string sportType = form["sportstype"];
            string degree = form["degree"];
            var weight = form["weight"];
            var decWeight = Convert.ToDecimal(weight);
            var duration = form["duration"];
            var decDuration = Convert.ToDecimal(duration);
            var coeff = db.Calories.Where(p => p.SportName == sportType && p.Degree == " " + degree).Select(p => p.Coef).FirstOrDefault();
            var intercept = db.Calories.Where(p => p.SportName == sportType && p.Degree == " " + degree).Select(p => p.Intercept).FirstOrDefault();

            var calories = decDuration * ((coeff * decWeight) + intercept);
            ViewBag.Message = calories;
            return View();
        }


        // GET: Calories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calorie calorie = db.Calories.Find(id);
            if (calorie == null)
            {
                return HttpNotFound();
            }
            return View(calorie);
        }

        // GET: Calories/Create
        public ActionResult Create()
        {
            ViewBag.Data = new SelectList(db.Calories, "Id", "SportName");
            return View();
        }

        // POST: Calories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SportName,Degree,Coef,Intercept,W130lb,W155lb,W180lb,W205lb")] Calorie calorie)
        {
            if (ModelState.IsValid)
            {
                db.Calories.Add(calorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calorie);
        }

        // GET: Calories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calorie calorie = db.Calories.Find(id);
            if (calorie == null)
            {
                return HttpNotFound();
            }
            return View(calorie);
        }

        // POST: Calories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SportName,Degree,Coef,Intercept,W130lb,W155lb,W180lb,W205lb")] Calorie calorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calorie);
        }

        // GET: Calories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calorie calorie = db.Calories.Find(id);
            if (calorie == null)
            {
                return HttpNotFound();
            }
            return View(calorie);
        }

        // POST: Calories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calorie calorie = db.Calories.Find(id);
            db.Calories.Remove(calorie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public FileResult DownloadExcel()
        {
            string path = "~Uploads/linear_models.xlsx";
            return File(path, "application/vnd.ms-excel", "linear_models.xlsx");
        }
        [HttpPost]
        public JsonResult UploadExcel(Event users, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    string sheetName = "Sheet1";
                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<Calorie>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            Calorie TU = new Calorie();
                            TU.SportName = a.SportName;
                            TU.Coef = a.Coef;
                            TU.Degree = a.Degree;
                            TU.Intercept = a.Intercept;
                            TU.W130lb = a.W130lb;
                            TU.W155lb = a.W155lb;
                            TU.W180lb = a.W180lb;
                            TU.W205lb = a.W205lb;

                            db.Calories.Add(TU);
                            db.SaveChanges();

                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {
                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                                }
                            }
                        }
                    }
                    //deleting excel file from folder
                    if ((System.IO.File.Exists(pathToExcelFile)))
                    {
                        System.IO.File.Delete(pathToExcelFile);
                    }
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
