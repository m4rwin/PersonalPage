using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;
using BaseLibrary;

namespace martinhromek.library
{
  public partial class Home : System.Web.UI.Page
  {
    #region Properties
    public string DB { set; get; }
    public string DBPath { set; get; } = "~/library/storage.xml";
    public Library MyLib { private set; get; }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        LoadData();
        SetStatistics();
        ShowData();
      }
      catch (Exception)
      {
      }
    }

    protected void btnChangeLanguage_Click(object sender, EventArgs e)
    {
      if (Session["lang"] == null || Session["lang"].Equals("cz"))
        Session["lang"] = "en";
      else
        Session["lang"] = "cz";

      Page.Response.Redirect(Request.Url.ToString());
    }
    #endregion

    #region Method
    private void LoadData()
    {
      DB = Server.MapPath(DBPath);

      if (!File.Exists(DB))
        CreateDB();

      Session["db"] = DBPath;

      MyLib = new Library(DB);

      lblLastUpdate.Text = $"last update: {MyLib.LibraryLastUpdate}";
      Session["library"] = MyLib.AllBooks;
    }

    private void CreateDB()
    {
      new XDocument(
        new XElement("books",
          new XAttribute("last_update", DateTime.Now)
        )
      ).Save(DB);
    }

    private void ShowData()
    {
      bool language = (Session["lang"] == null || Session["lang"].Equals("cz")) ? true : false;

      foreach (string group in Enum.GetNames(typeof(Common.BookGroup)))
        this.MainPanel.Controls.Add(new Panel() { ID = $"panel{group}", GroupingText = group });

      foreach (var item in MyLib.AllBooks)
        ShowBook(FindControl($"panel{item.Groupe}"), item, language);
    }

    private void ShowBook(System.Web.UI.Control panel, Book item, bool lang)
    {
      string readedText = item.Readed ? $"přečteno: {item.DateRead} - {item.Ratings} [{item.RatingsValue}%]" : "nepřečteno";
      string tooltip = $"{item.AuthorFirstName} {item.AuthorMiddleName} {item.AuthorLastName} - {item.OriginalName} ({item.OriginalPublicationDate}), {item.CzechName} ({item.MyPublicationDate}), {item.Publish3r}, {item.BookType}, [{item.GenreAll}], [{item.Groupe}], {readedText}";
      string bookName = (lang) ? item.CzechName : item.OriginalName;

      panel.Controls.Add(new Label()
      { /*ID = DateTime.Now.Millisecond.ToString(),*/
        Text = $"{item.AuthorLastName}, {item.AuthorFirstName} {item.AuthorMiddleName} - {bookName}",
        Width = 400,
        BorderWidth = 0,
        ToolTip = tooltip,
        ForeColor = item.Readed ? System.Drawing.Color.LawnGreen : System.Drawing.Color.Black
      });
      panel.Controls.Add(new LiteralControl("<br />"));
    }

    private void SetStatistics()
    {
      lblNoOfBooks.Text = $"{MyLib.NumberOfBooks.ToString()} [n:{MyLib.NumberOfNewBooks}, a:{MyLib.NumberOfAnticBooks}]";
      lblReaded.Text = $"{MyLib.NumberOfReaded} [{MyLib.NumberOfReadedPercentage}%]";
      lblWanted.Text = $"{MyLib.NumberOfWantedBooks}";
      lblMyOldestBook.Text = $"{MyLib.MyOldestBook.CzechName} [{MyLib.MyOldestBook.MyPublicationDate}]";
      lblOldestBook.Text = $"{MyLib.OldestBook.CzechName} [{MyLib.OldestBook.OriginalPublicationDate}]";
      lblBestPublishers.Text = $"[{MyLib.BestPublishers.Substring(0, MyLib.BestPublishers.Length-2)}]";
    }
    #endregion
  }
}