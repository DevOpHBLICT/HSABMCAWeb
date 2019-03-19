<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HSABMCAWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>
    <div class="container">
      <h2>Info-sign Glyph</h2>
      <p>Info-sign icon: <span class="glyphicon glyphicon-info-sign"></span></p>    
      <p>Info-sign icon as a link:
        <a href="#">
          <span class="glyphicon glyphicon-info-sign"></span>
        </a>
      </p>
      <p>Info-sign icon on a button:
        <button type="button" class="btn btn-default btn-sm">
          <span class="glyphicon glyphicon-info-sign"></span> Info
        </button>
      </p>
      <p>Info-sign icon on a styled link button:
        <a href="#" class="btn btn-info btn-lg">
          <span class="glyphicon glyphicon-info-sign"></span> Info
        </a>
      </p> 
    </div>
    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
