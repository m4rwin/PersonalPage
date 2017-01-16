using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace martinhromek
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            string value = e.Item.Value;

            string path = "~/" + e.Item.Parent.Value + ".aspx?id=" + value;
            Response.Redirect(path);
        }
    }
}