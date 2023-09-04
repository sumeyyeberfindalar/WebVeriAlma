using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebVeriAlma.Classes;

namespace WebVeriAlma.Pages.Shared
{
    public class GoruntuleModel : PageModel
    {
        public List<urlAlClass> ListURL = new List<urlAlClass>();

        cGenel connect = new cGenel();

        public void OnGet()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connect.conString))
                {
                    con.Open();
                    String sql = "Select * From html";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                urlAlClass urlInfo = new urlAlClass();
                                urlInfo.id = "" + dr.GetInt32(0);
                                urlInfo.name = dr.GetString(1);
                                urlInfo.htmlVeri = dr.GetString(2);
                             
                             
                                ListURL.Add(urlInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
