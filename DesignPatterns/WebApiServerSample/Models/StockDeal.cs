using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiServerSample.Models
{
    public class StockDeal
    {
        public int Amount { get; set; }
        [Key]
        public String Symbole { get; set; }
        public double Value { get; set; }
        [Key]
        public DateTime Date { get; set; }

        public String State { get; set; }
    }
}