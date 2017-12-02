<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Trigger4.Admin.ManageUsers" %>
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
        <h1>Users</h1>
        <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" AllowPaging="True" AllowSorting="True" OnRowEditing="grdUsers_RowEditing" CssClass="mydatagrid">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="GUI" HeaderText="GUI" SortExpression="GUI" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Companies" HeaderText="Companies" SortExpression="Companies" />
                <asp:BoundField DataField="Triggers" HeaderText="Triggers" SortExpression="Triggers" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="AccountType" HeaderText="AccountType" SortExpression="AccountType" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                <asp:BoundField DataField="BillingCycle" HeaderText="BillingCycle" SortExpression="BillingCycle" />
                <asp:BoundField DataField="LastLogin" HeaderText="LastLogin" SortExpression="LastLogin" />
                <asp:BoundField DataField="Newsletter" HeaderText="Newsletter" SortExpression="Newsletter" />
                <asp:BoundField DataField="Results" HeaderText="Results" SortExpression="Results" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TriggerDBConnectionString2 %>" DeleteCommand="DELETE FROM [MyUser] WHERE [ID] = @ID" InsertCommand="INSERT INTO [MyUser] ([GUI], [UserName], [FirstName], [LastName], [Companies], [Triggers], [Email], [AccountType], [StartDate], [BillingCycle], [LastLogin], [Newsletter], [Results]) VALUES (@GUI, @UserName, @FirstName, @LastName, @Companies, @Triggers, @Email, @AccountType, @StartDate, @BillingCycle, @LastLogin, @Newsletter, @Results)" SelectCommand="SELECT * FROM [MyUser] ORDER BY [StartDate], [ID]" UpdateCommand="UPDATE [MyUser] SET [GUI] = @GUI, [UserName] = @UserName, [FirstName] = @FirstName, [LastName] = @LastName, [Companies] = @Companies, [Triggers] = @Triggers, [Email] = @Email, [AccountType] = @AccountType, [StartDate] = @StartDate, [BillingCycle] = @BillingCycle, [LastLogin] = @LastLogin, [Newsletter] = @Newsletter, [Results] = @Results WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="GUI" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Companies" Type="String" />
                <asp:Parameter Name="Triggers" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="AccountType" Type="Int32" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="BillingCycle" Type="Int32" />
                <asp:Parameter Name="LastLogin" Type="DateTime" />
                <asp:Parameter Name="Newsletter" Type="String" />
                <asp:Parameter Name="Results" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="GUI" Type="String" />
                <asp:Parameter Name="UserName" Type="String" />
                <asp:Parameter Name="FirstName" Type="String" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Companies" Type="String" />
                <asp:Parameter Name="Triggers" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="AccountType" Type="Int32" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="BillingCycle" Type="Int32" />
                <asp:Parameter Name="LastLogin" Type="DateTime" />
                <asp:Parameter Name="Newsletter" Type="String" />
                <asp:Parameter Name="Results" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <h1>Compaines</h1>
        <asp:GridView ID="grdCompanies" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" DataSourceID="SqlDataSource3" ForeColor="Black" OnRowEditing="grdCompanies_RowEditing" CssClass="mydatagrid">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Symbol" HeaderText="Symbol" SortExpression="Symbol" />
                <asp:BoundField DataField="AlternateName" HeaderText="AlternateName" SortExpression="AlternateName" />
                <asp:BoundField DataField="CEO" HeaderText="CEO" SortExpression="CEO" />
                <asp:BoundField DataField="CFO" HeaderText="CFO" SortExpression="CFO" />
                <asp:BoundField DataField="Industry" HeaderText="Industry" SortExpression="Industry" />
                <asp:BoundField DataField="Industry2" HeaderText="Industry2" SortExpression="Industry2" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:TriggerDBConnectionString2 %>" DeleteCommand="DELETE FROM [Company] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Company] ([Name], [Symbol], [AlternateName], [CEO], [CFO], [Industry], [Industry2]) VALUES (@Name, @Symbol, @AlternateName, @CEO, @CFO, @Industry, @Industry2)" SelectCommand="SELECT * FROM [Company] ORDER BY [Name], [ID]" UpdateCommand="UPDATE [Company] SET [Name] = @Name, [Symbol] = @Symbol, [AlternateName] = @AlternateName, [CEO] = @CEO, [CFO] = @CFO, [Industry] = @Industry, [Industry2] = @Industry2 WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Symbol" Type="String" />
                <asp:Parameter Name="AlternateName" Type="String" />
                <asp:Parameter Name="CEO" Type="String" />
                <asp:Parameter Name="CFO" Type="String" />
                <asp:Parameter Name="Industry" Type="String" />
                <asp:Parameter Name="Industry2" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Symbol" Type="String" />
                <asp:Parameter Name="AlternateName" Type="String" />
                <asp:Parameter Name="CEO" Type="String" />
                <asp:Parameter Name="CFO" Type="String" />
                <asp:Parameter Name="Industry" Type="String" />
                <asp:Parameter Name="Industry2" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <h1>Results</h1>
        <asp:GridView ID="grdResults" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="Black" OnRowEditing="grdResults_RowEditing" CssClass="mydatagrid">
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Company" HeaderText="Company" SortExpression="Company" />
                <asp:BoundField DataField="Triggers" HeaderText="Triggers" SortExpression="Triggers" />
                <asp:BoundField DataField="DateSearched" HeaderText="DateSearched" SortExpression="DateSearched" />
                <asp:BoundField DataField="BodyText" HeaderText="BodyText" SortExpression="BodyText" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" BorderStyle="Solid" BorderWidth="1px" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TriggerDBConnectionString2 %>" DeleteCommand="DELETE FROM [Result] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Result] ([Company], [Triggers], [DateSearched], [BodyText]) VALUES (@Company, @Triggers, @DateSearched, @BodyText)" SelectCommand="SELECT * FROM [Result] ORDER BY [ID], [Company]" UpdateCommand="UPDATE [Result] SET [Company] = @Company, [Triggers] = @Triggers, [DateSearched] = @DateSearched, [BodyText] = @BodyText WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Company" Type="String" />
                <asp:Parameter Name="Triggers" Type="String" />
                <asp:Parameter Name="DateSearched" Type="DateTime" />
                <asp:Parameter Name="BodyText" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Company" Type="String" />
                <asp:Parameter Name="Triggers" Type="String" />
                <asp:Parameter Name="DateSearched" Type="DateTime" />
                <asp:Parameter Name="BodyText" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
            </div>
        </div>
</asp:Content>
