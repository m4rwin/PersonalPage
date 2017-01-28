<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="martinhromek.library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Library</title>
    <link href="../styles/library.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
 
        <div id="pagewrap">
	        <header>
		            <b>M<a href="AddBook.aspx">y</a> Library</b>
                    <br />
                    <asp:LinkButton ID="btnSwitchLanguage" runat="server" Text="[lang]" Font-Italic="true" OnClick="btnChangeLanguage_Click"/>
                    <asp:HyperLink runat="server" Text="[backup]" Font-Italic="true" NavigateUrl="~/library/storage.xml" Target="_blank" />
	        </header>
		
            <section id="info">
                <asp:Table runat="server" GridLines="None">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Left">
                            Knih: <asp:Label runat="server" ID="lblNoOfBooks" Text="-"/> |
                            Přečteno: <asp:Label runat="server" ID="lblReaded" Text="-" /> |
                            Chci: <asp:Label runat="server" ID="lblWanted" Text="-" /> |
                            Nakladatelé: <asp:Label runat="server" ID="lblBestPublishers" Text="-" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Left">
                            Moje nejstarší kniha: <asp:Label runat="server" ID="lblMyOldestBook" Text="-"/> |
                            Původní nejstarší kniha: 
                        <asp:Label runat="server" ID="lblOldestBook" Text="-" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </section>
            
            <section id="middle">
            </section>
            
            <section id="content">
                <asp:Panel ID="MainPanel" runat="server"/>
            </section>
	       
	
	        <footer>
		        <asp:Label ID="lblLastUpdate" Text="-" runat="server" Font-Italic="true" />
	        </footer>

        </div>
    </form>
</body>
</html>
