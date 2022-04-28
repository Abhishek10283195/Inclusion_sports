using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inclusion_sports.Models;
using LinqToExcel;
using Newtonsoft.Json;


namespace Inclusion_sports.Controllers
{
    public class TrustHeterosController : Controller
    {
        private Epic3Entities1 db = new Epic3Entities1();

		private Epic3Entities3 db2 = new Epic3Entities3();

		// GET: TrustHeteros
		public ActionResult Index()
        {

            var myType = (from values in db.TrustHeteroes
                            select values.Type).ToArray();
            var Percentage = (from values in db.TrustHeteroes
                          select values.Percentage).ToArray();

            var myType2 = (from values in db.TrustHomoes
                           select values.Type).ToArray();
            var Percentage2 = (from values in db.TrustHomoes
                              select values.Percentage).ToArray();

			var y2010 = (from values in db2.TobaccoHeteroes
						 select values.Y2010).ToArray();
			var y2013 = (from values in db2.TobaccoHeteroes
						 select values.Y2013).ToArray();
			var y2016 = (from values in db2.TobaccoHeteroes
						 select values.Y2016).ToArray();
			var y2019 = (from values in db2.TobaccoHeteroes
						 select values.Y2019).ToArray();

            var yy2010 = (from values in db2.TobaccoHomoes
                         select values.Y2010).ToArray();
            var yy2013 = (from values in db2.TobaccoHomoes
                          select values.Y2013).ToArray();
            var yy2016 = (from values in db2.TobaccoHomoes
                          select values.Y2016).ToArray();
            var yy2019 = (from values in db2.TobaccoHomoes
                          select values.Y2019).ToArray();

            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();


            List<DataPoint> dataPoints4 = new List<DataPoint>();
            List<DataPoint> dataPoints5 = new List<DataPoint>();
            List<DataPoint> dataPoints6 = new List<DataPoint>();

            List<DataPoint> dataPoints7 = new List<DataPoint>();
            List<DataPoint> dataPoints8 = new List<DataPoint>();
            List<DataPoint> dataPoints9 = new List<DataPoint>();
            List<DataPoint> dataPoints10 = new List<DataPoint>();
            List<DataPoint> dataPoints11 = new List<DataPoint>();
            List<DataPoint> dataPoints12 = new List<DataPoint>();
            List<DataPoint> dataPoints13 = new List<DataPoint>();
            List<DataPoint> dataPoints14 = new List<DataPoint>();
            List<DataPoint> dataPoints15 = new List<DataPoint>();


            List<DataPoint> dataPoints16 = new List<DataPoint>();
            List<DataPoint> dataPoints17 = new List<DataPoint>();
            List<DataPoint> dataPoints18 = new List<DataPoint>();
            List<DataPoint> dataPoints19 = new List<DataPoint>();
            List<DataPoint> dataPoints20 = new List<DataPoint>();
            List<DataPoint> dataPoints21 = new List<DataPoint>();
            List<DataPoint> dataPoints22 = new List<DataPoint>();
            List<DataPoint> dataPoints23 = new List<DataPoint>();
            List<DataPoint> dataPoints24 = new List<DataPoint>();


            dataPoints1.Add(new DataPoint(myType[0], Percentage[0]));
            dataPoints1.Add(new DataPoint(myType[3], Percentage[3]));
            dataPoints1.Add(new DataPoint(myType[6], Percentage[6]));
            dataPoints1.Add(new DataPoint(myType[9], Percentage[9]));

            dataPoints2.Add(new DataPoint(myType[0], Percentage[1]));
            dataPoints2.Add(new DataPoint(myType[3], Percentage[4]));
            dataPoints2.Add(new DataPoint(myType[6], Percentage[7]));
            dataPoints2.Add(new DataPoint(myType[9], Percentage[10]));

            dataPoints3.Add(new DataPoint(myType[0], Percentage[2]));
            dataPoints3.Add(new DataPoint(myType[3], Percentage[5]));
            dataPoints3.Add(new DataPoint(myType[6], Percentage[8]));
            dataPoints3.Add(new DataPoint(myType[9], Percentage[11]));


            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
			ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
			ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);


            dataPoints4.Add(new DataPoint(myType2[0], Percentage2[0]));
            dataPoints4.Add(new DataPoint(myType2[3], Percentage2[3]));
            dataPoints4.Add(new DataPoint(myType2[6], Percentage2[6]));
            dataPoints4.Add(new DataPoint(myType2[9], Percentage2[9]));

            dataPoints5.Add(new DataPoint(myType2[0], Percentage2[1]));
            dataPoints5.Add(new DataPoint(myType2[3], Percentage2[4]));
            dataPoints5.Add(new DataPoint(myType2[6], Percentage2[7]));
            dataPoints5.Add(new DataPoint(myType2[9], Percentage2[10]));

