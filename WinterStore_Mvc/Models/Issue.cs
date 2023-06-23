using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class Issue
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");
        [Key] public int IssueId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string Mobile { get; set; }

        public string DateIssueRegistered { get; set; }

        public string DateIssueResolved { get; set; }

        public string status { get; set; }


        public List<Issue> getData()
        {
            List<Issue> issues = new List<Issue>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Issue", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                issues.Add(new Issue
                {
                    IssueId = Convert.ToInt32(dr["IssueId"].ToString()),
                    UserName = dr["UserName"].ToString(),
                    Email = dr["Email"].ToString(),
                    Message = dr["Message"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    DateIssueRegistered = dr["DateIssueRegistered"].ToString(),
                    DateIssueResolved = dr["DateIssueResolved"].ToString(),
                    status = dr["status"].ToString(),
                   
                });
            }
            return issues;
        }
        public Issue getData(int id)
        {
            Issue issue = new Issue();
            SqlCommand cmd = new SqlCommand("select * from Issue where IssueId=@IssueId", con);
            cmd.Parameters.AddWithValue("@IssueId", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            issue.IssueId = Convert.ToInt32(dr["IssueId"].ToString());
            issue.UserName = dr["UserName"].ToString();
            issue.Email = dr["Email"].ToString();
            issue.Message = dr["Message"].ToString();
            issue.Mobile = dr["Mobile"].ToString();
            issue.DateIssueRegistered = dr["DateIssueRegistered"].ToString();
            issue.DateIssueResolved = dr["DateIssueResolved"].ToString();
            issue.status = dr["status"].ToString();
         
            con.Close();
            return issue;
     
        
       }
        //Insert a record into a database table
        public bool Insert(Issue issue)
        {
            SqlCommand cmd = new SqlCommand("insert into Issue(UserName,Email,Message,Mobile,DateIssueRegistered) values(@UserName,@Email,@Message,@Mobile,@DateIssueRegistered)", con);
            cmd.Parameters.AddWithValue("@UserName", issue.UserName);
            cmd.Parameters.AddWithValue("@Email", issue.Email);
            cmd.Parameters.AddWithValue("@Message", issue.Message);
            cmd.Parameters.AddWithValue("@Mobile", issue.Mobile);
            cmd.Parameters.AddWithValue("@DateIssueRegistered", DateTime.Now.ToString());
            
   
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


    }
}   