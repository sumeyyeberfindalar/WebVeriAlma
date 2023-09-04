using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static WebVeriAlma.Pages.Users.KullanicilarModel;
using WebVeriAlma.Classes;
using System.Data.SqlClient;
using WebVeriAlma.Pages.Classes;


// registerda kullandigimiz tema css falan onlarý buaraya cek lutfen 
namespace WebVeriAlma.Pages.Users
{
    public class OlusturModel : PageModel
    {
        cGenel connect = new cGenel();
        public UserInfo userInfo = new UserInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            String pass = userInfo.password;

            userInfo.nameSurname = Request.Form["nameSurname"];
            userInfo.email = Request.Form["email"];
            userInfo.username = Request.Form["username"];
            userInfo.password = Request.Form["password"];
            String PasswordSon = StaticVariables.MD5Encrypt(userInfo.password);


            try
            {
                using (SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "Insert Into users (nameSurname,email,password,username)VALUES(@nameSurname,@email,@password,@username)";


                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {

                        cmd.Parameters.AddWithValue("@nameSurname", userInfo.nameSurname);
                        cmd.Parameters.AddWithValue("@email", userInfo.email);
                        cmd.Parameters.AddWithValue("@username", userInfo.username);

                        cmd.Parameters.AddWithValue("@password", PasswordSon);

                        cmd.ExecuteNonQuery();



                        //UNIQUE DEGÝLSE HATA MESAJÝ CÝKARMAM GEREKÝYOR !!!!!!!!!!!COZULDU!!!!!!!!!!!!

                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                return;
            }

            userInfo.nameSurname = "";
            userInfo.email = "";
            userInfo.password = "";
            userInfo.username = "";
            successMessage = "New User Added Correctly";

            Response.Redirect("/Users/Kullanicilar");
        }
    }
}
