using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagementSystem.Controllers
{
    public class MarksAndDetailsController : ApiController
    {
        // GET: api/MarksAndDetails
        public HttpResponseMessage Get()
        {
            List<MarksAndDetailsModel> studs=new List<MarksAndDetailsModel>() ;



            
            string connString = @"Data Source=DESKTOP-F5HHJ41;Initial Catalog=StudentManagementSystem;Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string procedure = "getDetailsAndMarks";
            SqlCommand cmd = new SqlCommand(procedure, con);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            /*
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(procedure, con);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.Fill(dataSet);
            var listOfstuds=new List<>
            */
            int f = 0;
            SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            // Use Data aDapter insteadd of SqlDAtaREader

            while (dr.Read())
            {
                f = f + 1;
                studs.Add(

                    new MarksAndDetailsModel
                    {
                        Userid = int.Parse(dr.GetValue(0).ToString()),
                        UPassword = dr.GetValue(1).ToString(),
                        Sname = dr.GetValue(2).ToString(),
                        Phno = dr.GetValue(3).ToString(),
                        SAddress = dr.GetValue(4).ToString(),
                        Mailid = dr.GetValue(5).ToString(),
                        FatherName = dr.GetValue(6).ToString(),
                        FatherDesignation = dr.GetValue(7).ToString(),
                        FatherPhNum = dr.GetValue(8).ToString(),
                        MotherName = dr.GetValue(9).ToString(),
                        MotherDesignation = dr.GetValue(10).ToString(),
                        MotherPhNum = dr.GetValue(11).ToString(),
                        Dob = dr.GetValue(12).ToString(),
                        BloodGrp = dr.GetValue(13).ToString(),
                        DateOfJoining = dr.GetValue(14).ToString(),
                        Domain = dr.GetValue(15).ToString(),
                        Syear = int.Parse(dr.GetValue(16).ToString()),
                        Roll_Number = dr.GetValue(17).ToString(),
                        Subject1 = int.Parse(dr.GetValue(20).ToString()),
                        Subject2= int.Parse(dr.GetValue(21).ToString()),
                        Subject3= int.Parse(dr.GetValue(22).ToString()),
                        Attendance= int.Parse(dr.GetValue(23).ToString())
                        

                    }

                    );
            }

            con.Close();



            if(f==1)
            return Request.CreateResponse(HttpStatusCode.OK,studs );
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, studs);
            }
        }

        // GET: api/MarksAndDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MarksAndDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MarksAndDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MarksAndDetails/5
        public void Delete(int id)
        {
        }
    }
}
