<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="paymenttest.aspx.cs" Inherits="Trigger4.paymenttest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="NewPaymentForm" method="post" action="<%= braintreeGateway().TransparentRedirect.Url %>">
		<% if (TransactionSuccessful) { %>
			<h1>Thank you!</h1>
		<% } else { %>
            <p style="color:red;">Didnt work</p>
			<% if (ErrorMessage.Length > 0) { %>
			<p style="color:red;"><%= ErrorMessage %></p>
			<% } %>
			<input id="tr_data" name="tr_data" type="hidden" value="<%= TrData %>" />
			
			<p>
				<label>Credit Card Number</label>
				<input type="text" value="4111111111111111" name="transaction[credit_card][number]" />
			</p>
			
			<p>
				<label>Expiration Date</label>
				<input type="text" value="10/14" name="transaction[credit_card][expiration_date]" />
			</p>
			
			<input type="submit" value="Pay" />
		<% } %>
	</form>
</asp:Content>
