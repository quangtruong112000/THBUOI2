using _5951071114_TranQuangTruong_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _5951071114_TranQuangTruong_Nhom3.Controllers
{
    [EnableCors(origins:"http://mywebclient.azurewebsites.net", headers:"*", methods:"*")]
    public class StudentController : ApiController
    {
        private SqlConnection con;
        private SqlDataAdapter adapter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            con = new SqlConnection("Data Source=LAPTOP-8MK2IUGC;Initial Catalog=Nawab;User ID=sa; password=123456");
            DataTable dt = new DataTable();
            var query = "select * from Student";
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow studentRecord in dt.Rows){
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            con = new SqlConnection("Data Source=LAPTOP-8MK2IUGC;Initial Catalog=Nawab;User ID=sa; password=123456");
            DataTable dt = new DataTable();
            var query = "select * from Student where id =" +id;
            adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, con)
            };
            adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecord));
                }
            }
            return students;
        }

        // POST api/<controller>
        public string Post([FromBody] CreateStudent value)
        {
            con = new SqlConnection("Data Source=LAPTOP-8MK2IUGC;Initial Catalog=Nawab;User ID=sa; password=123456");
            var query = "Insert into Student (f_name,m_name,l_name, address, birthday, score) values(@f_name,@m_name,@l_name, @address, @birthday, @score)";
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthday", value.birthday);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Them thanh cong";
            }
            else
            {
                return "Them that bai";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateStudent value)
        {
            con = new SqlConnection("Data Source=LAPTOP-8MK2IUGC;Initial Catalog=Nawab;User ID=sa; password=123456");
            var query = "Update Student set f_name=@f_name,m_name=@m_name,l_name=@l_name, address=@address, birthday=@birthday, score=@score where id ="+id;
            SqlCommand insertCommand = new SqlCommand(query, con);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthday", value.birthday);
            insertCommand.Parameters.AddWithValue("@score", value.score);
            con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Cap nhat thanh cong";
            }
            else
            {
                return "Cap nhat that bai";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            con = new SqlConnection("Data Source=LAPTOP-8MK2IUGC;Initial Catalog=Nawab;User ID=sa; password=123456");
            var query = "Delete from Student where id =" + id;
            SqlCommand insertCommand = new SqlCommand(query, con);
            con.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Xoa thanh cong";
            }
            else
            {
                return "Xoa that bai";
            }
        }
    }
}