using StudentManagementSystem_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
namespace StudentManagementSystem_Client.Controllers
{
    
    public class FacultyController : Controller
    {
        // GET: Faculty
        public static List<StudentDetailsForFaculty> students = new List<StudentDetailsForFaculty>();
        // null error handling......
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {

            //api/StudentDetails

            students.Clear();
            if (Session["user_id"] != null && string.IsNullOrEmpty(Session["user_id"].ToString()))
            {
                return RedirectToAction("Index", "Login");
            }
            if (int.Parse(Session["role"].ToString()) != 2)
            {
                // Not a faculty.... 
                Session["role"] = "";
                Session["user_id"] = "";
                Session["mail_id"] = "";
                return RedirectToAction("Index", "Login");

            }
            else
            {


                string apiURI = "http://localhost:52738/api/MarksAndDetails";
                /// new rest call for both student details and marks.
                var client = new HttpClient();
                var response = client.GetAsync(apiURI);
                response.Wait();
                // string op = "";
                if (response.Result.IsSuccessStatusCode)
                {
                    var readTask = response.Result.Content.ReadAsAsync<IList<StudentDetailsForFaculty>>();
                    var studsDetails = readTask.Result;
                    //var studsMarks =;
                    foreach (var item in studsDetails)
                    {

                        students.Add(new StudentDetailsForFaculty
                        {

                            Attendance = item.Attendance,
                            BloodGrp = item.BloodGrp,
                            DateOfJoining = item.DateOfJoining,
                            Dob = item.Dob,
                            Domain = item.Domain,
                            FatherDesignation = item.FatherDesignation,
                            Average = (item.Subject3 + item.Subject2 + item.Subject1) / 3,
                            FatherName = item.FatherName,
                            FatherPhNum = item.FatherPhNum,
                            Mailid = item.Mailid,
                            MotherDesignation = item.MotherDesignation,
                            MotherName = item.MotherName,
                            MotherPhNum = item.MotherPhNum,
                            Phno = item.Phno,
                            Roll_Number = item.Roll_Number,
                            SAddress = item.SAddress,
                            Sname = item.Sname,
                            Subject1 = item.Subject1,
                            Subject2 = item.Subject2,
                            Subject3 = item.Subject3,
                            Syear = item.Syear,
                            UPassword = item.UPassword,
                            Userid = item.Userid

                        });

                    }

                    //students = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDetail>(readTask.Result);
                    //students = JsonConvert.DeserializeObject<StudentDetailsForFaculty>(op);
                    // return PartialView("ViewMarks", marks);

                    return View(students);

                }
                else
                {
                    return View();
                    // the view to show  that marks for this student doesnt exist.
                }
            
            }




           // students.Add(new StudentDetailsForFaculty { roll_no = , student_name = });

  
        }
        public ActionResult EditStudentMarks(StudentDetailsForFaculty stud)
        {

            // Create Action .
            
            return View(stud);
        }

        //SaveEdittedDetails
        [HttpPost]
        public ActionResult SaveEdittedDetails(StudentDetailsForFaculty stud, JsonResult json)
        {

          
            float Average = (stud.Subject1 + stud.Subject2+stud.Subject3)/3;
            
            //api/Curriculum_Table
            string apiURI = "http://localhost:52738/api/Curriculum_Table";
            var client = new HttpClient();
            var values = new Dictionary<string, string>()
            {
                {"Subject1",stud.Subject1.ToString()},
                {"Subject2",stud.Subject2.ToString() },
                {"Subject3",stud.Subject3.ToString()},
                {"Average",Average.ToString()},
                {"Attendance",stud.Attendance.ToString()}
            };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(apiURI, content);
            
            if (response.Result.IsSuccessStatusCode)
            {

              return  RedirectToAction("Details");
                
            }
            //if fails show error msg
                return View();
        }
            
    }
}

