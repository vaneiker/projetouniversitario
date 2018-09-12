<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCVechicleEditForm.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.WUCVechicleEditForm" %>
<asp:UpdatePanel runat="server" ID="udpVehicleEditForm" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvVehicleEditForm" style="padding: 10px">
            <div style="height: 15px;"></div>

            <div class="col-6 fl">
                <div class="label_plus_input par">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Registry %></span>
                    <asp:TextBox runat="server" ID="txtPlate" validation="Required" Style="text-align: left; text-transform: uppercase" Enabled="false"></asp:TextBox>
                </div>
           </div>
           <asp:Panel ID="pnPlateNew" runat="server" CssClass="col-6 fl" Visible="false">
                <div class="label_plus_input par">
                    <span>Placa Nueva</span>
                    <asp:TextBox runat="server" ID="txtPlateNew" Style="text-align: left; text-transform: uppercase"></asp:TextBox>
                </div>
            </asp:Panel>
            <div class="col-6 fl">
                <div class="label_plus_input par">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleChasis %></span>
                    <asp:TextBox runat="server" ID="txtChassis" validation="Required" Style="text-align: left; text-transform: uppercase" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <asp:Panel ID="pnChassisNew" runat="server" CssClass="col-6 fl" Visible="false">
                <div class="label_plus_input par">
                    <span>Chasis Nuevo</span>
                    <asp:TextBox runat="server" ID="txtChassisNew" validation="Required" Style="text-align: left; text-transform: uppercase"></asp:TextBox>
                </div>
            </asp:Panel>
            <div class="col-6 fl">
                <div class="label_plus_input par sl">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.VehicleColor %></span>
                    <asp:DropDownList runat="server" ID="ddlColor" validation="Required" Enabled="false"></asp:DropDownList>
                </div>
            </div>
            <asp:Panel ID="pnColorNew" runat="server" CssClass="col-6 fl" Visible="false">
                <div class="label_plus_input par sl">
                    <span>Color Nuevo</span>
                    <asp:DropDownList runat="server" ID="ddlColorNew" validation="Required"></asp:DropDownList>
                </div>
            </asp:Panel>

            <div class="col-6 fl">
                <asp:Panel runat="server" ID="pnCondition" class="label_plus_input par sl">
                    <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Condition %></span>
                    <asp:DropDownList runat="server" ID="ddlCondition" validation="Required" OnPreRender="ddlCondition_PreRender">
                        <asp:ListItem Value="-1"> ---- </asp:ListItem>
                        <asp:ListItem Value="true"> Nuevo</asp:ListItem>
                        <asp:ListItem Value="false"> Usado</asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
            </div>

            <div style="height: 6px;"></div>
            <div style="float: right;">
                <div class="fl" style="margin-left: 10px;">
                    <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvVehicleEditForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
                    </asp:LinkButton>
                </div>
                <div class="fl" style="margin-left: 10px;">
                    <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopVehicleForm();" />
                </div>
            </div>
        </div>

        <asp:HiddenField runat="server" ID="hdnInsuredVehicleId" Value="0" />

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
