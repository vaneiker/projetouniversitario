<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAddressLegal.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.WUCAddressLegal" %>
<asp:UpdatePanel runat="server" ID="udpAddress_Legal" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" ID="frmAddress_Legal" class="col-1-3 " ClientIDMode="Static">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><span class="address"></span><strong> <asp:Literal runat="server" ID="ltAddresses">ADDRESSES</asp:Literal> </strong></div>
                <div class="content_fondo_blanco ">
                    <asp:Panel ID="frmHomeAddress_Legal" runat="server" ClientIDMode="Static">
                        <div class="grupos de_1">
                            <div>
                                <label runat="server" id="homeAddress" class="label red">Home Address</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_HomeAddress_Legal" TextMode="MultiLine" ClientIDMode="Static" validation="Required"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->  
                        <div class="grupos de_2">
                            <div>
                                <label runat="server" id="country" class="label red">Country</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeCountry_Legal" ClientIDMode="Static" AutoPostBack="true" validation="Required" OnSelectedIndexChanged="ddlContry_Legal_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label runat="server" id="StateProvince" class="label red">State/Province</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeState_Legal" ClientIDMode="Static" AutoPostBack="true" validation="Required" OnSelectedIndexChanged="ddlState_Legal_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="City">City</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeCity_Legal" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label" runat="server" id="PostalCode">Postal Code</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_HomePostalCode_Legal" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->
                        <fieldset runat="server" style="border: none;" >
                            <div class="background: none;border: none;" id="dvCopyHomeAddress_Legal">
                                <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkCopyHomeAddress_Legal" AutoPostBack="true" onclick="BeginRequestHandler()" OnCheckedChanged="chkCopyHomeAddress_Legal_CheckedChanged" />
                                <label class="label" runat="server" id="copyHomeAddress_Legal">Copy Home Address</label>
                                <%--<div class="float_right">
                                    <div class="boton_wrapper gris">
                                        <span class="copy"></span>
                                        <asp:Button runat="server" ID="btn_WCU_A_CopyHomeAddress" ClientIDMode="Static" Text="Copy Home Address" OnClientClick="return validateHomeAddress();" CssClass="boton" OnClick="btn_WCU_A_CopyHomeAddress_Click" />
                                    </div>
                                </div>  --%>
                            </div>
                        </fieldset>
                    </asp:Panel>
                    <!--grupos-->
                     <asp:Panel ID="frmbusinessAddress_Legal" runat="server" ClientIDMode="Static">
                        <div class="grupos de_1">
                            <div>
                                <label class="label red" runat="server" >Direccion de la empresa</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_BusinessAddress_Legal" TextMode="MultiLine" ClientIDMode="Static" validation="Required"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->
                        <div class="grupos de_2">
                            <div>
                                <label class="label red" runat="server" id="Country2">Country</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessCountry_Legal" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlContry_Legal_SelectedIndexChanged" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="StateProvince2">State/Province</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessState_Legal" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlState_Legal_SelectedIndexChanged" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="City2">City</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessCity_Legal" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label" runat="server" id="PostalCode2">Postal Code</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_BusinessPostalCode_Legal" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->
                    </asp:Panel>
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </asp:Panel>
         <!--col-1-3-->
        <asp:HiddenField ID="hdnCurrentSession_Legal" runat="server" Value="" />
        <asp:HiddenField ID="hdnTotalAddress_Legal" runat="server" Value="" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>        
        <asp:AsyncPostBackTrigger ControlID="chkCopyHomeAddress_Legal" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_HomeCountry_Legal" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_HomeState_Legal" />
          <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_BusinessCountry_Legal" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_BusinessState_Legal" />
    </Triggers>
</asp:UpdatePanel>
