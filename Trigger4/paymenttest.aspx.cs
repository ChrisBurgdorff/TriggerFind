using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Braintree;

namespace Trigger4
{
    public partial class paymenttest : System.Web.UI.Page
    {
        public String TrData;
        public Boolean TransactionSuccessful;
        public String ErrorMessage;

        public virtual void Page_Load(object sender, EventArgs args)
        {
            TransactionSuccessful = false;
            ErrorMessage = String.Empty;

            if (Request.Url.Query.Length > 0)
            {
                TransactionSuccessful = confirmTransparentRedirect();
                ErrorMessage = "Problem with your credit card number or expiration date.";
            }
            else
            {
                TrData = buildTransparentRedirectData();
            }
        }

        public String buildTransparentRedirectData()
        {
            var transactionRequest = new TransactionRequest
            {
                Amount = 10.00M
            };

            return braintreeGateway().Transaction.SaleTrData(transactionRequest, "http://localhost:8080/");
        }

        public Boolean confirmTransparentRedirect()
        {
            Result<Transaction> ChargeResult = braintreeGateway().TransparentRedirect.ConfirmTransaction(Request.Url.Query);
            return ChargeResult.IsSuccess();
        }

        public BraintreeGateway braintreeGateway()
        {
            return new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "k7t3hftq6yv6y56p",
                PublicKey = "hvrc6br8ktgtyz75",
                PrivateKey = "035a4aac2f074ced1c0d964975450809"
            };
        }
    }
}