using System.Collections.Generic;
using System.Web.Mvc;
using System.Net.Http;
using StudentManagementSystem_Client.Models;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StudentManagementSystem_Client.Controllers
{
    public class UserController : Controller
    {
 

        [HttpPost]
        public string Login1(User l, JsonResult json)
        {
            string apiURI = "http://localhost:52738/api/Login";
            var client = new HttpClient();
            var values = new Dictionary<string, string>()
            {
                {"mail_id",l.mail_id },
                {"password",l.password },
               

            };

            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(apiURI, content);
            string op = "";
            User userNew;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;

            
                //User user=JsonConvert.DeserializeObject<User>
                JavaScriptSerializer js = new JavaScriptSerializer();
         
                userNew = js.Deserialize<User>(op);
                
            }
            if (response.Result.IsSuccessStatusCode)
            {
                // session create .
                Session["role"] = userNew.role;

                if (userNew.role == 1)
                {
                    // admin

                }else if (userNew.role == 2)
                {
                    // faculty
                }
                else if (userNew.role == 3)
                {
                    //student

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "server error.plase contact adminstrator");
                    return "failed";
                }
                return "success";
            }
            else
            {
                ModelState.AddModelError(string.Empty, "server error.plase contact adminstrator");
                return "failed";
            }


        }
    }
}