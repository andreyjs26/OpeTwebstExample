using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       // List<string> myList= new List<string>(string[] arr = new string[] {});
        string[] arr = new string[] {};

        GridView1.DataSource = arr;
        GridView1.DataBind();

    }
}