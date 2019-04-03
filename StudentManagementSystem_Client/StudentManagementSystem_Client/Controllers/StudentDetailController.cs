using StudentManagementSystem_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentManagementSystem_Client.Controllers
{
    public class StudentDetailController : Controller
    {
        // GET: StudentDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentDetail/Details/1900
        public ActionResult Details(int id)
        {
            //StudentDetail student = new StudentDetail();

            string apiURI = "http://localhost:52738/api/StudentDetails/";
            apiURI = apiURI + id.ToString();
            var client = new HttpClient();
            var response = client.GetAsync(apiURI);

            string op = "";
            StudentDetail student;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;


                //User user=JsonConvert.DeserializeObject<User>
                JavaScriptSerializer js = new JavaScriptSerializer();

                student = js.Deserialize<StudentDetail>(op);

            }
                return View(student);
        }

        // GET: StudentDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentDetail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentDetail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
