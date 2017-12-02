<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="TF.aspx.cs" Inherits="Trigger4.TF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="topline"><img class="logo" src="http://www.whatshouldibuyfor.com/images/tflogocolor3.png"><h2>Trigger Find</h2>
      <asp:Button ID="btnBlog" runat="server" Text="Blog" CssClass="btnBlog" OnClick="btnBlog_Click" />
  <div class="right">
      <asp:Literal ID="litStatusLogin" runat="server"></asp:Literal>
            <asp:TextBox ID="txtUserLogin" runat="server" CssClass="textTop" placeholder="User Name"></asp:TextBox>
            <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password" CssClass="textTop" placeholder="Password"></asp:TextBox>
            <asp:Button ID="login" runat="server" Text="Login" CssClass="btnTop" OnClick="login_Click" />
  </div>
</div>
<div id="content">
  <header>
    <div class="point">        
    <h1>The Business News You Need</h1>
            <h2 class="mobileHidden">Choose Which Companies To Follow And Get Alerts Only For The Events You Choose.</h2>
    </div>
           </header>
        <div id="registerDiv">
          <div class="left">
        <h1>Sign Up Today</h1>
          <h2>It's Free</h2>
        <h2>
            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
            </h2></div>
          <div class="right moveDown">
              <p>
                  <asp:TextBox ID="txtEmail" runat="server" CssClass="textBox" placeholder ="Email"></asp:TextBox></p>
        <p>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textBox" placeholder="User Name"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textBox" placeholder="Password"></asp:TextBox>
        </p>
        <p>
          <asp:Button ID="register" runat="server" Text="Sign Up" CssClass="btn" OnClick="register_Click" />
        </p>
          </div>
          <div class="clearFix"></div>
        </div>
           <div id="alertDisplay">
             <div class="point">
            <h1>Custom Alerts For The Sales Triggers You Care About</h1>
               <ul>
                 <li><img class="icon2" src="http://www.whatshouldibuyfor.com/images/progress.svg"><h2>Sales Growth</h2></li>
                 <li><img class="icon2" src="http://www.whatshouldibuyfor.com/images/handshake.svg"><h2>Mergers</h2></li>
                 <li><img class="icon2" src="http://www.whatshouldibuyfor.com/images/contract.svg"><h2>New Contracts</h2></li>
                 <li><img class="icon2" src="http://www.whatshouldibuyfor.com/images/hiring2.svg"><h2>Growing Workforce</h2></li>
                 <li><h2>And More</h2></li>
               </ul>
             </div>
          </div>
        <div class="breakDiv">
          <div class="newPoint">
              <h2 class="works">Download Our Mobile App</h2>
              <asp:Button ID="btnMobileDownload" runat="server" Text="Download For Android" CssClass="btn" OnClick="btnMobileDownload_Click" />
            <h2 id="works">How It Works</h2>
            <p>In a world of over-complicated, overly detailed technology….TriggerFind makes a tool that is fast and easy to use!p>
            <p>First, create your account by submitting your Email, User Name and Password</p>
            <p><i>Hint – Name and Password can only contain letters and numbers…no spaces and no symbols</i></p>
 
            <p>Next, click the “My Companies” tab and start selecting the companies you want to follow.</p>
            <p><i>Hint - Be sure to enter the company name the way it’s most widely recognized in the media...and make sure you include the FULL company name if their “common” name can pertain to more than one entity.  ( Example – you want to choose “Marvel Entertainment” instead of just “Marvel”.  )</i></p>
 
            <p>Lastly, click the “My Triggers” tab, and select the sales triggers that matter to you. These are the types of news categories that matter to you when you are prospecting.  </p>
            <p><i>Hint – <a href="/triggerblog/">check out our blog</a> and read about WHY you should care about news triggers, and how each of the 7 we selected can be used in your favor when speaking with a customer or prospect.</i></p>
 
            <h2>That’s all there is to it!</h2>
 
            <p>TriggerFind will bring you the most relevant news about the companies you selected twice a day (once around 8:00 AM EST and again about 2:00 PM EST).  When you check the tab called “All Alerts” you’ll see the most recent results there!  Armed with this up-to-date information, you can call upon companies and talk intelligently about what is happening in their universe…and how you can best serve them!</p>
            <h2><a href="#registerDiv">Create An Account</a></h2>
            <h2><a href="/triggerblog/">Visit Our Blog</a></h2>
          </div>
        </div>
        <div class="clearFix"></div>
    </div>
</asp:Content>
