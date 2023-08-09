using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        string cs = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        [HttpGet]
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("APIStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Student_ID", "");
            cmd.Parameters.AddWithValue("@Student_Name", "");
            cmd.Parameters.AddWithValue("@Student_Class", "");
            cmd.Parameters.AddWithValue("@Student_Phone", "");
            cmd.Parameters.AddWithValue("@Student_Email", "");
            cmd.Parameters.AddWithValue("@Operation", 1);

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "No Records Found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
        }
        [HttpPost]
        public string Post(Student std)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("APIStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_ID", std.Student_ID);
                cmd.Parameters.AddWithValue("@Student_Name", std.Student_Name);
                cmd.Parameters.AddWithValue("@Student_Class", std.Student_Class);
                cmd.Parameters.AddWithValue("@Student_Phone", std.Student_Phone);
                cmd.Parameters.AddWithValue("@Student_Email", std.Student_Email);
                cmd.Parameters.AddWithValue("@Operation", 2);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();

                return "Student Data Insered Successfully";
            }
            catch (Exception)
            {
                return "Failed To Save Data";
            }
        }
        [HttpPut]
        public string Put(Student std)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("APIStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_ID", std.Student_ID);
                cmd.Parameters.AddWithValue("@Student_Name", std.Student_Name);
                cmd.Parameters.AddWithValue("@Student_Class", std.Student_Class);
                cmd.Parameters.AddWithValue("@Student_Phone", std.Student_Phone);
                cmd.Parameters.AddWithValue("@Student_Email", std.Student_Email);
                cmd.Parameters.AddWithValue("@Operation", 3);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();

                return "Student Data Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed To Update Student Data";
            }
        }

        [HttpDelete]
        public string Delete(Student std)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("APIStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_ID", std.Student_ID);
                cmd.Parameters.AddWithValue("@Student_Name", std.Student_Name);
                cmd.Parameters.AddWithValue("@Student_Class", std.Student_Class);
                cmd.Parameters.AddWithValue("@Student_Phone", std.Student_Phone);
                cmd.Parameters.AddWithValue("@Student_Email", std.Student_Email);
                cmd.Parameters.AddWithValue("@Operation", 4);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.Close();

                return "Student Data Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed To Delete Student Data";
            }
        }

        [Route("api/Student/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpreq = HttpContext.Current.Request;
                var PostFile = httpreq.Files[0];

                string filename = PostFile.FileName;
                var path = HttpContext.Current.Server.MapPath("~/Photos/" + filename);
                PostFile.SaveAs(path);

                return filename;
            }
            catch (Exception)
            {

                return "No File Found";
            }
        }
    }
}
