using System;
using System.Threading.Tasks;
using Quartz;
using WebVeriAlma.Pages.Classes;

namespace WebVeriAlma.Classes
{
    public class GetHtmlJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            //StaticVariables.driver.Navigate().GoToUrl("https://www.trendyol.com/vatkalimon/denim-kot-koyu-mavi-omuz-ve-bel-cantasi-p-177418745?boutiqueId=608117&merchantId=207608");
            //StaticVariables.Connect("https://www.trendyol.com/vatkalimon/denim-kot-koyu-mavi-omuz-ve-bel-cantasi-p-177418745?boutiqueId=608117&merchantId=207608");
            StaticVariables.GetHtmlofPage();
            //StaticVariables.driver.Close();
            return Task.CompletedTask;
        }
    }
}
