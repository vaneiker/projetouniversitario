<%@ Page Title="" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="ListFormFields.aspx.cs" Inherits="ListFormFields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>List PDF Form Fields</h2>
    <p>
        This demo shows how to use iTextSharp to list the form fields in a specified PDF document.
    </p>
    <p>
        <b>Select PDF:</b>
        <asp:DropDownList ID="ddlPDFs" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnShowFields" runat="server" Text="Show Form Fields" 
            onclick="btnShowFields_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGeneratePDF" runat="server" Text="Generate Sample PDF" 
            onclick="btnGeneratePDF_Click" />
    </p>
    <hr />

    <asp:BulletedList ID="blFields" runat="server" BulletStyle="Numbered">
    </asp:BulletedList>
</asp:Content>

