<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" ValidateRequest="false" Inherits="Trigger4.Admin.AddPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  style="padding: 120px 20px">
        <asp:Button ID="btnViewPosts" runat="server" CssClass="btn" OnClick="btnViewPosts_Click" Text="View Posts" />
        <br />
    Title: <asp:TextBox ID="txtTitle" runat="server" Width="500px"></asp:TextBox>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    <br />
    Post:
        <br />
        <asp:TextBox ID="txtBody" runat="server" Height="326px" TextMode="MultiLine" Width="1108px"></asp:TextBox>
        <br />
        Tags: 
        <asp:TextBox ID="txtTags" runat="server" Width="571px"></asp:TextBox>
        <asp:Label ID="lblSpaces" runat="server" Text="Put Spaces Between Tags"></asp:Label>
        <asp:Label ID="lblTagResult" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblTagResult2" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:CheckBox ID="chkDraft" runat="server" Text="Save As Draft" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Post" CssClass="btn" style="padding-bottom:60px" OnClick="btnSubmit_Click" />
        </div>
</asp:Content>
