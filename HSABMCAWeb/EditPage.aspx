<%@ Page Title="MCA Edit Prompts" Language="C#" MasterPageFile="~/SiteHTML.Master"  AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="HSABMCAWeb.EditPage"   %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/people-300x79.png" />
    <form id="form1" runat="server">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="Red" HeaderText=" Error - Please Check:" />
    
    <script>
        function onContentsChange() {
            var t = document.getElementById("MainContent_txt03_Prompt").innerHTML;
            document.getElementById("MainContent_lbl03_HTML").innerHTML=t;
        }
    </script>

<asp:Panel runat="server" ID="pnl01_Login">
    <table><tr><td>&nbsp;</td><td>&nbsp;</td></tr>
        <tr><td>Editor Login</td><td>&nbsp;&nbsp;- please enter</td></tr>
        <tr><td>UserName</td><td>
        <asp:TextBox ID="txt01_User" runat="server" Text="aaaa"></asp:TextBox>
    </td></tr>
        <tr><td>Password</td><td>
        <asp:TextBox ID="txt01_Password" runat="server" TextMode="Password"></asp:TextBox>
            </td><td><asp:Button ID="btn01_Login" runat="server" Text="Login" OnClick="btn01_Login_Click" />
    </td></tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnl02_Select">
    <br />
    Select Page to Edit&nbsp;Or click for <asp:Button ID="btn02_New" runat="server" Text="New Page" OnClick="btn02_New_Click" />
    <asp:SqlDataSource ID="sql02_Pages" runat="server" ConnectionString="<%$ ConnectionStrings:HSABMCAWebDBConnectionString %>" SelectCommand="SELECT Page_ID FROM Pages
union
Select '' as Page_ID
 ORDER BY Page_ID"></asp:SqlDataSource>
    <asp:GridView ID="dg02_Pages" runat="server" DataSourceID="sql02_dgPages" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Page_ID" OnSelectedIndexChanged="dg02_Pages_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:BoundField DataField="Page_ID" HeaderText="Page_ID" ReadOnly="True" SortExpression="Page_ID" />
            <asp:BoundField DataField="YesPage_ID" HeaderText="YesPage_ID" SortExpression="YesPage_ID" />
            <asp:BoundField DataField="NoPage_ID" HeaderText="NoPage_ID" SortExpression="NoPage_ID" />
            <asp:BoundField DataField="NextPage_ID" HeaderText="NextPage_ID" SortExpression="NextPage_ID" />
            <asp:BoundField DataField="BackPage_ID" HeaderText="BackPage_ID" SortExpression="BackPage_ID" />
            <asp:BoundField DataField="HeaderType" HeaderText="HeaderType" SortExpression="HeaderType" />
            <asp:BoundField DataField="DisplayHTML" HeaderText="DisplayHTML" SortExpression="DisplayHTML">
            <ItemStyle Width="400px" Wrap="False" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sql02_dgPages" runat="server" ConnectionString="<%$ ConnectionStrings:HSABMCAWebDBConnectionString %>" SelectCommand="SELECT Page_ID, YesPage_ID, NoPage_ID, NextPage_ID, BackPage_ID, HeaderType, Substring(DisplayHTML,1,60)+'...' as DisplayHTML FROM Pages ORDER BY Page_ID"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl03_HTML">
     <br />
        Page ID <asp:TextBox ID="txt03_Page_ID" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt03_Page_ID" ErrorMessage="Page ID cannot be left blank" ValidationGroup="RequiredGroup"></asp:RequiredFieldValidator>
        <br /><br />

Edit<br />        <div style="margin-left: 10px;margin-right:10px">

                        <asp:TextBox runat="server"
                        ID="txt03_Prompt"
                        TextMode="MultiLine"
                        Columns="50"
                        Rows="10"
                        Text="Hello <b>world!</b>" Width="80%" />

                    <ajaxToolkit:HtmlEditorExtender
                        ID="htmlEditorExtender1"
                        TargetControlID="txt03_Prompt"
                        OnClientChange="onContentsChange"
                        runat="server" EnableSanitization="true">
                    </ajaxToolkit:HtmlEditorExtender>
                        <br />
  
    Preview:<br />
        <div >
             <div id="lbl03_Preview"><asp:Label ID="lbl03_HTML" runat="server" Text="Label"  TargetControlID="lbl03_HTML" style="background-color: lightgrey;margin-left: 10px;margin-right:10px" Width="70%" ></asp:Label>
             </div>
        </div>
        <br/>

    </div>
            <br />
            Navigate to if?<br />
             &nbsp;&nbsp;Yes&nbsp;<asp:TextBox ID="txt03_Yes" runat="server" Width="70"></asp:TextBox>
             &nbsp;&nbsp;No&nbsp;<asp:TextBox ID="txt03_No" runat="server" Width="70"></asp:TextBox>
             &nbsp;&nbsp;Back&nbsp;<asp:TextBox ID="txt03_Back" runat="server" Width="70"></asp:TextBox>
             &nbsp;&nbsp;Next&nbsp;<asp:TextBox ID="txt03_Next" runat="server" Width="70"></asp:TextBox>
             &nbsp;&nbsp;Header&nbsp;<asp:DropDownList ID="ddl03_Header" runat="server" DataSourceID="sql03_Header" DataTextField="Header_Title" DataValueField="Header_ID"></asp:DropDownList>

            <asp:SqlDataSource ID="sql03_Header" runat="server" ConnectionString="<%$ ConnectionStrings:HSABMCAWebDBConnectionString %>" SelectCommand="SELECT Header_Title, Header_ID, Display_Order FROM Headers
union
Select '' as Header_Title, '' as Header_ID,  0 as Display_Order
ORDER BY Display_Order"></asp:SqlDataSource>

            <br /><br />
                    <asp:Button ID="btn03_AddPage" runat="server" Text="Add Page" OnClick="btn03_AddPage_Click" ValidationGroup="RequiredGroup" />
                    <asp:Button ID="btn03_Save" runat="server" Text="Save Changes" OnClick="btn03_Save_Click" ValidationGroup="RequiredGroup" />
                    <asp:Button ID="btn03_Cancel" runat="server" Text="Cancel" OnClick="btn03_Cancel_Click" />
        
    </asp:Panel>

    </form>
    </asp:Content>
