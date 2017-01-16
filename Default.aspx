<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="martinhromek.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--content content content content content content--%>
    <div id="makeMeScrollable">
        <div class="scrollingHotSpotLeft" style="display: none;"></div>
        <div class="scrollingHotSpotRight"></div>
        <div class="scrollWrapper">
            <div class="scrollableArea">

                <img src="pic/welcome/pic01.jpg" />
                <img src="pic/welcome/pic02.jpg" />
                <img src="pic/welcome/pic18.jpg" />
                <img src="pic/welcome/pic03.jpg" />
                <img src="pic/welcome/pic04.jpg" />
                <img src="pic/welcome/pic05.jpg" />
                <img src="pic/welcome/pic06.jpg" />
                <img src="pic/welcome/pic07.jpg" />
                <img src="pic/welcome/pic08.jpg" />
                <img src="pic/welcome/pic09.jpg" />
                <img src="pic/welcome/pic10.jpg" />
                <img src="pic/welcome/pic11.jpg" />
                <img src="pic/welcome/pic12.jpg" />
                <img src="pic/welcome/pic13.jpg" />
                <img src="pic/welcome/pic14.jpg" />
                <img src="pic/welcome/pic15.jpg" />
                <img src="pic/welcome/pic16.jpg" />
                <img src="pic/welcome/pic19.jpg" />
                <img src="pic/welcome/pic20.jpg" />
                <img src="pic/welcome/pic21.jpg" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(window).load(function () {
            $("div#makeMeScrollable").smoothDivScroll({
                autoScroll: "onstart",
                autoScrollDirection: "backandforth",
                autoScrollStep: 1,
                autoScrollInterval: 15,
                startAtElementId: "startAtMe",
                visibleHotSpots: "always",
                scrollToEasingFunction: "easeOutBounce"
            });
        });
    </script>

</asp:Content>
