<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Trigger4.Admin.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newContent">
        <div style="margin:150px 0; padding-left:50px;">

        GUI:
        <asp:TextBox ID="txtGUI" runat="server" Enabled="False" Width="261px"></asp:TextBox>
        <br />
        User Name:
        <asp:TextBox ID="txtUserName" runat="server" Width="186px"></asp:TextBox>
        <br />
        First Name:
        <asp:TextBox ID="txtFirstName" runat="server" Width="193px"></asp:TextBox>
        <br />
        Last Name:
        <asp:TextBox ID="txtLastName" runat="server" Width="192px"></asp:TextBox>
        <br />
        Companies:
        <asp:TextBox ID="txtCompanies" runat="server" style="margin-right: 0px" Width="181px"></asp:TextBox>
        <br />
        Triggers:
        <asp:TextBox ID="txtTriggers" runat="server" Width="218px"></asp:TextBox>
        <br />
        Email:
        <asp:TextBox ID="txtEmail" runat="server" Width="246px"></asp:TextBox>
        <br />
        Account Type:
        <asp:TextBox ID="txtAccountType" runat="server" Width="155px"></asp:TextBox>
        <br />
        Start Date:
        <asp:TextBox ID="txtStartDate" runat="server" Enabled="False" Width="204px"></asp:TextBox>
        <br />
        Billing Cycle:
        <asp:TextBox ID="txtBillingCycle" runat="server" Width="183px"></asp:TextBox>
        <br />
        Last Login:
        <asp:TextBox ID="txtLastLogin" runat="server" Enabled="False" Width="215px"></asp:TextBox>
        <br />
        Newsletter:
        <asp:TextBox ID="txtNewsletter" runat="server" Width="207px"></asp:TextBox>
        <br />
        Results:
        <asp:TextBox ID="txtResults" runat="server" Width="257px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" Text="Submit" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
    </div>
</asp:Content>
