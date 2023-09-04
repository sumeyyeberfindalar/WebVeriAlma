using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebVeriAlma.Classes;

namespace WebVeriAlma.Pages.Shared
{
    public class DuzenleGoruntuleModel : PageModel
    {
        cGenel connect = new cGenel();
        public urlAlClass urlInfo = new urlAlClass();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];
            try
            {
                using (SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM html WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urlInfo.id = "" + reader.GetInt32(0);
                                urlInfo.name = reader.GetString(1);
                                urlInfo.htmlVeri = reader.GetString(2);
                              

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
            urlInfo.id = Request.Form["id"];
            urlInfo.name = Request.Form["isim"];
            urlInfo.htmlVeri = Request.Form["htmlVeri"];
            


            try
            {
                using (SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "UPDATE html SET name=@name, htmlVeri=@htmlVeri WHERE id=@id";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", urlInfo.name);
                        cmd.Parameters.AddWithValue("@htmlVeri", urlInfo.htmlVeri);
                        cmd.Parameters.AddWithValue("@id", urlInfo.id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Shared/Goruntule");
        }
    }
}
