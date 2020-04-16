using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace Task5
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class News : System.Web.Services.WebService
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime NewsDate { get; set; }

        [WebMethod]
        public News Get()
        {
            Thread.Sleep(3000);
            return new News { Title = "New News", Description ="My news", NewsDate = DateTime.Parse("2020-10-11") };
        }
    }
}
