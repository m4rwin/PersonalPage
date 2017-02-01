using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace martinhromek.bitcoin
{
  public partial class Stock : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // http://www.coindesk.com/api/
      var v = comm.GET("http://api.coindesk.com/v1/bpi/currentprice.json");

      IEnumerable<string> arr = v.Split(',').Where(i => i.Contains("rate")).Skip(1);

      string course = arr.FirstOrDefault().Replace('"', ' ').Split(':')[1];
      this.lblExchange.Text = $"[Coindesk] {course} USB / 1 BTC";
    }
  }
}