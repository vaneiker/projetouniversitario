<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAddress.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.WUCAddress" %>
<asp:UpdatePanel runat="server" ID="udpAddress" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" ID="frmAddress" class="col-1-3 " ClientIDMode="Static">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><span class="address"></span><strong> <asp:Literal runat="server" ID="ltAddresses">ADDRESSES</asp:Literal> </strong></div>
                <div class="content_fondo_blanco ">
                    <asp:Panel ID="frmHomeAddress" runat="server" ClientIDMode="Static">
                        <div class="grupos de_1">
                            <div>
                                <label runat="server" id="homeAddress" class="label red">Home Address</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_HomeAddress" TextMode="MultiLine" ClientIDMode="Static" validation="Required"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->  
                        <div class="grupos de_2">
                            <div>
                                <label runat="server" id="country" class="label red">Country</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeCountry" ClientIDMode="Static" AutoPostBack="true" validation="Required" OnSelectedIndexChanged="ddlContrySelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label runat="server" id="StateProvince" class="label red">State/Province</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeState" ClientIDMode="Static" AutoPostBack="true" validation="Required" OnSelectedIndexChanged="ddlStateSelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="City">City</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_HomeCity" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label" runat="server" id="PostalCode">Postal Code</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_HomePostalCode" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->
                        <fieldset runat="server" style="border: none;" >
                            <div class="background: none;border: none;" id="dvCopyHomeAddress">
                                <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkCopyHomeAddress" AutoPostBack="true" onclick="BeginRequestHandler()" OnCheckedChanged="chkCopyHomeAddress_CheckedChanged" />
                                <label class="label" runat="server" id="copyHomeAddress">Copy Home Address</label>
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
                    <asp:Panel ID="frmbusinessAddress" runat="server" ClientIDMode="Static">
                        <div class="grupos de_1">
                            <div>
                                <label class="label red" runat="server" >Direccion de la empresa</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_BusinessAddress" TextMode="MultiLine" ClientIDMode="Static" validation="Required"></asp:TextBox>
                            </div>
                        </div>
                        <!--grupos-->
                        <div class="grupos de_2">
                            <div>
                                <label class="label red" runat="server" id="Country2">Country</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessCountry" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlContrySelectedIndexChanged" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="StateProvince2">State/Province</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessState" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlStateSelectedIndexChanged" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label red" runat="server" id="City2">City</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="ddl_WUC_A_BusinessCity" ClientIDMode="Static" validation="Required"></asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div>
                                <label class="label" runat="server" id="PostalCode2">Postal Code</label>
                                <asp:TextBox runat="server" ID="tb_WCU_A_BusinessPostalCode" ClientIDMode="Static"></asp:TextBox>
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
        <asp:HiddenField ID="hdnCurrentSession" runat="server" Value="" />
        <asp:HiddenField ID="hdnTotalAddress" runat="server" Value="" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>        
        <asp:AsyncPostBackTrigger ControlID="chkCopyHomeAddress" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_HomeCountry" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_HomeState" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_BusinessCountry" />
        <asp:AsyncPostBackTrigger ControlID="ddl_WUC_A_BusinessState" />
    </Triggers>
</asp:UpdatePanel>
