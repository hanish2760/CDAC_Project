using StudentManagementSystem_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if(string.IsNullOrEmpty(Session["user_id"].ToString()))
            {
                return RedirectToAction("Index", "Login");
            }
            if (int.Parse(Session["user_id"].ToString()) != id)
            {
                // invalid request... redirect to login page.
                return RedirectToAction("Index", "Login");
                
            }
            else
            {


                string apiURI = "http://localhost:52738/api/StudentDetails/";
                apiURI = apiURI + id.ToString();
                var client = new HttpClient();
                var response = client.GetAsync(apiURI);

                string op = "";
                StudentDetail student;
                if (response.Result.IsSuccessStatusCode)
                {
                    using (HttpContent cont = response.Result.Content)
                    {
                        Task<string> res = cont.ReadAsStringAsync();
                        op = res.Result;


                        //User user=JsonConvert.DeserializeObject<User>
                        JavaScriptSerializer js = new JavaScriptSerializer();

                        student = js.Deserialize<StudentDetail>(op);

                    }
                    Session["roll_no"] = student.Roll_Number;

                    return View(student);
                }
                else
                {
                    return View();
                    // student record not found.....
                }
                }
        }

        // GET: StudentDetail/Create
        public ActionResult Create()
        {
            return View();
        }
        //ViewMarks
        public ActionResult ViewMarks()
        {
            StudentMarks marks = new StudentMarks();
            //api/Curriculum_Table/5
            //return RedirectToAction("Details", "StudentMarksDetails", new { id =int.Parse(Session["user_id"].ToString() )});

            if (string.IsNullOrEmpty(Session["user_id"].ToString()))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {


                string apiURI = "http://localhost:52738/api/Curriculum_Table/";
                apiURI = apiURI + Session["user_id"].ToString();
                var client = new HttpClient();
                var response = client.GetAsync(apiURI);

                string op = "";
                if (response.Result.IsSuccessStatusCode)
                {
                    using (HttpContent cont = response.Result.Content)
                    {
                        Task<string> res = cont.ReadAsStringAsync();
                        op = res.Result;


                        //User user=JsonConvert.DeserializeObject<User>
                        JavaScriptSerializer js = new JavaScriptSerializer();

                        marks = js.Deserialize<StudentMarks>(op);

                    }
                    marks.Average = (marks.Subject1 + marks.Subject2 + marks.Subject3) / 3;


                    return PartialView("ViewMarks", marks);
                }
                else
                {
                    return View();
                    // the view to show  that marks for this student doesnt exist.
                }
            }
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

            if (string.IsNullOrEmpty(Session["user_id"].ToString()) || Session["user_id"].ToString() == null || Session["user_id"].ToString().Length == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            if (int.Parse(Session["user_id"].ToString()) != id)
            {
                // invalid request... redirect to login page.
                return RedirectToAction("Index", "Login");

            }
            else
            {


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
        //Logout
        public ActionResult Logout()
        {
            Session["role"] = "";
            Session["user_id"] = "";
            Session["mail_id"] = "";
            return RedirectToAction("Index", "Login");


        }
        //SaveDeatils
        [HttpPost]       public ActionResult SaveDetails(StudentDetail stud, JsonResult json)
        {


            // api / StudentDetails
            if (string.IsNullOrEmpty(Session["user_id"].ToString()) || Session["user_id"].ToString() == null || Session["user_id"].ToString().Length == 0)
            {
                return RedirectToAction("Index", "Login");
            }
           
            string apiURI = "http://localhost:52738/api/StudentDetails/";
            apiURI = apiURI + Session["user_id"].ToString();
            var client = new HttpClient();
            stud.Userid = int.Parse(Session["user_id"].ToString());
            stud.Roll_Number =(Session["roll_no"].ToString());
            var jsonStudvalues = new Dictionary<string, string>()
            {
                {"BloodGrp" ,stud.BloodGrp},
                { "DateOfJoining",stud.DateOfJoining},
                {"Dob",stud.Dob },
                {"Domain",stud.Domain },
                {"FatherDesignation",stud.FatherDesignation },
                {"FatherName",stud.FatherName },
                {"FatherPhNum",stud.FatherPhNum },
                {"Mailid",stud.Mailid },
                {"MotherDesignation",stud.MotherDesignation },
                {"MotherPhNum",stud.MotherPhNum },
                {"MotherName",stud.MotherName },
                {"Phno",stud.Phno },
                {"Roll_Number",stud.Roll_Number },
                {"SAddress",stud.SAddress },
                {"Sname",stud.Sname },
                {"Syear",stud.Syear.ToString() },
                {"UPassword",stud.UPassword },
                {"Userid",stud.Userid.ToString() }



            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonUser = js.Serialize(stud);
            var content = new FormUrlEncodedContent(jsonStudvalues);
            var response = client.PutAsync(apiURI, content);

           


            if (response.Result.IsSuccessStatusCode)
                return RedirectToAction("Details",new { id = Session["user_id"] });
            else
            {
                return View();
                // student could not update details.... 
            }
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
