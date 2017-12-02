<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="Trigger4.Companies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
      <div id="topLeft"><h2 class="leftText">Trigger Find</h2></div>
  <div id="headline"><div class="leftSide"><h1 class="headText">Add or delete your Companies.</h1></div>
  <div class="rightSide"><ul><a href="Settings.aspx"><li class="settingsLi"><img src="Images/Gear.svg" class="icon"></li></a><li>
      <asp:Literal ID="litUsername" runat="server" Visible="False"></asp:Literal><asp:LinkButton ID="lnkSignout" runat="server" CssClass="clickable" OnClick="lnkSignout_Click">Sign Out</asp:LinkButton><img src="Images/user.svg"class="icon"></li></ul></div>
    </div>
    <div class="clearFix"></div>
  <div class="wrapper">
    <div class="fullMenu">
        <ul id="menuList">
          <a href="Home.aspx"><li class="aboveSelected">Home</li></a>
          <a href="#"><li class="selected">My Companies</li></a>
          <a href="Triggers.aspx"><li>My Triggers</li></a>
          <a href="Alerts.aspx"><li>All Alerts</li></a>
        </ul>
    </div>
    <div id="newContent">
        <div id="topBar">
            <h1 class="headText">My Companies</h1>
            <ul>
                <asp:Literal ID="litComp" runat="server"></asp:Literal>
            </ul>
            <hr />
            <h1 class="headText">Add Company</h1>
            <asp:TextBox ID="txtComp" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
            <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn" OnClick="btnAdd_Click" />
        </div>
    </div>
    <div class="clearFix"></div>
  </div>
</asp:Content>
