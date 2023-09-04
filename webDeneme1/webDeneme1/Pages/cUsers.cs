using System.Data.SqlClient;
using WebVeriAlma.Classes;

namespace WebVeriAlma.Pages
{
    public class cUsers
    {

        public bool userEntryControl(String userName, String password)
        {   cGenel gnl = new cGenel();
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from users where userName=@userName and password=@password",con);
            cmd.Parameters.Add("@userName",System.Data.SqlDbType.VarChar).Value=userName;
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value=password;

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                String hata = ex.Message;
                throw;
            }
           
         
            return result;   
        }
        public bool changePasswordControl(String password)
        {
            cGenel gnl = new cGenel();
            bool result = false;
            SqlConnection con= new SqlConnection(gnl.conString);    
            SqlCommand cmd = new SqlCommand("Select * from users where password =@password",con);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = password;
            try
            {
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                result=Convert.ToBoolean(cmd.ExecuteScalar());  
            }
            catch(Exception ex)
            {
                String hata = ex.Message;
                throw;
            }
            return result;
        }
        

        
    }
}
