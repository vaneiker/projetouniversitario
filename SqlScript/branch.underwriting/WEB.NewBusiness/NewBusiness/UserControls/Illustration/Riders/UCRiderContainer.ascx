<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRiderContainer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Riders.UCRiderContainer" %>
<li>
    <a href="#item2" lnk='lnk' onclick="setCurrentAccordeon(this, '#hdnLnkAccordeon')"><%=RESOURCE.UnderWriting.NewBussiness.Resources.RidersLabel %><span><!--icono--></span></a>
    <ul>
        <li>
            <div id="frmRiderInformation">
                <div class="fondo_blanco">
                    <div class="content_fondo_blanco">
                        <asp:Panel ID="pnlRiderMainInsured" runat="server" CssClass="col-1-2">
                            <fieldset>
								
                                <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.MainInsuredLabel.ToUpper() %></legend>
                                <div class="grupos de_2">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AccidentalDeathBenefitsLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlAccidentalDeathBenefit">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
                                        <asp:TextBox runat="server" ID="txtAccidentalDeathBenefitInsuredAmount" decimal='decimal' />
                                    </div>
                                </div>
                                <!--grupos-->
                                <div class="grupos de_3">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.OtherInsured %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlSpouseInsured">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
                                        <asp:TextBox runat="server" ID="txtSpouseInsuredInsuredAmount" decimal='decimal' />
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.UntilAge %></label>
                                                    <div class="wrap_select">
                                                        <asp:DropDownList runat="server" ID="ddlSpouseInsuredUntilAge">
                                                            <asp:ListItem Text="Opcion 1" />
                                                            <asp:ListItem Text="Opcion 2" />
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--wrap_select-->
                                                </td>
                                                <td style="width: 25%">
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %></label>
                                                    <asp:TextBox runat="server" ID="txtSpouseInsuredYears" number='number3' />
                                                    <!--wrap_select-->
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <!--grupos-->
                                <div class="break_line"></div>
                                <div class="grupos de_2">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.CriticalIllnessLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlCriticalIllness" ClientIDMode="Static">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
                                        <asp:TextBox runat="server" ID="txtCriticalIllnessInsuredAmount" decimal='decimal' />
                                    </div>
                                </div>
                                <!--grupos-->
                                <div class="grupos de_3">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AdditionalTermInsuranceLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlAdditionalTermInsurance">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
                                        <asp:TextBox runat="server" ID="txtAdditionalTermInsuranceInsuredAmount" decimal='decimal' />
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.UntilAge %></label>
                                                    <div class="wrap_select">
                                                        <asp:DropDownList runat="server" ID="ddlAdditionalTermInsuranceUntilAge">
                                                            <asp:ListItem Text="Opcion 1" />
                                                            <asp:ListItem Text="Opcion 2" />
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--wrap_select-->
                                                </td>
                                                <td style="width: 25%">
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %></label>
                                                    <asp:TextBox runat="server" ID="txtAdditionalTermInsuranceYears" number='number3' />
                                                    <!--wrap_select-->
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div class="break_line"></div>
                                 <!--Bmarroquin 09/01/2017 Se agrega este DIV para contemplar el beneficio de Gastos Funerarios-->
                                <div class="grupos de_2">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FuneralExpenses %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlGastosFunerarios" ClientIDMode="Static">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
                                        <asp:TextBox runat="server" ID="txtGastosFunerariosInsuredAmount" decimal='decimal' />
                                    </div>
                                </div>
                                <!--grupos-->
                            </fieldset>
                        </asp:Panel>
                        <!--col-1-2-->
                        <asp:Panel ID="divOtherInsuredInfo" runat="server" ClientIDMode="Static" CssClass="col-1-2">
                            <fieldset>
                                <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.OtherInsured.ToUpper() %></legend>
                                <div class="grupos de_5">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.NameLabel %></label>
                                        <asp:TextBox runat="server" ID="txtName" alphabetical='alphabetical' />
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MiddleNameLabel %></label>
                                        <asp:TextBox runat="server" ID="txtMiddleName" alphabetical='alphabetical' />
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.LastNameLabel %></label>
                                        <asp:TextBox runat="server" ID="txtLastName" alphabetical='alphabetical' />
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SecondLastNameLabel %></label>
                                        <asp:TextBox runat="server" ID="txtSecondLastName" alphabetical='alphabetical' />
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.RelationshipLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlRelationship">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!--grupos-->
                                <div class="grupos de_4">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DateofBirthLabel %></label>
                                        <%--<input type="text" class="datepicker" id="datepicker2" />--%>
                                        <asp:TextBox runat="server" ID="txtOtherInsuredDateOfBirth" date="birth" ClientIDMode="Static" CssClass="datepicker_03" onfocusout="ChangeOtherInsuredDateOfBirth($(this).val())" />
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.GenderLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlGender">
                                                <asp:ListItem Text="Male" />
                                                <asp:ListItem Text="Female" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MaritalStatusLabel %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlMaritalStatus">
                                                <asp:ListItem Text="Yes" />
                                                <asp:ListItem Text="No" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td>
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Age %></label>
                                                    <asp:TextBox runat="server" ID="txtAge" number='number3' />
                                                    <asp:HiddenField runat="server" ID="hdnAge" />
                                                </td>
                                                <td style="width: 55%">
                                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SmokerLabel %></label>
                                                    <div class="wrap_select">
                                                        <asp:DropDownList runat="server" ID="ddlSmoker">
                                                            <asp:ListItem Text="Yes" />
                                                            <asp:ListItem Text="No" />
                                                        </asp:DropDownList>
                                                    </div>
                                                    <!--wrap_select-->
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <!--grupos-->
                                <div class="break_line"></div>
                                <div class="grupos de_2">
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Risk %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlRisk">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PerThousand %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlPerThousand">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                </div>
                                <!--grupos-->
                            </fieldset>
                        </asp:Panel>

                        <asp:Panel ID="pnlRiderFuneral" runat="server" CssClass="col-1-2">
                            <fieldset>
                                <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.RidersLabel.ToUpper() %></legend>
                                <div class="grupos de_2">
                                    <div>
                                        <label class="label">Familiar</label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlFamiliar">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                        <!--wrap_select-->
                                    </div>
                                    <div>
                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Repatriation %></label>
                                        <div class="wrap_select">
                                            <asp:DropDownList runat="server" ID="ddlRepatriation">
                                                <asp:ListItem Text="Opcion 1" />
                                                <asp:ListItem Text="Opcion 2" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <!--grupos-->
                            </fieldset>
                        </asp:Panel>
                        <!--col-1-2-->
                    </div>
                    <!--content_fondo_blanco-->
                </div>
                <!--fondo_blanco-->
            </div>
        </li>
    </ul>
</li>
