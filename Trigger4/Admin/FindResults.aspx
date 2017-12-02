<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="FindResults.aspx.cs" Inherits="Trigger4.Admin.FindResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newContent">
        <div style="margin:150px 0; padding-left:50px;">
        <asp:Button ID="btnFindAll" runat="server" Text="Find All" CssClass="btn" OnClick="btnFindAll_Click" />
        <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        <br />
        <asp:Literal ID="litFinalStatus" runat="server"></asp:Literal>
            </div>
    </div>
</asp:Content>