            dataPoints6.Add(new DataPoint(myType2[0], Percentage2[2]));
            dataPoints6.Add(new DataPoint(myType2[3], Percentage2[5]));
            dataPoints6.Add(new DataPoint(myType2[6], Percentage2[8]));
            dataPoints6.Add(new DataPoint(myType2[9], Percentage2[11]));


            ViewBag.DataPoints4 = JsonConvert.SerializeObject(dataPoints4);
            ViewBag.DataPoints5 = JsonConvert.SerializeObject(dataPoints5);
            ViewBag.DataPoints6 = JsonConvert.SerializeObject(dataPoints6);


			dataPoints7.Add(new DataPoint("2010", y2010[0]));
            dataPoints8.Add(new DataPoint("2010", y2010[1]));
            dataPoints9.Add(new DataPoint("2010", y2010[2]));
            dataPoints10.Add(new DataPoint("2010", y2010[3]));
            dataPoints11.Add(new DataPoint("2010", y2010[4]));
            dataPoints12.Add(new DataPoint("2010", y2010[5]));
            dataPoints13.Add(new DataPoint("2010", y2010[6]));
            dataPoints14.Add(new DataPoint("2010", y2010[7]));
            dataPoints15.Add(new DataPoint("2010", y2010[8]));

            dataPoints7.Add(new DataPoint("2013", y2013[0]));
            dataPoints8.Add(new DataPoint("2013", y2013[1]));
            dataPoints9.Add(new DataPoint("2013", y2013[2]));
            dataPoints10.Add(new DataPoint("2013", y2013[3]));
            dataPoints11.Add(new DataPoint("2013", y2013[4]));
            dataPoints12.Add(new DataPoint("2013", y2013[5]));
            dataPoints13.Add(new DataPoint("2013", y2013[6]));
            dataPoints14.Add(new DataPoint("2013", y2013[7]));
            dataPoints15.Add(new DataPoint("2013", y2013[8]));

            dataPoints7.Add(new DataPoint("2016", y2016[0]));
            dataPoints8.Add(new DataPoint("2016", y2016[1]));
            dataPoints9.Add(new DataPoint("2016", y2016[2]));
            dataPoints10.Add(new DataPoint("2016", y2016[3]));
            dataPoints11.Add(new DataPoint("2016", y2016[4]));
            dataPoints12.Add(new DataPoint("2016", y2016[5]));
            dataPoints13.Add(new DataPoint("2016", y2016[6]));
            dataPoints14.Add(new DataPoint("2016", y2016[7]));
            dataPoints15.Add(new DataPoint("2016", y2016[8]));

            dataPoints7.Add(new DataPoint("2019", y2019[0]));
            dataPoints8.Add(new DataPoint("2019", y2019[1]));
            dataPoints9.Add(new DataPoint("2019", y2019[2]));
            dataPoints10.Add(new DataPoint("2019", y2019[3]));
            dataPoints11.Add(new DataPoint("2019", y2019[4]));
            dataPoints12.Add(new DataPoint("2019", y2019[5]));
            dataPoints13.Add(new DataPoint("2019", y2019[6]));
            dataPoints14.Add(new DataPoint("2019", y2019[7]));
            dataPoints15.Add(new DataPoint("2019", y2019[8]));

            ViewBag.DataPoints7 = JsonConvert.SerializeObject(dataPoints7);
            ViewBag.DataPoints8 = JsonConvert.SerializeObject(dataPoints8);
            ViewBag.DataPoints9 = JsonConvert.SerializeObject(dataPoints9);
            ViewBag.DataPoints10 = JsonConvert.SerializeObject(dataPoints10);
            ViewBag.DataPoints11 = JsonConvert.SerializeObject(dataPoints11);
            ViewBag.DataPoints12 = JsonConvert.SerializeObject(dataPoints12);
            ViewBag.DataPoints13 = JsonConvert.SerializeObject(dataPoints13);
            ViewBag.DataPoints14 = JsonConvert.SerializeObject(dataPoints14);
            ViewBag.DataPoints15 = JsonConvert.SerializeObject(dataPoints15);


            dataPoints16.Add(new DataPoint("2010", yy2010[0]));
            dataPoints17.Add(new DataPoint("2010", yy2010[1]));
            dataPoints18.Add(new DataPoint("2010", yy2010[2]));
            dataPoints19.Add(new DataPoint("2010", yy2010[3]));
            dataPoints20.Add(new DataPoint("2010", yy2010[4]));
            dataPoints21.Add(new DataPoint("2010", yy2010[5]));
            dataPoints22.Add(new DataPoint("2010", yy2010[6]));
            dataPoints23.Add(new DataPoint("2010", yy2010[7]));
            dataPoints24.Add(new DataPoint("2010", yy2010[8]));

