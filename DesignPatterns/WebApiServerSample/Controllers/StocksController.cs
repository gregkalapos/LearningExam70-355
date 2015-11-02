using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiServerSample.Controllers
{
    public class StocksController : ApiController
    {

        public Tick GetPrice(int id)
        {
            var retVal = new Tick();

            if(id == 1) //  if(symbol.ToLower() == "appl")
            {
                retVal.CompanyName = "Apple";
            }
            else if(id == 2)//  if(symbol.ToLower() == "msft")
            {
                retVal.CompanyName = "Microsoft";
            }

            else
            {
                return null;
            }

            Random rnd = new Random(DateTime.Now.Second);


            retVal.Price = rnd.Next(100);
            retVal.Time = DateTime.Now;

            return retVal;
        }

        public void PostOrder(Order Order)
        {

        }

    }

    public class Order
    {
        public int StockId { get; set; }
        public int Amount { get; set; }
    }

    public class Tick
    {
        public String CompanyName { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
    }
}
