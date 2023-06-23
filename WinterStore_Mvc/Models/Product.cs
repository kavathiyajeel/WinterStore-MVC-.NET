using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WinterStore_Mvc.Models
{

    public class Product

    {
    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-09UAKUJ\JEEL;Initial Catalog=WinterStore;Integrated Security=True");
        [Key] public int pid { get; set; } 
        public string pname { get; set; }    
        public string pbrand { get; set; }    
        public string pdesc { get; set; } 
        public string pcategory { get; set; }    
        public int pmrp { get; set; }    
        public int pprice { get; set; }    
        public string pidealfor { get; set; }    
        public string pimage { get; set; }    
        public int isActive { get; set; }

        public List<Product> getData()
        {
            List<Product> lstPdt = new List<Product >();
            SqlDataAdapter apt = new SqlDataAdapter("select * from products", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstPdt.Add(new Product { pid = Convert.ToInt32(dr["pid"].ToString()),
                    pname = dr["pname"].ToString(),
                    pbrand = dr["pbrand"].ToString(),
                    pdesc = dr["pdesc"].ToString(), 
                    pcategory = dr["pcategory"].ToString(), 
                    pmrp = Convert.ToInt32(dr["pmrp"].ToString()),
                    pprice = Convert.ToInt32(dr["pprice"].ToString()), 
                    pidealfor = dr["pidealfor"].ToString(),
                    pimage = dr["pimage"].ToString(),
                    isActive = Convert.ToInt32(dr["isActive"].ToString()) });
            }
            return lstPdt;
        } 
        public Product getData(int id)
        {
            Product product= new Product(); 
            SqlCommand cmd = new SqlCommand("select * from products where pid=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
           SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            product.pid = Convert.ToInt32(dr["pid"].ToString());
             product.pname = dr["pname"].ToString();
product.pbrand = dr["pbrand"].ToString();
                product.pdesc = dr["pdesc"].ToString();
                product.pcategory = dr["pcategory"].ToString();
                product.pmrp = Convert.ToInt32(dr["pmrp"].ToString());
                product.pprice = Convert.ToInt32(dr["pprice"].ToString());
                product.pidealfor = dr["pidealfor"].ToString();
                product.pimage = dr["pimage"].ToString();
                product.isActive = Convert.ToInt32(dr["isActive"].ToString());
            con.Close();
            return product;
        }
        public bool Insert(Product product)
        {
            SqlCommand cmd = new SqlCommand("insert into Products(pname,pbrand,pdesc,pcategory,pmrp,pprice,pidealfor,pimage,isActive)values (@pname,@pbrand,@pdesc,@pcategory,@pmrp,@pprice,@pidealfor,@pimage,@isActive)", con);
           
            cmd.Parameters.AddWithValue("@pname", product.pname);
            cmd.Parameters.AddWithValue("@pbrand", product.pbrand);
            cmd.Parameters.AddWithValue("@pdesc", product.pdesc);
            cmd.Parameters.AddWithValue("@pcategory", product.pcategory);
            cmd.Parameters.AddWithValue("@pmrp", product.pmrp);
            cmd.Parameters.AddWithValue("@pprice", product.pprice);
            cmd.Parameters.AddWithValue("@pidealfor", product.pidealfor);
            cmd.Parameters.AddWithValue("@pimage", product.pimage);
            cmd.Parameters.AddWithValue("@isActive", product.isActive);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public bool Update(Product product)
        {
            SqlCommand cmd = new SqlCommand("update products SET pname=@pname," +
                "pbrand=@pbrand," +
                "pdesc=@pdesc,pcategory=@pcategory,pmrp=@pmrp,pprice=@pprice,pidealfor=@pidealfor,pimage=@pimage,isActive=@isActive where pid=@pid", con);
            cmd.Parameters.AddWithValue("@pid",product.pid);
            cmd.Parameters.AddWithValue("pname", product.pname);
            cmd.Parameters.AddWithValue("pbrand", product.pbrand);
            cmd.Parameters.AddWithValue("pdesc", product.pdesc);
            cmd.Parameters.AddWithValue("pcategory", product.pcategory);
            cmd.Parameters.AddWithValue("pmrp", product.pmrp);
            cmd.Parameters.AddWithValue("pprice", product.pprice);
            cmd.Parameters.AddWithValue("pidealfor", product.pidealfor);
            cmd.Parameters.AddWithValue("pimage", product.pimage);
            cmd.Parameters.AddWithValue("isActive", product.isActive);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public bool delete(Product product)
        {
            SqlCommand cmd = new SqlCommand("delete Products where pid = @pid", con);
            cmd.Parameters.AddWithValue("@pid", product.pid);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        public List<Product> getData_Men()
        {
            List<Product> lstMen = new List<Product>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from products where pidealfor='Men'", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstMen.Add(new Product
                {
                    pid = Convert.ToInt32(dr["pid"].ToString()),
                    pname = dr["pname"].ToString(),
                    pbrand = dr["pbrand"].ToString(),
                    pdesc = dr["pdesc"].ToString(),
                    pcategory = dr["pcategory"].ToString(),
                    pmrp = Convert.ToInt32(dr["pmrp"].ToString()),
                    pprice = Convert.ToInt32(dr["pprice"].ToString()),
                    pidealfor = dr["pidealfor"].ToString(),
                    pimage = dr["pimage"].ToString(),
                    isActive = Convert.ToInt32(dr["isActive"].ToString())
                });
            }
            return lstMen;

        }

        public List<Product> getData_Women()
        {
            List<Product> lstMen = new List<Product>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from products where pidealfor='Women'", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstMen.Add(new Product
                {
                    pid = Convert.ToInt32(dr["pid"].ToString()),
                    pname = dr["pname"].ToString(),
                    pbrand = dr["pbrand"].ToString(),
                    pdesc = dr["pdesc"].ToString(),
                    pcategory = dr["pcategory"].ToString(),
                    pmrp = Convert.ToInt32(dr["pmrp"].ToString()),
                    pprice = Convert.ToInt32(dr["pprice"].ToString()),
                    pidealfor = dr["pidealfor"].ToString(),
                    pimage = dr["pimage"].ToString(),
                    isActive = Convert.ToInt32(dr["isActive"].ToString())
                });
            }
            return lstMen;

        }

        public List<Product> getData_Kids()
        {
            List<Product> lstMen = new List<Product>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from products where (pidealfor != 'Men')and (pidealfor != 'Women') and (isActive = 0)", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstMen.Add(new Product
                {
                    pid = Convert.ToInt32(dr["pid"].ToString()),
                    pname = dr["pname"].ToString(),
                    pbrand = dr["pbrand"].ToString(),
                    pdesc = dr["pdesc"].ToString(),
                    pcategory = dr["pcategory"].ToString(),
                    pmrp = Convert.ToInt32(dr["pmrp"].ToString()),
                    pprice = Convert.ToInt32(dr["pprice"].ToString()),
                    pidealfor = dr["pidealfor"].ToString(),
                    pimage = dr["pimage"].ToString(),
                    isActive = Convert.ToInt32(dr["isActive"].ToString())
                });
            }
            return lstMen;

        }

    }
}