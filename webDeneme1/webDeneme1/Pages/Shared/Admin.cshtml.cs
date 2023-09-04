using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenQA.Selenium.Chrome;
using WebVeriAlma.Pages.Classes;
using WebVeriAlma.Classes;
using static WebVeriAlma.Pages.Users.KullanicilarModel;
using System.Data.SqlClient;

namespace WebVeriAlma.Pages.Shared
{
    public class ChromeDriverService : PageModel

    {
        //urlAlClass urlAl = new urlAlClass();

        //cGenel connect = new cGenel();

        //private readonly IWebHostEnvironment _env;

        //public ChromeDriverService(IWebHostEnvironment env)
        //{
        //    _env = env;
        //    StaticVariables.driver = new ChromeDriver(_env.ContentRootPath + "/Pages/Selenium", StaticVariables.cop);
        //}

        public void OnGet()
        {

            //StaticVariables.Connect("https://www.hepsiburada.com/awox-armada-celik-kettle-inox-p-HBV00000BAXTF");

            ////String message = StaticVariables.GetHtmlofPage();
            ////String message = StaticVariables.GetCurrentUrl();
            //String message = StaticVariables.GetPrice("offering-price");
            //StaticVariables.driver.Close();


            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connect.conString))
            //    {
            //        connection.Open();
            //        String sql = "Insert Into html (htmlVeri)VALUES(@htmlVeri)";
            //        String deneme = "denemedur";

            //        using (SqlCommand cmd = new SqlCommand(sql, connection))
            //        {

            //            cmd.Parameters.Add("@htmlVeri",System.Data.SqlDbType.VarChar).Value=message;


            //            cmd.ExecuteNonQuery();
            
            //            Response.Redirect("/Users/Create");

            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
   

            //    Response.Redirect("/Shared/Login");

            //    return;
            //}



        }
    }
}
