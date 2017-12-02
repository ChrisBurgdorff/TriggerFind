<%@ Page Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="ViewPosts.aspx.cs" Inherits="Trigger4.Admin.ViewPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  style="padding: 120px 20px">
    <asp:Button ID="btnNewPost" runat="server" Text="Create New Post" CssClass="btn" OnClick="btnNewPost_Click" PostBackUrl="~/Admin/AddPost.aspx" />
    <asp:Button ID="btnEmailList" runat="server" CssClass="btn" OnClick="btnEmailList_Click" Text="Email List" />
        <asp:Button ID="btnUsers" runat="server" CssClass="btn" OnClick="btnUsers_Click" Text="Manage Users" />
        <asp:Button ID="btnFindResults" runat="server" CssClass="btn" OnClick="btnFindResults_Click" Text="Find Results" />
        <asp:Button ID="btnManageResults" runat="server" Text="Manage Results" CssClass="btn" OnClick="btnManageResults_Click" />
    <asp:GridView ID="GridViewPosts" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="15" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" CellSpacing="5" HorizontalAlign="Center" Width="1400px" OnSelectedIndexChanged="GridViewPosts_SelectedIndexChanged" onrowediting="GridViewPosts_RowEditing">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" HeaderStyle-Width="50px"/>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" HeaderStyle-Width="600px"/>
            <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime" HeaderStyle-Width="200px"/>
            <asp:BoundField DataField="Tags" HeaderText="Tags" SortExpression="Tags" HeaderStyle-Width="300px" />
            <asp:BoundField DataField="IsDraft" HeaderText="IsDraft" SortExpression="IsDraft" HeaderStyle-Width="100px"/>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:triggerDBConnectionString %>" DeleteCommand="DELETE FROM [Posts] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Posts] ([Title], [DateTime], [Tags], [IsDraft]) VALUES (@Title, @DateTime, @Tags, @IsDraft)" SelectCommand="SELECT [ID], [Title], [DateTime], [Tags], [IsDraft] FROM [Posts] ORDER BY [DateTime] DESC" UpdateCommand="UPDATE [Posts] SET [Title] = @Title, [DateTime] = @DateTime, [Tags] = @Tags, [IsDraft] = @IsDraft WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateTime" Type="DateTime" />
            <asp:Parameter Name="Tags" Type="String" />
            <asp:Parameter Name="IsDraft" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="DateTime" Type="DateTime" />
            <asp:Parameter Name="Tags" Type="String" />
            <asp:Parameter Name="IsDraft" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
        </div>
</asp:Content>
