using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace martinhromek.library
{
  public partial class AddBook : System.Web.UI.Page
  {
    #region Properties
    private string DBPath { get; set; }
    private List<Book> Lib { set; get; } = new List<Book>();
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
      DBPath = Server.MapPath(Session["db"].ToString());
      Lib = (List<Book>)Session["library"];

      if (!IsPostBack)
        LoadData();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        SaveItem();
        lblInfo.ForeColor = System.Drawing.Color.DarkGreen;
        lblInfo.Text = "Uloženo";
        Response.AppendHeader("Refresh", "2");
      }
      catch (Exception)
      {
        lblInfo.ForeColor = System.Drawing.Color.DarkRed;
        lblInfo.Text = "Chyba";
        throw;
      }
    }

    protected void ddAuthorCoolection_SelectedIndexChanged(object sender, EventArgs e)
    {
      string[] a = ddAuthorCollection.SelectedValue.Split(' ');
      txbFirstName.Text = a[0];
      txbMiddleName.Text = string.Join(" ", a, 1, a.Length - 2);
      txbLastName.Text = a[a.Length - 1];
    }

    protected void ddGroup_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        ddGroup.DataSource = Enum.GetNames(typeof(Common.BookGroup));
        ddGroup.DataBind();
      }
    }

    protected void ddPublisherCollection_SelectedIndexChanged(object sender, EventArgs e)
    {
      txbPublisher.Text = ddPublisherCollection.SelectedValue;
    }

    protected void lbGenre_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        lbGenre.DataSource = Enum.GetNames(typeof(Common.BookGenre));
        lbGenre.DataBind();
      }
    }

    protected void ddType_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        ddType.DataSource = Enum.GetNames(typeof(Common.BookType));
        ddType.DataBind();
      }
    }
    #endregion

    #region Method
    private void LoadData()
    {
      Lib.Sort((x, y) => string.Compare(x.AuthorLastName, y.AuthorLastName));
      var v = Lib.GroupBy(g => new
      {
        g.AuthorFirstName,
        g.AuthorMiddleName,
        g.AuthorLastName
      });

      ddAuthorCollection.Items.Clear();
      foreach (var i in v)
        ddAuthorCollection.Items.Add(new ListItem(
            $"{i.Key.AuthorLastName}, {i.Key.AuthorFirstName} {i.Key.AuthorMiddleName}",
            $"{i.Key.AuthorFirstName} {i.Key.AuthorMiddleName} {i.Key.AuthorLastName}"));





      Lib.Sort((x, y) => string.Compare(x.Publish3r, y.Publish3r));
      var w = Lib.GroupBy(g => new
      {
        g.Publish3r
      });

      ddPublisherCollection.Items.Clear();
      foreach (var ii in w)
        ddPublisherCollection.Items.Add(new ListItem() { Text = $"{ii.Key.Publish3r}", Value = $"{ii.Key.Publish3r}" });
    }

    private void SaveItem()
    {
      XDocument doc = XDocument.Load(DBPath);

      doc.Element("books").SetAttributeValue("last_update", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

      XElement books = doc.Element("books");

      int id = (books.HasElements) ? Convert.ToInt32(books?.Elements()?.Last().Attribute("id").Value) : 0;

      books.Add(
          new XElement("book",
              new XAttribute("id", (++id).ToString()),
              new XAttribute("cover", fileCover.FileName),
          new XElement("name",
              new XAttribute("original", txbOriginalName.Text),
              new XAttribute("czech", txbCzechName.Text)),
          new XElement("author",
              new XElement("first_name", txbFirstName.Text),
              new XElement("middle_name", txbMiddleName.Text),
              new XElement("last_name", txbLastName.Text)
          ),
          new XElement("publication_date",
              new XAttribute("original", txbDatePublish.Text),
              new XAttribute("my", txbDatePublishMy.Text)),
          new XElement("publisher", txbPublisher.Text),
          new XElement("type", ddType.SelectedValue),
          new XElement("genre", ReturnItems(lbGenre.Items)),
          new XElement("group", ddGroup.SelectedValue),
          new XElement("readed", ddReaded.SelectedValue),
          new XElement("date_read", txbDateRead.Text),
          new XElement("ratings", txbRating.Text),
          new XElement("ratings_value", txbRatingValue.Text)
          ));
      doc.Save(DBPath);
    }

    private List<XElement> ReturnItems(ListItemCollection items)
    {
      List<XElement> result = new List<XElement>();
      char ch = 'a';
      foreach (ListItem item in items)
        if (item.Selected)
          result.Add(new XElement((ch++).ToString(), item.Text));
      return result;
    }
    #endregion
  }
}