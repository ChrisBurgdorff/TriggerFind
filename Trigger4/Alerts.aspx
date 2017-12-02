<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Alerts.aspx.cs" Inherits="Trigger4.Alerts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="topLeft"><h2 class="leftText">Trigger Find</h2></div>
  <div id="headline"><div class="leftSide"><h1 class="headText">All Alerts</h1></div>
  <div class="rightSide"><ul><a href="Settings.aspx"><li class="settingsLi"><img src="Images/Gear.svg" class="icon"></li></a><li>
      <asp:Literal ID="litUsername" runat="server" Visible="False"></asp:Literal><asp:LinkButton ID="lnkSignout" runat="server" CssClass="clickable" OnClick="lnkSignout_Click">Sign Out</asp:LinkButton><img src="Images/user.svg"class="icon"></li></ul></div>
    </div>
    <div class="clearFix"></div>
  <div class="wrapper">
    <div class="fullMenu">
        <ul id="menuList">
          <a href="Home.aspx"><li>Home</li></a>
          <a href="Companies.aspx"><li>My Companies</li></a>
          <a href="Triggers.aspx"><li class="aboveSelected">My Triggers</li></a>
          <a href="#"><li class="selected">All Alerts</li></a>
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
