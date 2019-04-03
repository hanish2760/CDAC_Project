using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class User
    {
        public string mail_id
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public int role
        {
            get;
            set;
        }
        public int userid
        {
            get;
            set;
        }
        public bool isLoggedin(User user)
        {

            // Db Procedure.
           
            return true;
            
        }
    }
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }
        
      //  POST: api/Login
       [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {

            bool check = false;
            string connString = @"Data Source=DESKTOP-F5HHJ41;Initial Catalog=StudentManagementSystem;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string procedure = "Check_Credentials";
            SqlCommand cmd = new SqlCommand(procedure, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter paras = new SqlParameter("@mail_id", System.Data.SqlDbType.VarChar);
            SqlParameter paras2 = new SqlParameter("@password", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add(paras).Value = user.mail_id;
            cmd.Parameters.Add(paras2).Value = user.password;
            //cmd.ExecuteNonQuery();


            int f = 0;
            SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                f = f + 1;
                user.role = int.Parse(dr.GetValue(3).ToString());
                user.userid = int.Parse(dr.GetValue(0).ToString());
            }

            con.Close();
            if (f == 0)
                check= false;
            else
                check= true;
               
            if (check)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

            //return Request.CreateResponse(HttpStatusCode.OK, user);
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, user);
            }
        }
        // POST: api/Student
        //public IEnumerable<string> Post([FromBody]string value)
        //{
        //    return new string[] { "from", " post" };
        //}

        // PUT: api/Login/5
        public void  Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
