<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Trigger.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Trigger4.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>
    <!--start Contact Form-->
        <div id="contactBox" class="popup">
        <div id="contactWrapper">
            <div id="contactContainer">
                <img src="http://www.triggerfind.com/images/x.png" id="closeContact">
                <h2>We Want To Hear From You</h2>
                <br>
                <p>Email: <a href="mailto:contact@triggerfind.com">Contact@TriggerFind.com</a></p>
                <br>
                    <p>Email Address:</p>
                    <asp:TextBox ID="txtEmailContact" runat="server" Width="200px"></asp:TextBox>
                    <br>
                    <p>Message:</p>
                    <asp:TextBox ID="txtMessageContact" runat="server" TextMode="MultiLine" Height="50px" Width="200px"></asp:TextBox>
                    <br>
                    <asp:Button ID="btnSubmitContact" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmitContact_Click" />
                    <br>
                    <asp:Label ID="lblSuccessContact" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
    <!--End Contact Form -->
    <div id="content">
        <div id="landing">
            <table id="landingTablePhone">
                <tr>
                    <td>
                        <a href="#steps"><img src="http://www.triggerfind.com/images/mag_glassblack.png"></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Find The News YOU Need About YOUR Customers</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="http://www.triggerfind.com/images/bbellblack.png">
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Custom Alerts - Be The First To Know (Coming Soon)</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="http://www.triggerfind.com/images/moneyblack.png">
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="steps"><p>Close More Sales With More Information</p></div>
                    </td>
                </tr>
            </table>
            <table id="landingTable">
                <tr>
                    <td>
                        <img src="http://www.triggerfind.com/images/mag_glassblack.png">
                    </td>
                    <td>
                        <img src="http://www.triggerfind.com/images/bbellblack.png">
                    </td>
                    <td>
                        <img src="http://www.triggerfind.com/images/moneyblack.png">
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>Find The News YOU Need About YOUR Customers</p>
                    </td>
                    <td>
                        <p>Custom Alerts - Be The First To Know (Coming Soon)</p>
                    </td>
                    <td>
                        <p>Close More Sales With More Information</p>
                    </td>
            </table>
        </div>
        <h2 class="steps">Select a Trigger: </h2>
        <table id="triggerTableTablet">
            <tr>
                <td>
                    <button class="hiring" onclick="javascript:void(0); return(false);">Hiring</button>
                </td>
                <td>
                    <button class="merger" onclick="javascript:void(0); return(false);">Merger/Acquisition</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="sales" onclick="javascript:void(0); return(false);">Sales Growth</button>
                </td>
                <td>
                    <button class="contracts" onclick="javascript:void(0); return(false);">Contracts</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="training" onclick="javascript:void(0); return(false);">Training</button>
                </td>
                <td>
                    <button class="location" onclick="javascript:void(0); return(false);">New Office/Location</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="cfo" onclick="javascript:void(0); return(false);">CFO Leaving</button>
                </td>
                <td>
                    <button class="all" onclick="javascript:void(0); return(false);">All Triggers</button>
                </td>
            </tr>
        </table>
        <table id="triggerTablePhone">
            <tr>
                <td>
                    <button class="hiring" onclick="javascript:void(0); return(false);">Hiring</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="merger" onclick="javascript:void(0); return(false);">Merger/Acquisition</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="sales" onclick="javascript:void(0); return(false);">Sales Growth</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="contracts" onclick="javascript:void(0); return(false);">Contracts</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="training" onclick="javascript:void(0); return(false);">Training</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="location" onclick="javascript:void(0); return(false);">New Office/Location</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="cfo" onclick="javascript:void(0); return(false);">CFO Leaving</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="all" onclick="javascript:void(0); return(false);">All Triggers</button>
                </td>
            </tr>
        </table>
        <table id="triggerTable">
            <tr>
                <td>
                    <button class="hiring"  onclick="javascript:void(0); return(false);">Hiring</button>
                </td>
                <td>
                    <button class="merger" onclick="javascript:void(0); return(false);">Merger/Acquisition</button>
                </td>
                <td>
                    <button class="sales" onclick="javascript:void(0); return(false);">Sales Growth</button>
                </td>
                <td>
                    <button class="contracts" onclick="javascript:void(0); return(false);">Contracts</button>
                </td>
            </tr>
            <tr>
                <td>
                    <button class="training" onclick="javascript:void(0); return(false);">Training</button>
                </td>
                <td>
                    <button class="location" onclick="javascript:void(0); return(false);">New Office/Location</button>
                </td>
                <td>
                    <button class="cfo" onclick="javascript:void(0); return(false);">CFO Leaving</button>
                </td>
                <td>
                    <button class="all" onclick="javascript:void(0); return(false);">All Triggers</button>
                </td>
            </tr>
        </table>
        <h2 class="steps">Search:</h2>
        <div id="searchInputs">
            <input type="text" placeholder="Name of Company" id="search">
                <button id="searchBtn" onclick="javascript:void(0); return(false);"></button>
        </div>
    </div>
    <div id="searchStuff">
        <div class="loader"><p>The Results Are Loading...</p><br />
            <img src="Images/ajaxprogress.gif" /></div>
        <div id="nothing"></div>
        <div id="alerts"></div>
        <div id="results"></div>
        <asp:Panel ID="pnlResults" runat="server"></asp:Panel>
        <div id="newSearch"></div>
    </div>
    <div id="sidebar">
        <div class="smallad">
            <a target="_blank" href="http://shareasale.com/r.cfm?b=511303&amp;u=156535&amp;m=43524&amp;urllink=&amp;afftrack="><img src="http://static.shareasale.com/image/43524/52324.gif" border="0" alt="Sales Training" /></a>    
        </div>
        <div class="fakead">
            <a target="_blank" href="http://shareasale.com/r.cfm?b=488695&amp;u=156535&amp;m=43524&amp;urllink=&amp;afftrack="><img src="http://static.shareasale.com/image/43524/bt25.jpg" border="0" alt="Brian Tracy Sales Management" height="250px" width="250px"/></a>
        </div>
        <div id="mailingBox" class="slideup">
            <div id="mailingWrapper">
                <div id="mailingContainer">
                    <h2>Need to increase your sales conversions?</h2>
                    <br />
                    <h2>Grab your FREE copy of Best of the Best! (The 10 BEST Books about Selling).</h2>
                    <form id="mailingList" method="post" name="mailing_list" action="/mailinglist.php">
                        <br>
                        Name:
                        <br />
                        <asp:TextBox ID="TextBoxName" runat="server" Width="206px"></asp:TextBox>
                        <br />
                        Email Address:
                        <br />
                        <asp:TextBox ID="TextBoxEmail" runat="server" Width="206px"></asp:TextBox>
                        <br><br />
                        <asp:Button ID="ButtonSubmitEmail" runat="server" CssClass="btn" Text="Submit" OnClick="ButtonSubmitEmail_Click" CausesValidation="true" UseSubmitBehavior="False" ValidateRequestMode="Disabled" />
                        <br>
                        &nbsp;</form>
                    <asp:Label ID="LabelSuccess" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <br>
    <br>
    </asp:Content>

