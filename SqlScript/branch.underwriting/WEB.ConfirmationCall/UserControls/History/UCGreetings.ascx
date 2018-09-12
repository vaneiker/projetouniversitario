<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGreetings.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.History.UCGreetings" %>
<div class="iconos_right">
    <span id="iconSecurityFlag" runat="server" class="candado_icon" visible="false" ></span>
    <span id="iconMedicalFlag" runat="server" class="medical_icon"  visible="false" ></span>
</div>
<div class="texto margin_t_20">
    <ul>
        <li><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.BuenasTardes.ToUpper()  %> <strong class="red">  <asp:Label ID="lbNombreCliente" runat="server" Text="[NOMBRE CLIENTE]"></asp:Label> </strong>
           
        </li>
        <li><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.MiNombreEs.ToUpper()  %> <strong class="red"><asp:Label ID="lbNombreOperador" runat="server" Text="[NOMBRE OPERADOR]"></asp:Label></strong> 
            <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.YLeEstamosLlamando  %> <strong class="red"><asp:Label ID="lblCorp" runat="server" Text="ATLANTICA SEGUROS"></asp:Label></strong>. </li>
        <li><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ElMotivo  %>  
                                        <strong class="red"><asp:Label ID="lbPlan" runat="server" Text="[PLAN]"></asp:Label></strong>
            <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ElCualContrato  %> 
                                        <strong class="red"><asp:Label ID="lbAcesorFinanciero" runat="server" Text="[ACESOR FINANCIERO]"></asp:Label></strong>
            <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.YDeseamos  %> 
        </li>
    </ul>
</div>
<fieldset class="margin_t_60">
    <legend class="textblack"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PreSecurityQuestions.ToUpper()  %></legend>
    <div class="grupos de_3">
        <div>
            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DateofBirth  %>:</label>
            <asp:TextBox ID="tbDateBirth" runat="server" ReadOnly="True"></asp:TextBox>
                        <asp:CheckBox ID="chkDateBirth" Enabled="false" runat="server" />
        </div>
        <div>
            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Agent  %>:</label>
            <asp:TextBox ID="tbAgent" runat="server" ReadOnly="True"></asp:TextBox>
            
       <asp:CheckBox ID="chkAgent" Enabled="false" runat="server" />    
        </div>
        <div>
            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ID  %>:</label>
            <asp:TextBox ID="tbId" runat="server" ReadOnly="True"></asp:TextBox>
                        <asp:CheckBox ID="chkId" Enabled="false" runat="server" />
        </div>
    </div>
    <!--grupos-->
</fieldset>