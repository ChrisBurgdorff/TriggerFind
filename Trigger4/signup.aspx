<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Trigger4.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="topline"><a href="TF.aspx"><img class="logo" src="http://www.whatshouldibuyfor.com/images/tflogocolor3.png"><h2>Trigger Find</h2></a>
  <div class="right">
  </div>
</div>
<div id="signupLanding">
            <h1>Select Account Type</h1>
            <h1>Up to 20 Companies: $9/month or Up to 50 Companies: $19/month<h1>
            <h1>Select and Click Subscribe Now</h1>
              <div id="paypalForm">
            <form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
            <input type="hidden" name="cmd" value="_s-xclick">
            <input type="hidden" name="hosted_button_id" value="R7CSWMXHMW9Q6">
            <table>
            <tr><td><input type="hidden" name="on0" value=""></td></tr><tr><td><select name="os0">
	            <option value="Follow 20 Companies">Follow 20 Companies : $9.00 USD - monthly</option>
	            <option value="Follow 50 Companies">Follow 50 Companies : $19.00 USD - monthly</option>
            </select> </td></tr>
            </table>
            <input type="hidden" name="currency_code" value="USD">
            <input type="image" src="https://www.paypalobjects.com/en_US/i/btn/btn_subscribeCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
            <img alt="" border="0" src="https://www.paypalobjects.com/en_US/i/scr/pixel.gif" width="1" height="1">
            </form>
            </div>
            <h2>You will be redirected to Paypal</h2>
            <h2>Or Follow Up To 8 Companies For Free:</h2>
            <a href="Home.aspx"><h2>Continue With Free Account</h2></a>
</div>
<div class="clearFix"></div>
</asp:Content>
