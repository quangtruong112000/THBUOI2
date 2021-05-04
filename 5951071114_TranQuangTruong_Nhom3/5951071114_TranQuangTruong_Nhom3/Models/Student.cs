﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _5951071114_TranQuangTruong_Nhom3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public string score { get; set; }
        public string dep_id { get; set; }

    }
    public class ReadStudent : Student
    {
        public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            f_name = row["f_name"].ToString();
            m_name = row["m_name"].ToString();
            l_name = row["l_name"].ToString();
            address = row["address"].ToString();
            birthday = row["birthday"].ToString();
            score = row["score"].ToString();
        }
    }
    public class CreateStudent : Student
    {

    }
}