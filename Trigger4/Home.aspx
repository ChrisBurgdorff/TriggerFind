<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Trigger4.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div id="topLeft"><h2 class="leftText">Trigger Find</h2></div>
  <div id="headline"><div class="leftSide"><h1 class="headText">Welcome <asp:Literal ID="litFName" runat="server"></asp:Literal>, You Have <a href="#">
      <asp:Literal ID="litNewAlerts" runat="server"></asp:Literal></a></h1></div>
  <div class="rightSide"><ul><li class="settingsLi"><a href="Settings.aspx"><img src="Images/Gear.svg" class="icon"></a></li><li>
      <asp:LinkButton ID="lnkSignout" runat="server" Enabled="True" OnClick="lnkSignout_Click" Visible="True" CssClass="clickable">Sign Out</asp:LinkButton><img src="Images/user.svg"class="icon"></li></ul></div>
    </div>
    <div class="clearFix"></div>
  <div class="wrapper">
    <div class="fullMenu">
        <ul id="menuList">
          <a href="#"><li class="selected">Home</li></a>
          <a href="Companies.aspx"><li>My Companies</li></a>
          <a href="Triggers.aspx"><li>My Triggers</li></a>
          <a href="Alerts.aspx"><li>All Alerts</li></a>
          <a href="#"><li>NEW SHIT</li></a>
        </ul>
    </div>
    <div id="newContent">
        <div id="topBar">
            <asp:Literal ID="litMain" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="clearFix"></div>
  </div>
</asp:Content>
