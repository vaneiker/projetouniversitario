<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCommCalls.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.CustomerCommunication.UCCommCalls" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="ejem_note ">
    <div class="cont wd100">

        <div class=" wd20 mR-2-p fl mB">
            <label class="label">Date</label>
            <asp:TextBox ID="txtCallDate" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        </div>
        <div class=" wd23-5 mR-2-p fl mB">
            <label class="label">User</label>
            <asp:TextBox ID="txtCallUser" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        </div>
       <%-- <div class=" wd52 fl mB">
            <label class="label">Department</label>
            <asp:TextBox ID="txtCallDepartment" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
        </div>--%>
        <div class="wd100 fl mB15">
            <asp:Literal ID="playerText" runat="server"></asp:Literal>
        </div>
        <!-- Botones -->

        <div class="wd100 fl hg35 mB">
            <div class="boton_wrapper gradient_RJ bdrRJ fr">
                <span class="equis"></span>
                <input class="boton" type="submit" value="Close" onclick="return CloseCCCallPop();">
            </div>
        </div>
        <!--// Botones -->
    </div>
</div>
<asp:HiddenField ID="hdnAudFileName" ClientIDMode="Static" runat="server" />
