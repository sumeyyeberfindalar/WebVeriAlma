using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebVeriAlma.Classes;
using WebVeriAlma.Pages.Classes;
using static WebVeriAlma.Pages.Users.KullanicilarModel;

namespace WebVeriAlma.Pages.Users
{
    public class DuzenleModel : PageModel
    {

        cGenel connect = new cGenel();
        public UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id= Request.Query["id"];
            try
            {
                using(SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM users WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userInfo.id = ""+reader.GetInt32(0);
                                userInfo.nameSurname = reader.GetString(1);
                                userInfo.email = reader.GetString(2);   
                                userInfo.username = reader.GetString(3); 

                                userInfo.password = StaticVariables.MD5Decrypt( reader.GetString(4));   
                    

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            userInfo.id = Request.Form["id"];
            userInfo.nameSurname = Request.Form["nameSurname"];
            userInfo.email = Request.Form["email"];
            userInfo.username = Request.Form["username"];

            userInfo.password = Request.Form["password"];

        
            try
            {
                using (SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "UPDATE users SET nameSurname=@nameSurname, email=@email, username=@username, password=@password WHERE id=@id";
                    
                    using(SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@nameSurname", userInfo.nameSurname);
                        cmd.Parameters.AddWithValue("@email", userInfo.email);
                        cmd.Parameters.AddWithValue("@username", userInfo.username);

                        cmd.Parameters.AddWithValue("@password", userInfo.password);
                        cmd.Parameters.AddWithValue("@id", userInfo.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }

            Response.Redirect("/Users/Kullanicilar");
        }
    }
}
