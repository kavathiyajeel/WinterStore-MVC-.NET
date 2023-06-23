using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{
    public class Customers
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");

        [Key] public int CustomerID { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }

        public string CustomerState { get; set; }

        public string CustomerZip { get; set; }

        public string CustomerPhone { get; set; }
        public string CustomerDateAdded { get; set; }

        public int CustomerIsActive { get; set; }
        public List<Customers> getData()
        {
            List<Customers> lstCust = new List<Customers>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Customers", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstCust.Add(new Customers {
                    CustomerID = Convert.ToInt32(dr["CustomerID"].ToString()),
                    CustomerFirstName = dr["CustomerFirstName"].ToString(),
                    CustomerLastName = dr["CustomerLastName"].ToString(),
                    CustomerEmail = dr["CustomerEmail"].ToString(), 
                    CustomerAddress = dr["CustomerAddress"].ToString(),
                    CustomerCity = dr["CustomerCity"].ToString(), 
                    CustomerState = dr["CustomerState"].ToString(),
                    CustomerZip = dr["CustomerZip"].ToString(),
                    CustomerPhone = dr["CustomerPhone"].ToString(),
                    CustomerDateAdded = dr["CustomerDateAdded"].ToString(),
                    //CustomerIsActive = Convert.ToInt32(dr["CustomerIsActive"].ToString())
                });
            }
            return lstCust;
        }
        public Customers getData(int id)
        {
            Customers customer = new Customers();
            SqlCommand cmd = new SqlCommand("select * from Customers where CustomerID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            customer.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                    customer.CustomerFirstName = dr["CustomerFirstName"].ToString();
                    customer.CustomerLastName = dr["CustomerLastName"].ToString();
                    customer.CustomerEmail = dr["CustomerEmail"].ToString();
                    customer.CustomerAddress = dr["CustomerAddress"].ToString();
                    customer.CustomerCity = dr["CustomerCity"].ToString();
                    customer.CustomerState = dr["CustomerState"].ToString();
                    customer.CustomerZip = dr["CustomerZip"].ToString();
                   customer.CustomerPhone = dr["CustomerPhone"].ToString();
                   customer.CustomerDateAdded = dr["CustomerDateAdded"].ToString();
                    //customer.CustomerIsActive = Convert.ToInt32(dr["CustomerIsActive"].ToString());
            con.Close();
            return customer;
        }

        public  (string,string,int) Login(string email,string password,int i)
        {
            SqlCommand cmd = new SqlCommand("select * from Customers where CustomerEmail ='"+email+"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
             string CustomerPassword = dr["CustomerPassword"].ToString();
                string name = dr["CustomerFirstName"].ToString();
                int id = (int)dr["CustomerID"];
                if (password == CustomerPassword) {
                    
                return ("user",name,id);
                }
                
            }
            if(email == "admin@gmail.com" && password == "admin")
            {
                return ("admin","admin",1);
            }
                    return ("Incoreeect Password", "admin", 1);
          
           


        }
        //Insert a record into a database table
        public bool Insert(Customers customer)
        {
            SqlCommand cmd = new SqlCommand("insert into Customers(CustomerFirstName,CustomerLastName,CustomerEmail,CustomerPassword,CustomerAddress,CustomerCity,CustomerState,CustomerZip,CustomerPhone,CustomerDateAdded) values(@CustomerFirstName,@CustomerLastName,@CustomerEmail,@CustomerPassword,@CustomerAddress,@CustomerCity,@CustomerState,@CustomerZip,@CustomerPhone,@CustomerDateAdded)", con);
            cmd.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
            cmd.Parameters.AddWithValue("@CustomerLastName", customer.CustomerLastName);
            cmd.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@CustomerPassword", customer.CustomerPassword);
            cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
            cmd.Parameters.AddWithValue("@CustomerState", customer.CustomerState);
            cmd.Parameters.AddWithValue("@CustomerZip", customer.CustomerZip);
            cmd.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
            cmd.Parameters.AddWithValue("@CustomerDateAdded", DateTime.Now.ToString());
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        } 
        //Update a record into a database table
        public bool Update(Customers customer)
        {
            SqlCommand cmd = new SqlCommand("update Customers SET CustomerFirstName=@CustomerFirstName," +
                "CustomerLastName=@CustomerLastName," +
                "CustomerEmail=@CustomerEmail," +
                "CustomerAddress=@CustomerAddress," +
                "CustomerCity=@CustomerCity," +
                "CustomerState=@CustomerState," +
                "CustomerZip=@CustomerZip," +
                "CustomerPhone=@CustomerPhone where CustomerID = @id", con);
            cmd.Parameters.AddWithValue("@id", customer.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerFirstName", customer.CustomerFirstName);
            cmd.Parameters.AddWithValue("@CustomerLastName", customer.CustomerLastName);
            cmd.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
            cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
            cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
            cmd.Parameters.AddWithValue("@CustomerState", customer.CustomerState);
            cmd.Parameters.AddWithValue("@CustomerZip", customer.CustomerZip);
            cmd.Parameters.AddWithValue("@CustomerPhone", customer.CustomerPhone);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool delete(Customers customer)
        {
            SqlCommand cmd = new SqlCommand("delete Customers where CustomerID = @id", con);
            cmd.Parameters.AddWithValue("@id", customer.CustomerID);
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