            dataPoints16.Add(new DataPoint("2013", yy2013[0]));
            dataPoints17.Add(new DataPoint("2013", yy2013[1]));
            dataPoints18.Add(new DataPoint("2013", yy2013[2]));
            dataPoints19.Add(new DataPoint("2013", yy2013[3]));
            dataPoints20.Add(new DataPoint("2013", yy2013[4]));
            dataPoints21.Add(new DataPoint("2013", yy2013[5]));
            dataPoints22.Add(new DataPoint("2013", yy2013[6]));
            dataPoints23.Add(new DataPoint("2013", yy2013[7]));
            dataPoints24.Add(new DataPoint("2013", yy2013[8]));

            dataPoints16.Add(new DataPoint("2016", yy2016[0]));
            dataPoints17.Add(new DataPoint("2016", yy2016[1]));
            dataPoints18.Add(new DataPoint("2016", yy2016[2]));
            dataPoints19.Add(new DataPoint("2016", yy2016[3]));
            dataPoints20.Add(new DataPoint("2016", yy2016[4]));
            dataPoints21.Add(new DataPoint("2016", yy2016[5]));
            dataPoints22.Add(new DataPoint("2016", yy2016[6]));
            dataPoints23.Add(new DataPoint("2016", yy2016[7]));
            dataPoints24.Add(new DataPoint("2016", yy2016[8]));

            dataPoints16.Add(new DataPoint("2019", yy2019[0]));
            dataPoints17.Add(new DataPoint("2019", yy2019[1]));
            dataPoints18.Add(new DataPoint("2019", yy2019[2]));
            dataPoints19.Add(new DataPoint("2019", yy2019[3]));
            dataPoints20.Add(new DataPoint("2019", yy2019[4]));
            dataPoints21.Add(new DataPoint("2019", yy2019[5]));
            dataPoints22.Add(new DataPoint("2019", yy2019[6]));
            dataPoints23.Add(new DataPoint("2019", yy2019[7]));
            dataPoints24.Add(new DataPoint("2019", yy2019[8]));

            ViewBag.DataPoints16 = JsonConvert.SerializeObject(dataPoints16);
            ViewBag.DataPoints17 = JsonConvert.SerializeObject(dataPoints17);
            ViewBag.DataPoints18 = JsonConvert.SerializeObject(dataPoints18);
            ViewBag.DataPoints19 = JsonConvert.SerializeObject(dataPoints19);
            ViewBag.DataPoints20 = JsonConvert.SerializeObject(dataPoints20);
            ViewBag.DataPoints21 = JsonConvert.SerializeObject(dataPoints21);
            ViewBag.DataPoints22 = JsonConvert.SerializeObject(dataPoints22);
            ViewBag.DataPoints23= JsonConvert.SerializeObject(dataPoints23);
            ViewBag.DataPoints24 = JsonConvert.SerializeObject(dataPoints24);


            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }

            db2.tblFiles.Add(new tblFile
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            db2.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            tblFile file = db2.tblFiles.ToList().Find(p => p.Id == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }
    


    // GET: TrustHeteros/Details/5
    public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustHetero trustHetero = db.TrustHeteroes.Find(id);
            if (trustHetero == null)
            {
                return HttpNotFound();
            }
            return View(trustHetero);
        }

        // GET: TrustHeteros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrustHeteros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Degree,Percentage")] TrustHetero trustHetero)
        {
            if (ModelState.IsValid)
            {
                db.TrustHeteroes.Add(trustHetero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trustHetero);
        }

        // GET: TrustHeteros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustHetero trustHetero = db.TrustHeteroes.Find(id);
            if (trustHetero == null)
            {
                return HttpNotFound();
            }
            return View(trustHetero);
        }

        // POST: TrustHeteros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Degree,Percentage")] TrustHetero trustHetero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trustHetero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trustHetero);
        }

        // GET: TrustHeteros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrustHetero trustHetero = db.TrustHeteroes.Find(id);
            if (trustHetero == null)
            {
                return HttpNotFound();
            }
            return View(trustHetero);
        }

        // POST: TrustHeteros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrustHetero trustHetero = db.TrustHeteroes.Find(id);
            db.TrustHeteroes.Remove(trustHetero);
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
            string path = "~Uploads/Tobacco_heterosexsual.xlsx";
            return File(path, "application/vnd.ms-excel", "Tobacco_heterosexsual.xlsx");
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
                    var artistAlbums = from a in excelFile.Worksheet<TobaccoHetero>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                                TobaccoHetero TU = new TobaccoHetero();
                                TU.Item = a.Item;
                                TU.Y2010 = a.Y2010;
                                TU.Y2013 = a.Y2013;
                                TU.Y2016 = a.Y2016;
                                TU.Y2019 = a.Y2019;


                                db2.TobaccoHeteroes.Add(TU);
                                db2.SaveChanges();
                      
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
