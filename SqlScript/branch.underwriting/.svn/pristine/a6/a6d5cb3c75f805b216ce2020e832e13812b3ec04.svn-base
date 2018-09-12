<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WEB.NewBusiness.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/dtl.css" rel="stylesheet" />
    <style>
        .Boton
        {
            background-color: #00608F;
            color: #fff;
            font-size: 13px;
            line-height: 19px;
            margin: 0px auto 10px;
            padding: 8px 12px 8px;
            white-space: nowrap;
            min-width: 170px;
            max-width: 200px;
            text-shadow: none;
        }
    </style>
</head>
<body class="ErrorMsg">
    <form id="form1" runat="server">
        <center>
        <div>
            <p>
                <h1><%Response.Write(RESOURCE.UnderWriting.NewBussiness.Resources.Error); %>:
                </h1>
                   <asp:Literal runat="server" ID="ltMsg"> </asp:Literal>
                <br />
            </p>
            <p><b><%Response.Write(RESOURCE.UnderWriting.NewBussiness.Resources.AdministratorMessage); %>.</b></p>
            <asp:Button runat="server" ID="btnGoToLoby" CssClass="Boton" OnClick="btnGoToLoby_Click" OnPreRender="btnGoToLoby_PreRender" />
        </div>
        </center> 
    </form>
</body>
</html>
