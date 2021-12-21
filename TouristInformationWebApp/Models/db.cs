//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;
//using System.Configuration;
//using TouristInformation.Models;

//namespace TouristInformation.Models
//{
//    public class db
//    {
//        SqlConnection con = new SqlConnection("Data Source=touristinformation.database.windows.net;Initial Catalog=TouristInformationDB;Persist Security Info=True;User ID=TouristInformationAdmin;Password=TouristInformation1234!");
//        public int LoginCheck(Userr ad)
//        {
//            SqlCommand com = new SqlCommand("Sp_Login2", con);
//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@Admin_id", ad.Admin_id);
//            com.Parameters.AddWithValue("@Password", ad.Ad_Password);
//            SqlParameter oblogin = new SqlParameter();
//            oblogin.ParameterName = "@Isvalid";
//            oblogin.SqlDbType = SqlDbType.Bit;
//            oblogin.Direction = ParameterDirection.Output;
//            com.Parameters.Add(oblogin);
//            con.Open();
//            com.ExecuteNonQuery();
//            int res = Convert.ToInt32(oblogin.Value);
//            con.Close();
//            return res;
//        }
//    }
//}

