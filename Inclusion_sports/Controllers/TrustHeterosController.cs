using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
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

        // GET: TrustHeteros
        public ActionResult Index()
        {

            var myType = (from values in db.TrustHeteroes
                            select values.Type).ToArray();
            var Percentage = (from values in db.TrustHeteroes
                          select values.Percentage).ToArray();

            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();


            //string cs = ConfigurationManager.ConnectionStrings["Epic3Entities1"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //             string cmd = "Select Type, Percentage from TrustHetero";
            //	con.Open();
            //             DataTable dt = new DataTable();
            //             SqlDataAdapter rdr = new SqlDataAdapter(cmd, con);
            //             rdr.Fill(dt);
            //             con.Close();

            //             dataPoints1.Add(new DataPoint(Convert.ToDouble(dt.Rows[1][0]), dt.Rows[1][1]));

            //         }


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



            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(4).Type), Convert.ToDouble(db.TrustHeteroes.Find(4).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(4).Type), Convert.ToDouble(db.TrustHeteroes.Find(5).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(4).Type), Convert.ToDouble(db.TrustHeteroes.Find(6).Percentage)));

            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(7).Type), Convert.ToDouble(db.TrustHeteroes.Find(7).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(7).Type), Convert.ToDouble(db.TrustHeteroes.Find(8).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(7).Type), Convert.ToDouble(db.TrustHeteroes.Find(9).Percentage)));

            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(10).Type), Convert.ToDouble(db.TrustHeteroes.Find(10).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(10).Type), Convert.ToDouble(db.TrustHeteroes.Find(11).Percentage)));
            //dataPoints1.Add(new DataPoint(Convert.ToDouble(db.TrustHeteroes.Find(10).Type), Convert.ToDouble(db.TrustHeteroes.Find(12).Percentage)));

            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
			ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
			ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);

			return View();
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
            string path = "~Uploads/trust_heterosexual.xlsx";
            return File(path, "application/vnd.ms-excel", "trust_heterosexual.xlsx");
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
                    var artistAlbums = from a in excelFile.Worksheet<TrustHetero>(sheetName) select a;
                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                                TrustHetero TU = new TrustHetero();
                                TU.Degree = a.Degree;
                                TU.Percentage = a.Percentage;
                                TU.Type = a.Type;


                                db.TrustHeteroes.Add(TU);
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
