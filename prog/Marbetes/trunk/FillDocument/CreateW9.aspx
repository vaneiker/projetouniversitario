<%@ Page Title="" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="CreateW9.aspx.cs" Inherits="CreateW9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Create a Filled Out IRS Form W-9</h2>
    <p>
        This demo shows how to collect user input and use it to populate the form fields in the 
        <a href="http://www.irs.gov/pub/irs-pdf/fw9.pdf">IRS's Form W-9 (PDF)</a>.
    </p>
    <p>
        <b>Name (as shown on your income tax return):</b><br />
        <asp:TextBox ID="txtName" Width="95%" runat="server"></asp:TextBox>
    </p>
    <p>
        <b>Business name/disregarded entity name, if different from above:</b><br />
        <asp:TextBox ID="txtBusinessName" Width="95%" runat="server"></asp:TextBox>
    </p>
    <p>
        <b>Federal tax classification:</b><br />
        <asp:RadioButtonList ID="rblTaxClassification" runat="server" RepeatColumns="3" 
            RepeatDirection="Horizontal">
            <asp:ListItem>Individual/sole proprietor</asp:ListItem>
            <asp:ListItem>C Corporation</asp:ListItem>
            <asp:ListItem>S Corporation</asp:ListItem>
            <asp:ListItem>Partnership</asp:ListItem>
            <asp:ListItem>Trust/estate</asp:ListItem>
            <asp:ListItem>Limited liability company</asp:ListItem>
            <asp:ListItem>Other (see instructions)</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:CheckBox ID="chkExemptPayee" Text="Exempt Payee" runat="server" />
    </p>
    <p>
        <b>Address (number, street, and apt. or suite no.)</b><br />
        <asp:TextBox ID="txtAddress" Width="95%" runat="server"></asp:TextBox>
    </p>
    <p>
        <b>City, state, and ZIP code</b><br />
        <asp:TextBox ID="txtCityStateZIP" Width="95%" runat="server"></asp:TextBox>
    </p>
    <p>
        <b>List account number(s) here (optional)</b><br />
        <asp:TextBox ID="txtAccountNumbers" Width="95%" runat="server"></asp:TextBox>
    </p>
    <h3>Tax Identification Number (TIN)</h3>
    <div class="indent">
        <p>
            <b>Social security number</b><br />
            <asp:TextBox ID="txtSSN1" MaxLength="3" Columns="3" runat="server"></asp:TextBox>
            -
            <asp:TextBox ID="txtSSN2" MaxLength="2" Columns="2" runat="server"></asp:TextBox>
            -
            <asp:TextBox ID="txtSSN3" MaxLength="4" Columns="4" runat="server"></asp:TextBox>
        </p>
        <p>
            - or -
        </p>
        <p>
            <b>Employer identification number</b><br />
            <asp:TextBox ID="txtEIN1" MaxLength="2" Columns="2" runat="server"></asp:TextBox>
            -
            <asp:TextBox ID="txtEIN2" MaxLength="7" Columns="7" runat="server"></asp:TextBox>
        </p>
    </div>
    <p>
        <asp:Button ID="btnGeneratePDF" runat="server" Text="Generate Completed W-9" 
            onclick="btnGeneratePDF_Click" />
    </p>
</asp:Content>

