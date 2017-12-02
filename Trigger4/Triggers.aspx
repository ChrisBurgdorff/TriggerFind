<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Triggers.aspx.cs" Inherits="Trigger4.Triggers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
   <div id="topLeft"><h2 class="leftText">Trigger Find</h2></div>
  <div id="headline"><div class="leftSide"><h1 class="headText">Add or delete your Triggers.</h1></div>
  <div class="rightSide"><ul><a href="Settings.aspx"><li class="settingsLi"><img src="Images/Gear.svg" class="icon"></li></a><li>
      <asp:Literal ID="litUsername" runat="server" Visible="False"></asp:Literal><asp:LinkButton ID="lnkSignout" runat="server" CssClass="clickable" OnClick="lnkSignout_Click">Signout</asp:LinkButton><img src="Images/user.svg"class="icon"></li></ul></div>
    </div>
    <div class="clearFix"></div>
  <div class="wrapper">
    <div class="fullMenu">
        <ul id="menuList">
          <a href="Home.aspx"><li>Home</li></a>
          <a href="Companies.aspx"><li class="aboveSelected">My Companies</li></a>
          <a href="#"><li class="selected">My Triggers</li></a>
          <a href="Alerts.aspx"><li>All Alerts</li></a>
        </ul>
    </div>
    <div id="newContent">
        <div id="topBar">
            <h1 class="headText">My Triggers</h1>
            <ul>
                <asp:Literal ID="litTrig" runat="server"></asp:Literal>
            </ul>
            <hr class="norm" />
            <h1 class="headText">Add Triggers</h1>
            <asp:Button ID="btnHiring" runat="server" Text="Hiring" CssClass="btn hiring" OnClick="btnHiring_Click" PostBackUrl="~/Triggers.aspx" />
            <asp:Button ID="btnMerger" runat="server" Text="Merger/Acquisition" CssClass="btn merger" OnClick="btnMerger_Click" />
            <asp:Button ID="btnSales" runat="server" Text="Sales Growth" CssClass="btn sales" OnClick="btnSales_Click" />
            <asp:Button ID="btnContracts" runat="server" Text="Contracts" CssClass="btn contracts" OnClick="btnContracts_Click" />
            <asp:Button ID="btnTraining" runat="server" Text="Training" CssClass="btn training" OnClick="btnTraining_Click" />
            <asp:Button ID="btnLocation" runat="server" Text="New Office/Location" CssClass="btn location" OnClick="btnLocation_Click" />
            <asp:Button ID="btnCFO" runat="server" Text="CFO Leaving" CssClass="btn cfo" OnClick="btnCFO_Click" />
    </div>
        </div>
    <div class="clearFix"></div>
      </div>
</asp:Content>
