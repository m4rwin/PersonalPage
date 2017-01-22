<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="martinhromek.library.AddBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Add new book</title>
    <link href="../styles/library.css" rel="stylesheet" type="text/css" />
    <style>
        .TextBox {
            height: 10px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div style="font-size: smaller">

            <center>        
            <h4>Add Book</h4>
            <a href="Home.aspx">
            <figure><img src="../pic/home.png" alt="home" height="25px"/></figure>    
            </a>

            <asp:Panel ID="MainPanel" runat="server">
                <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="0" GridLines="None">
                    
                        <asp:TableRow>
                            <asp:TableCell>Autor</asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txbFirstName" runat="server" ToolTip="First Name" Width="100" />
                                <asp:TextBox ID="txbMiddleName" runat="server" ToolTip="Middle Name" Width="100" />
                                <asp:TextBox ID="txbLastName" runat="server" ToolTip="Last Name" Width="100" />
                            </asp:TableCell>
                        
                            <asp:TableCell>
                                <asp:DropDownList ID="ddAuthorCollection" runat="server" OnSelectedIndexChanged="ddAuthorCoolection_SelectedIndexChanged" AutoPostBack="true" Width="150" />
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Český název</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:TextBox ID="txbCzechName" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Originální název</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:TextBox ID="txbOriginalName" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>1. vydání</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:TextBox ID="txbDatePublish" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Moje vydání</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:TextBox ID="txbDatePublishMy" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Vydavatel</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txbPublisher" runat="server"></asp:TextBox></asp:TableCell>
                            <asp:TableCell><asp:DropDownList ID="ddPublisherCollection" runat="server" OnSelectedIndexChanged="ddPublisherCollection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Typ</asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                <asp:DropDownList ID="ddType" runat="server" OnLoad="ddType_Load"/>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Žánr</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:ListBox ID="lbGenre" runat="server" Height="120" SelectionMode="Multiple" OnLoad="lbGenre_Load"/></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Skupina</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:DropDownList ID="ddGroup" runat="server" SelectionMode="Single" OnLoad="ddGroup_Load" /></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Přečteno</asp:TableCell>
                            <asp:TableCell ColumnSpan="2">
                                <asp:DropDownList ID="ddReaded" runat="server">
                                    <asp:ListItem>ne</asp:ListItem>
                                    <asp:ListItem>ano</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Datum přečtení</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:TextBox ID="txbDateRead" runat="server"></asp:TextBox></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell RowSpan="2">Hodnocení</asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txbRating" runat="server" Width="100%"></asp:TextBox></asp:TableCell>
                            <asp:TableCell HorizontalAlign="Right"><asp:TextBox runat="server" ID="txbRatingValue" Width="20"/>%</asp:TableCell>
                        </asp:TableRow>

                    <asp:TableRow></asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell>Obálka</asp:TableCell>
                            <asp:TableCell ColumnSpan="2"><asp:FileUpload ID="fileCover" runat="server"></asp:FileUpload></asp:TableCell>
                        </asp:TableRow>


                    
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                                <asp:Label Text="..." ID="lblInfo" runat="server"/>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button>
                            </asp:TableCell>
                        </asp:TableRow>
            
                    </asp:Table>
            </asp:Panel>
        </center>
        </div>
    </form>
</body>
</html>
