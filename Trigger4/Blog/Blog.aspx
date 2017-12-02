<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="Trigger4.Blog.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!--start Contact Form-->
        <div id="contactBox" class="popup">
        <div id="contactWrapper">
            <div id="contactContainer">
                <img src="http://www.triggerfind.com/images/x.png" id="closeContact">
                <h2>We Want To Hear From You</h2>
                <br>
                <p>Email: <a href="mailto:contact@triggerfind.com">Contact@TriggerFind.com</a></p>
                <br>
                    <p>Email Address:</p>
                    <asp:TextBox ID="txtEmailContact" runat="server" Width="200px"></asp:TextBox>
                    <br>
                    <p>Message:</p>
                    <asp:TextBox ID="txtMessageContact" runat="server" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    <br>
                    <asp:Button ID="btnSubmitContact" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmitContact_Click" />
                    <br>
                    <asp:Label ID="lblSuccessContact" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
    <!--End Contact Form -->
    <asp:Panel ID="pnlPosts" runat="server">
    </asp:Panel>
    <asp:Panel ID="pnlSidebar" runat="server"></asp:Panel>
    <div class="blogAds">
    <div class ="blogAd" style="float: left">
            <a href="http://www.shareasale.com/m-pr.cfm?merchantID=44228&userID=156535&productID=511491375" target="_blank"><img alt="" src="http://magazinevalues.com/images/1665.jpg" border="0"></a>
        </div>
        <div class ="blogAd" style="float:right">
            <a target="_blank" href="http://shareasale.com/r.cfm?b=488695&amp;u=156535&amp;m=43524&amp;urllink=&amp;afftrack="><img src="http://static.shareasale.com/image/43524/bt25.jpg" border="0" alt="Brian Tracy Sales Management" height="250px" width="250px"/></a>
        </div>
        <div class ="blogAd">
        <a href="http://whatshouldibuy.com"><img src="http://www.whatshouldibuy.com/images/bannersquare.jpg"></a>
        </div>
        </div>
</asp:Content>
