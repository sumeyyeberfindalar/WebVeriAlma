
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using System.Security.Cryptography;

namespace WebVeriAlma.Pages.Classes
{

    public static class StaticVariables
    {

        static public ChromeOptions cop = new ChromeOptions();
        static public ChromeDriver driver = null;

        public static void Connect(string link)
        {
            driver.Navigate().GoToUrl(link);

        }
        public static void FindandClick(string id)
        {
            WebElement element = (WebElement)driver.FindElement(By.Id(id));
            element.Click();

        }

        public static string GetHtmlofPage()
        {
            String pageSource = driver.PageSource;
            String date = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + "..."
                + DateTime.Now.Hour.ToString() + "." + DateTime.Now.Minute.ToString();

            String path = "C:\\Users\\Dell\\Desktop\\html\\htmlFile" + date + ".html";
            File.WriteAllText(path, pageSource);
            return path;
        }
        public static string GetCurrentUrl()
        {
            return driver.Url;
        }

        public static string GetPrice(String id)
        {
            WebElement element = (WebElement)driver.FindElement(By.Id(id));
            return element.Text;
        }

        //!!!!!!!!!!!!!!!!!!!!!!!!HASH DEĞİŞECEK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static string hash = "berfoy";
        public static string MD5Encrypt(string sifre)
        {

            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }

        }

        public static string MD5Decrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }

        }


    }

}


