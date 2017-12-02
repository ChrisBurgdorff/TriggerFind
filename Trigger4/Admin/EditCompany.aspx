<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="Trigger4.Admin.EditCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newContent">

        Name:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        Symbol:
        <asp:TextBox ID="txtSymbol" runat="server"></asp:TextBox>
        <br />
        Alternate Name:
        <asp:TextBox ID="txtAlternateName" runat="server"></asp:TextBox>
        <br />
        CEO:
        <asp:TextBox ID="txtCEO" runat="server"></asp:TextBox>
        <br />
        CFO:
        <asp:TextBox ID="txtCFO" runat="server"></asp:TextBox>
        <br />
        Industry:
        <asp:TextBox ID="txtIndustry" runat="server"></asp:TextBox>
        <br />
        Industry 2:
        <asp:TextBox ID="txtIndustry2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>

    </div>
</asp:Content>
