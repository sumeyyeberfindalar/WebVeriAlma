using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebVeriAlma.Classes;
using WebVeriAlma.Pages.Classes;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;

namespace WebVeriAlma.Pages.Shared
{

    public class IsZamanlaModel : PageModel
    {

        cGenel connect = new cGenel();
        public urlAlClass url = new urlAlClass();
        public ÝsAraligi isAraligi = new ÝsAraligi();
        public String sonUrl = "";
        string isName = "";
        string aralik = "";

        public void OnGet()
        {

        }
        public void OnPost()
        {
            //StaticVariables.cop.AddArguments("headless");
            //StaticVariables.cop.AddArguments("--disable-notifications");


            StaticVariables.driver = new OpenQA.Selenium.Chrome.ChromeDriver();

            sonUrl = Request.Form["urlAddress"];
            isName = Request.Form["urlName"];
            aralik = Request.Form["isAraligi"];

            //StaticVariables.Connect(sonUrl);

            switch (aralik)
            {
                case "1":
                    SchedularHelper.SchedulerInMinute();
                    break;
                case "3":
                    SchedularHelper.SchedulerInThreeHours();
                    break;
                case "24":
                    SchedularHelper.SchedulerInDay();
                    break;
                
            }
            //String message = StaticVariables.GetCurrentUrl();
            //String message = StaticVariables.GetPrice("offering-price");


            //StaticVariables.driver.Close();


            try
            {
                using (SqlConnection connection = new SqlConnection(connect.conString))
                {
                    connection.Open();
                    String sql = "Insert Into html (htmlVeri,name)VALUES(@htmlVeri,@name)";


                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = isName;
                        cmd.Parameters.Add("@htmlVeri", System.Data.SqlDbType.Text).Value = "dene";


                        cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {

                return;
            }

            Response.Redirect("/Shared/Goruntule");

        }
    }
}
