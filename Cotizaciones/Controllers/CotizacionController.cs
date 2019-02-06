using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cotizaciones.Controllers
{
    [Route("/[controller]")]
    public class CotizacionController : Controller
    {
        [HttpGet("{Moneda}")]
        public string Get(string moneda)
        {
            string result = null, result1 = null;
            int i = 0;
            string url = null;
            if (moneda=="dolar")
            {
                url = "http://api.valuta.money/v1/quotes/USD/ARS/json?quantity=1&key=1695|wjJyUFUSxHmmgkqHS_NYvAcLTeCLQyfL";
            }
            else if(moneda =="euro")
            {
                url = "http://api.valuta.money/v1/quotes/EUR/ARS/json?quantity=1&key=1695|wjJyUFUSxHmmgkqHS_NYvAcLTeCLQyfL";
            }
            else if(moneda =="real")
            {
                url = "http://api.valuta.money/v1/quotes/BRL/ARS/json?quantity=1&key=1695|wjJyUFUSxHmmgkqHS_NYvAcLTeCLQyfL";
            }
            else
            {
                return "Moneda Inexistente";
            }
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                result = reader.ReadToEnd();
                i = result.IndexOf("value");
                result1 = result.Substring(i + 7, 8);

            }
            return result = "Moneda: " + moneda + System.Environment.NewLine + "Precio:" + result1 ;
        }

       
    }
}
