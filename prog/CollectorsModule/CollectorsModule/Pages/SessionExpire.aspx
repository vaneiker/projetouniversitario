<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CM.Master" AutoEventWireup="true" CodeBehind="SessionExpire.aspx.cs" Inherits="CollectorsModule.Pages.SessionExpire" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <style>
        .head {
            text-align: center !important;
            position: absolute;
            padding-top: 1%;
            text-align: left;
            margin-top: 8%;
            padding-left: 8%;
            color: white !important;
            width: 100%;
            background-color: rgba(255, 255, 255, 100);
            overflow: hidden;
        }
            .head > p {
                text-align:center;
            }
             .loginUri {
                text-decoration:underline;
                color:#47A5DF;
                font-weight:bold;
            }
    </style>
    <div class="head">
        <h1>Sesión Expirada</h1>
        <p>
            Su sesión ha expirado.  
            Por favor, retorne a la pagina de <a href="Login.aspx" class="loginUri">acceso</a> 
            e ingrese nuevamente sus credenciales.
        </p>
    </div>
</asp:Content>
