<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="martinhromek.bitcoin.Stock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BCT | Stock Exchange</title>
    <link href="../styles/bitcoin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <img src="../pic/btc.png" alt="bitcoin logo" height="100px" />
        </header>

        <section id="main">
            <asp:Label runat="server" ID="lblExchange" Text ="---" />
        </section>

        <footer>hromek@hotmail.cz | 2017</footer>
    </form>
</body>
</html>
