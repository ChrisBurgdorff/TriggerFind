<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Trigger4.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="topLeft"><h2 class="leftText">Trigger Find</h2></div>
  <div id="headline"><div class="leftSide"><h1 class="headText">Settings</h1></div>
  <div class="rightSide"><ul><a href="Settings.aspx"><li class="settingsLi"><img src="Images/Gear.svg" class="icon"></li></a><li>
      <asp:Literal ID="litUsername" runat="server" Visible="False"></asp:Literal><asp:LinkButton ID="lnkSignout" runat="server" Enabled="True" OnClick="lnkSignout_Click" Visible="True" CssClass="clickable">Sign Out</asp:LinkButton><img src="Images/user.svg"class="icon"></li></ul></div>
    </div>
    <div class="clearFix"></div>
  <div class="wrapper">
    <div class="fullMenu">
        <ul id="menuList">
          <a href="Home.aspx"><li>Home</li></a>
          <a href="Companies.aspx"><li>My Companies</li></a>
          <a href="Triggers.aspx"><li>My Triggers</li></a>
          <a href="Alerts.aspx"><li>All Alerts</li></a>
        </ul>
    </div>
    <div id="newContent">
        <div id="topBar">
            <h2>First Name:</h2>
        <p>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        <h2>Last Name:</h2>
        <p>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
        <h2>Email:</h2>
        <p>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox"></asp:TextBox>
        </p>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" OnClick="btnUpdate_Click" />
            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="clearFix"></div>
  </div>
</asp:Content>
