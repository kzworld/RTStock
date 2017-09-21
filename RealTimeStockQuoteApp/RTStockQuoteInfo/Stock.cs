using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RTStockQuoteInfo
{

    /// <summary>
    /// Stock Class
    /// </summary>
    public class Stock
    {
        #region Stock Properties Setting
        readonly string quote = "";
        readonly string price = "";
        readonly string time = "";
        readonly string pclsprice = "";
        readonly string exceptionwords = "";


        public string Quote
        {
            get { return quote; }
            
        }

        public string Price
        {
            get { return price; }
            
        }

        public string Time
        {
            get { return time; }

        }

        public string PclsPrice
        {
            get { return pclsprice; }

        }

        #endregion

        #region Stock Class Initialization with a string parameter
        public Stock(string stockquote)
        {
            try
            {
                string quotestr = "http://www.google.com/finance/info?q=" + stockquote;
                WebClient client = new WebClient();
                client.Proxy = null;

                string JsQuote = client.DownloadString(quotestr).Replace("]", "");
                dynamic obj = JObject.Parse(JsQuote);
                quote = obj.t;
                price = obj.l;
                time = obj.lt_dts;
                pclsprice = obj.pcls_fix;   
            }
            catch 
            {
                return;
            }
        }
        #endregion
    }

    /// <summary>
    /// StockList Class List<Stock>
    /// </summary>
    public class StockList : List<Stock>
    {
    }

}
