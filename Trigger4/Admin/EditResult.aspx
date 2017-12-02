<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="EditResult.aspx.cs" Inherits="Trigger4.Admin.EditResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newContent">
        <div style="margin:150px 0; padding-left:50px;">
        Company:
        <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
        <br />
        Triggers:
        <asp:TextBox ID="txtTriggers" runat="server"></asp:TextBox>
        <br />
        Date Searched:
        <asp:TextBox ID="txtDateSearched" runat="server" Enabled="False"></asp:TextBox>
        <br />
        Body Text:
        <asp:TextBox ID="txtBodyText" runat="server" Height="147px" OnTextChanged="TextBox4_TextChanged" TextMode="MultiLine" Width="696px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
    </div>
</asp:Content>
