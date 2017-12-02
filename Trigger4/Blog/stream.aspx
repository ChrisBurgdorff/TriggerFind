<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="stream.aspx.cs" Inherits="Trigger4.Blog.stream" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <br />
    <asp:Button ID="btnCreateFile" runat="server" Text="Create File" OnClick="btnCreateFile_Click" />
        <br />
    <asp:Button ID="btnOverwriteFile" runat="server" Text="Overwrite File" OnClick="btnOverwriteFile_Click" />
        <br />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Blog/testa.html">InDir</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/testa.html">inroot</asp:LinkButton>
        </div>
</asp:Content>
