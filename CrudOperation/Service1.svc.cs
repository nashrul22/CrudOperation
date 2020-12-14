using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CrudOperation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Insert(InsertUser user)
        {
            string msg;
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-5QK0TPE\\NASHRUL; Initial Catalog=CrudPAT; Persist Security=true; User ID=sa;Password=12345;Pooling=False");
            con.Open();
                SqlCommand cmd = new SqlCommand("Insert into UserTab(Name, Email) values (@Name, @Email)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);


            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Succesfully Inserted";
            }
            else
            {
                msg = "Failed to insert";
            }
            return msg;
        }

       
    }
}
