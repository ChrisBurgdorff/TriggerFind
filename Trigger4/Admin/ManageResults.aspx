<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="ManageResults.aspx.cs" Inherits="Trigger4.Admin.ManageResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newContent">
        <style>
            body {
                font-size: 0.8em;
            }
        </style>
        <div style="margin:150px 0; padding-left:50px;">

            <asp:Label ID="lblNumResults" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnDisplayAll" runat="server" CssClass="btn" OnClick="btnDisplayAll_Click" Text="Display All Alerts" />
            <br />
            <asp:Button ID="btnDeleteDuplicates" runat="server" CssClass="btn" OnClick="btnDeleteDuplicates_Click" Text="Delete Duplicates" />
            <br />
            <asp:Button ID="btnDeleteBlank" runat="server" CssClass="btn" OnClick="btnDeleteBlank_Click" Text="Delete Blank" />
            <br />
            <asp:Button ID="btnDeleteDays" runat="server" CssClass="btn" OnClick="btnDeleteDays_Click" Text="Delete from x days back" />
            <asp:TextBox ID="txtDays" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
            <br />
            <asp:Literal ID="litMain" runat="server"></asp:Literal>

            </div>
        </div>
</asp:Content>
