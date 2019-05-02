<%@ Page Title="MCA Prompts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HSABMCAWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/people-300x79.png" />
    <div >
        <h2>
            <asp:Table runat="server" ID="tbl01_Header2"></asp:Table>
    </h2>
    </div>
    <asp:Panel runat="server" ID="pnl02_Page">
        <h2>
        <asp:Label ID="lbl02_Prompt" runat="server" Text="Label"></asp:Label></h2>
        <asp:Panel runat="server" ID="pnl02A_Prompt">
           <br /> <div style="margin-left: 100px">
                <h2>
                    <asp:Table ID="tbl02_Prompt" runat="server">
                        <asp:TableRow runat="server" ID="tr02_Yes">
                            <asp:TableCell>
                                <asp:ImageButton ID="img02_Yes" runat="server" ImageUrl="~/Images/BigTick.png" Height="29px" Width="34px" OnClick="img02_Yes_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:LinkButton ID="lnk02_Yes" runat="server" OnClick="lnk02_Yes_Click">Yes</asp:LinkButton></asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" ID="tr02_No">
                            <asp:TableCell>
                                <asp:ImageButton ID="img02_No" runat="server" ImageUrl="~/Images/BigCross.png" Height="29px" Width="31px" OnClick="img02_No_Click" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:LinkButton ID="lnk02_No" runat="server" OnClick="lnk02_No_Click">No</asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </h2>
            </div>
        </asp:Panel>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnl99_Footer">
        <br />
    <asp:ImageButton ID="img99_Next" runat="server" ImageUrl="~/Images/next.png" Height="34px" Width="34px"  OnClick="img99_Next_Click"/>
    <asp:ImageButton ID="img99_Back" runat="server" ImageUrl="~/Images/back.png" Height="34px" Width="34px"  OnClick="img99_Back_Click" />
    <asp:ImageButton ID="img99_Home" runat="server" ImageUrl="~/Images/home.png" Height="34px" Width="34px" OnClick="img99_Home_Click"/>
    </asp:Panel>

</asp:Content>
