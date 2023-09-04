using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebVeriAlma.Classes;

namespace WebVeriAlma.Pages.Users
{
    public class KullanicilarModel : PageModel
    {
        public List<UserInfo> ListUsers = new List<UserInfo>();
        
        cGenel connect =new cGenel();
  
        public void OnGet()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connect.conString))
                {
                        con.Open();
                        String sql = "Select * From users";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                UserInfo usersInfo = new UserInfo();
                                usersInfo.id = "" + dr.GetInt32(0);
                                usersInfo.nameSurname = dr.GetString(1);
                                usersInfo.email = dr.GetString(2);
                                usersInfo.username = dr.GetString(3);
                                usersInfo.password = dr.GetString(4);

                                usersInfo.created_at = dr.GetDateTime(5).ToString();

                                ListUsers.Add(usersInfo);
                            }
                        }
                    }
                 }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + ex.ToString());
            }
        }

      
    }
}