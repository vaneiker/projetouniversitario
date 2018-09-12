<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcBankCheckRequest.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Eforms.UcBankCheckRequest" %>


<div class="contenedor_formilario">
    <div class="pagina_formilario">
        <div class="header_formilario">
            <table class="header-01">
                <tr>
                    <td rowspan="3">
                        <div class="stlEformsLogo"></div>
                    </td>
                    <td class="aling-right valing">
                        <h2>Bank Check Request</h2>
                    </td>
                </tr>
            </table>
        </div>
        <!--header_formilario-->

        <div class="break_line"></div>

        <div class="content_formulario">

            <div class="col-1-1">
                <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">To:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ToTxt" runat="server" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Date( MM/DD/YY):
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DateTxt" runat="server" class=" datepicker formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">From:
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="FromTxt" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Customer Number:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CustomerNumberTxt" runat="server" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Ref:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="RefTxt" runat="server" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--col-1-1-->

            <div class="col-1-1">
                <div class="titulos"><strong>Beneficiary Information</strong> (Información del Beneficiario):</div>
                <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Check Amount
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="CheckAmountTxt" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Check Currency
                                    </td>
                                    <td>
                                        <table class="sin-border">
                                            <tr>
                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <asp:CheckBox runat="server" ID="USCurrencyCheck" ClientIDMode="Static" name="USCurrencyCheck" class="check_03" />

                                                    </div>
                                                </td>
                                                <td class="aling-left">US Dollar</td>

                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="EuroCurrencyCheck" name="EuroCurrencyCheck" class="check_03" />

                                                    </div>
                                                </td>
                                                <td class="aling-left">Euro</td>

                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="OtherCurrencyCheck" name="OtherCurrencyCheck" class="check_03" />

                                                    </div>
                                                </td>
                                                <td class="aling-left">Other, Specify:</td>
                                                <td width="74%">
                                                    <asp:TextBox runat="server" ClientIDMode="Static" ID="OtherCurrencyTxt" class="formulario-01 inputClear" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Beneficiary Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="BeneficiaryNameTxt" runat="server" ClientIDMode="Static" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Beneficiary Address
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="BeneficiaryAddressTxt" CssClass="inputClear"
                                            ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Reference
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="ReferenceTxt" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Notes
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="NotesTxt" TextMode="MultiLine" CssClass="inputClear"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--col-1-1-->

            <div class="col-1-1">
                <div class="titulos"><strong>Debit ( - )</strong></div>
                <table class="horizontal-border">
                    <tr>
                        <td>
                            <div runat="server" id="AccountNumberPanel">
                                <table class="vertical-border" runat="server" id="tblAccountNumber">
                                    <tr>
                                        <td class="align_right" width="15%">Account Number
                                        </td>
                                        <td class="align_left">
                                            <table class="sin-border ancho-01 margin_left">
                                                <tr>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber1Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber2Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber3Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber4Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber5Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber6Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber7Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber8Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                    <td width="">
                                                        <asp:TextBox ID="AccountNumber9Txt" runat="server" ClientIDMode="Static" name="accountTxt" class="formulario-01 inputClear" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">Account Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AccountNameTxt" ClientIDMode="Static" runat="server" class="formulario-01 inputClear" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--col-1-1-->

            <div class="col-1-1">
                <div class="titulos"><strong>Authorization</strong></div>
                <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr height="60">
                                    <td class="align_left texto_gris">
                                        <asp:Literal ID="AcknowledgementLiteral" ClientIDMode="Static" runat="server" Text="I hereby authorize StateTrust Bank & Trust Ltd. to issue an Official Bank Check on my behalf and to debit my bank account
                                        (plus any transactional fee) accordingly.Account Number"></asp:Literal>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="texto_rojo valing">
                                        <asp:Literal ID="SignatureLiteral" runat="server" Text="“A” Type signatures, only one required; “B” Type signatures, two signatures are required."
                                            ClientIDMode="Static"></asp:Literal>

                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td height="80">
                                        <table class="sin-border">
                                            <tr>
                                                <td>
                                                    <table class="sin-border ancho-02 no_margin_right">
                                                        <tr>
                                                            <td width="">
                                                                <asp:TextBox ID="CustomerSignatureLeftTxt" ClientIDMode="Static" runat="server"
                                                                    class="formulario-01 inputClear" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="">Customer Signature
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table class="sin-border">
                                            <tr>
                                                <td>
                                                    <table class="sin-border ancho-02 no_margin_right">
                                                        <tr>
                                                            <td width="">
                                                                <asp:TextBox ID="CustomerSignatureRightTxt" ClientIDMode="Static" runat="server"
                                                                    class="formulario-01 inputClear" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="">Customer Signature
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td width="60%">
                                        <table class="sin-border">
                                            <tr>
                                                <td class="aling-left texto_gris">For Bank Use Only
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table runat="server" id="ForBankUserTable" class="sin-border margin_left">
                                                        <tr>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseBranch1Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseBranch2Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseBranch3Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td>.</td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseDay1Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseDay25Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td>.</td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseMonth1Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseMonth2Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td>.</td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseYear1Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseYear2Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td>.</td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseReference1Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseReference2Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseReference3Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                            <td width="">
                                                                <asp:TextBox ID="ForBankUseReference4Txt" runat="server" ClientIDMode="Static"
                                                                    class="formulario-01 inputClear" /></td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3" class="texto_gris">Branch</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">dd</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">mm</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">yy</td>
                                                            <td></td>
                                                            <td colspan="4" class="texto_gris">Reference</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table class="sin-border">
                                            <tr>
                                                <td class="aling-left" width="20%">Input By:
                                                </td>
                                                <td width="">
                                                    <asp:TextBox ID="InputByTxt" runat="server"
                                                        ClientIDMode="Static" class="formulario-01 inputClear" /></td>
                                            </tr>

                                            <tr>
                                                <td class="aling-left" width="">Verified By:
                                                </td>
                                                <td width="">
                                                    <asp:TextBox runat="server" ID="VerifiedByTxt" ClientIDMode="Static"
                                                        class="formulario-01 inputClear" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <!--col-1-1-->


            <div class="break_line"></div>


        </div>
        <!--content_formulario-->

    </div>
    <!--pagina_formilario-->






</div>
