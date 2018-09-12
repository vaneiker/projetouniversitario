<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGridViewPopup.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCGridViewPopup" %>
<asp:UpdatePanel runat="server" ID="udpPopupGridView" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 600px;" id="frmQuestions">
            <!--escriben por style el ancho que desean-->
            <div class="titulos_azules" style="width: 100%;">
                <ul>
                    <li style="position: absolute; left: 41%; top: 31%;">
                        <asp:Literal ID="ltPadecimiento" Text="ADD CONDITION" ClientIDMode="Static" runat="server"></asp:Literal>
                    </li>
                    <li style="top: 13%;">
                        <input type="button" id="close_pop_up" class="cls_pup" onclick="DiscardPadecimiento()" />
                    </li>
                </ul>
            </div>
            <!--titulos_azules-->
            <div class="content_fondo_blanco">
                <div class="grupos de_2">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <label class="label" runat="server" id="Condition">Condition</label>
                                    <asp:Panel ID="pnPadecimientos" runat="server">
                                        <div class="wrap_select">
                                            <asp:DropDownList ID="ddlPadecimiento" runat="server"></asp:DropDownList>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnPadecimientosTextBox" runat="server">
                                        <asp:TextBox ID="txtPadecimiento" runat="server" validation="Required"></asp:TextBox>
                                    </asp:Panel>
                                    <!--wrap_select-->
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos de_2">
                    <div>
                        <label class="label red" runat="server" id="Reason">Reason</label>
                        <asp:TextBox ID="txtRazon" runat="server" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label red" runat="server" id="Date">Date</label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="datepicker" validation="Required" alt="validateFutureDate"></asp:TextBox>
                    </div>
                </div>
                <div class="grupos de_1">
                    <div>
                        <label class="label red" runat="server" id="Motive">Motive</label>
                        <asp:TextBox ID="txtMotivo" runat="server" validation="Required"></asp:TextBox>
                    </div>
                </div>
                <div class="grupos de_2">
                    <div>
                        <label class="label red" runat="server" id="Doctor">Doctor</label>
                        <asp:TextBox ID="txtMedico" runat="server" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label red" runat="server" id="Institution">Institution</label>
                        <asp:TextBox ID="txtInstitucion" runat="server" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label red" runat="server" id="Phone">Phone</label>
                        <asp:TextBox ID="txtTelefono" runat="server" MaxLength="16" validation="Required" data-inputmask="'alias': 'integer','rightAlign': false,'clearMaskOnLostFocus': true,'allowMinus': false, 'allowPlus': false"></asp:TextBox>

                    </div>
                    <div>
                        <label class="label red" runat="server" id="StreetAddress">Street Address</label>
                        <asp:TextBox ID="txtDireccion" runat="server" validation="Required"></asp:TextBox>

                    </div>
                </div>

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper amarillo">
                            <span class="add"></span>
                            <asp:Button ID="btnAgregar" runat="server" Text="Add" OnClick="btnAgregar_Click" CssClass="boton" OnClientClick="return validateForm('frmQuestions')" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

                <div class="grid_wrap margin_t_15 gris">
                    <asp:GridView runat="server" ClientIDMode="Static" ID="gvPadecimiento" AutoGenerateColumns="False" AllowPaging="True"
                        DataKeyNames="ID,QuestionnaireSeq,QuestionnaireLanguageId,AnswerSeq,Exists"
                        ShowHeader="true"
                        ShowHeaderWhenEmpty="true"
                        CssClass="gvResult"
                        PageSize="4"
                        OnDataBound="gvPadecimiento_DataBound" OnPreRender="gvPadecimiento_PreRender">
                        <PagerSettings Mode="NextPreviousFirstLast" />
                        <Columns>
                            <asp:BoundField DataField="DiseaseDesc" HeaderText="CONDITION" AccessibleHeaderText="Condition" />
                            <asp:TemplateField HeaderText="EDIT" AccessibleHeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnEditar" CssClass="edit_file" OnClick="btnEditar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DELETE" AccessibleHeaderText="DeleteLabel">
                                <ItemTemplate>
                                    <asp:UpdatePanel runat="server" ID="udpBtnDelete">
                                        <ContentTemplate>
                                            <asp:Button runat="server" CssClass="delete_file" OnClientClick="return DlgConfirm(this)" ID="btnDelete" OnClick="btnDelete_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <span style="color: red; font-weight: bold; font-size: 13px;"><%=RESOURCE.UnderWriting.NewBussiness.Resources.NodataDisplay %></span>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <!--grid_wrap-->
                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save"></span>
                            <asp:Button ID="btnGuardar" runat="server" Text="Save" CssClass="boton" OnClick="btnGuardar_Click" OnClientClick="BeginRequestHandler()" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>
        <asp:Button ID="bntRefresh" runat="server" Text="" ClientIDMode="Static" Style="display: none" />
        <asp:HiddenField ID="hfISEdit" runat="server" Value="false" />
        <asp:HiddenField ID="hfSelect" runat="server" Value="0" />
    </ContentTemplate>
</asp:UpdatePanel>
