using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using WebVeriAlma.Classes;
using static WebVeriAlma.Pages.Users.KullanicilarModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebVeriAlma.Pages.Classes;

namespace WebVeriAlma.Pages.Shared
{
    public class GirisModel : PageModel
    {

        public String successMessage = "";
        public String errorMessage = "";
        public UserInfo userInfo = new UserInfo();

        public void OnGet()
        {

        }
        public void OnPost()
        {

            userInfo.password = Request.Form["password"];
            userInfo.username = Request.Form["username"];
            cGenel gnl = new cGenel();
            cUsers users = new cUsers();
            bool result = users.userEntryControl(userInfo.username, StaticVariables.MD5Encrypt( userInfo.password));

            if (result)
            {
                successMessage = "basarili giris";
                Response.Redirect("/Shared/Admin");
            }
            else
            {
                errorMessage = "hata";
            }
        }
    }

}
