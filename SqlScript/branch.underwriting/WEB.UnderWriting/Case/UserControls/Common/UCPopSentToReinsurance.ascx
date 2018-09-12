<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopSentToReinsurance.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.UCPopSentToReinsurance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register Src="~/Case/UserControls/Common/UCPdfViewer.ascx" TagPrefix="uc1" TagName="UCPdfViewer" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<div class="cont_send_reinsurance">
    <div class="accordion_tabulado">

        <ul class="principal" id="acc4">
            <!--SEND TO REINSURANCE-->
            <li><a href="#" id="aSendReinsuranceParams" class="trigger shown open" onclick="setCurrentAccordeon(this,'#hfRightAccordeon');" lnk='lnk'>
                <div class="rect">
                </div>
                REINSURANCE PARAMETERS<span></span> </a>
                <ul class="secundario" style="display: block; overflow: hidden;">
                    <li class="send_reinsurance">
                        <!-- CONTENIDO -->
                        <div class="cont bdr0">
                             <div class="box_titulos row bdrGR mB2 pd0-10">
                                <asp:Label ID="Label1" runat="server" ClientIDMode="Static">POLICY SEGMENTS</asp:Label>
                            </div>
                            <div class="data_G tbl mB">
                                <div class=" cont_GR">

                                    <asp:GridView ID="gvRiders" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                                        DataKeyNames="Risk_Rating,Coverage_Type_Desc, Beneficiary_Amount, Requested_Date, Processed_Date, Company_Risk_Amount, Reinsurance_Risk_Amount, Authorized_Amount, Risk_Rating_Amount, Per_Thousend_Risk_Amount, Facultative_Status_Id, Facultative_Status_Desc, Total_Amount_Insured,Facultative_Reinsurance_Id,Reinsurance_Facultative_Status" Autopostback="True"
                                        OnRowCreated="gvRiders_RowCreated" OnRowDataBound="gvRiders_RowDataBound"
                                        SelectedRowStyle-CssClass="selected_row" ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Segment Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRyderTypeDesc" runat="server" Text='<%# Eval("Coverage_Type_Desc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="c2">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBeneficiaryAmount" runat="server" Text='<%# Eval("Beneficiary_Amount")==null ? "": Decimal.Parse(Eval("Beneficiary_Amount").ToString()).ToString("N2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Requested" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequestedDate" runat="server" Text='<%# Eval("Requested_Date")==null ? "": DateTime.Parse(Eval("Requested_Date").ToString()).ToString("MM/dd/yyyy") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Approved" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProcessedDate" runat="server" Text='<%# Eval("Processed_Date")==null ? "": DateTime.Parse(Eval("Processed_Date").ToString()).ToString("MM/dd/yyyy") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Company Risk Amount" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompanyRiskAmount" runat="server" Text='<%# Eval("Company_Risk_Amount")==null ? "": Decimal.Parse(Eval("Company_Risk_Amount").ToString()).ToString("N2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reinsurance Risk Amount" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6 dvEntityExtraPremiumColumn" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6 dvEntityExtraPremiumColumn">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReinsuranceRiskAmount" runat="server" Text='<%# Eval("Reinsurance_Risk_Amount")==null ? "": Decimal.Parse(Eval("Reinsurance_Risk_Amount").ToString()).ToString("N2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Authorized Amount" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6 dvEntityExtraPremiumColumn" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6 dvEntityExtraPremiumColumn">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAuthorizedAmount" runat="server" Text='<%# Eval("Authorized_Amount")==null ? "": Decimal.Parse(Eval("Authorized_Amount").ToString()).ToString("N2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Risk Rating" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6 dvEntityExtraPremiumColumn" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6 dvEntityExtraPremiumColumn">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRiskRatingDesc" runat="server" Text='<%# Eval("Risk_Rating") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Per Thousend" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6 dvEntityExtraPremiumColumn" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6 dvEntityExtraPremiumColumn">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPerThousandAmount" runat="server" Text='<%# Eval("Per_Thousend_Risk_Amount")==null ? "": Decimal.Parse(Eval("Per_Thousend_Risk_Amount").ToString()).ToString("N2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c8" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c8">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRiderStatusDesc" runat="server" Text='<%# Eval("Facultative_Status_Desc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
									                <asp:LinkButton CommandArgument='<%# Container.DataItemIndex %>' CssClass="edit_file" ID="lnkEdit" OnClick="lnkEdit_Click" OnClientClick="return validateRiderFields(this);" runat="server"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No data to display
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gradient_azul" />
                                    </asp:GridView>
                                </div>
                            <div class="data_G tbl mB">
                                 
                                <div class=" cont_GR">
                                    <ul class="barra_secc">
                                        <li class="gradient_azul last-child"><i class="up_icon"></i>Facultative</li>
                                    </ul>
                                    <div class="cont mB25" style="height:100% !important;">
                                        <div id="parameters" style="display: block;" class="animated">
                                            <div class="data_id">
                                                <div class="box-cont" style="width:99% !important;">
                                                    <div class="boxes wd25 mR-2-p">
                                                        <%--wcastro 28-04-2017--%>
                                                        <%--<label class="label txtBold">Process</label>--%>
                                                        <label class="label txtBold">Process:</label>
                                                        <%--fin wcastro 26-04-2017--%> 
                                                        <label class="label txtNormal">Status:</label>
                                                        <asp:DropDownList ID="ddlFacultativeStatus" CssClass="select_1" Enabled="false" runat="server" OnSelectedIndexChanged="ddlFacultativeStatus_SelectedIndexChanged"
                                                            AutoPostBack="true" DataTextField="Text" DataValueField="Value">
                                                        </asp:DropDownList>
                                                        <label class="label txtBold">Comments:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <textarea id="txtComments" rows="2" cols="20" class="hg80"></textarea>
                                                        <%--<textarea id="txtComments" rows="2" cols="20" class="hg80" disabled="disabled"></textarea>--%>
                                                        <%--fin wcastro 26-04-2017--%>
                                                    </div>
                                                    <div class="boxes wd30 mR-2-p">
                                                        <%--wcastro 28-04-2017--%>
                                                        <%--<label class="label txtBold">Coverage Informacion</label>--%>
                                                        <label class="label txtBold">Coverage Informacion:</label>
                                                        <%--fin wcastro 28-04-2017--%>
                                                        <label class="label">Coverage Name:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <%--<asp:TextBox ID="txtCoverageName" runat="server" ClientIDMode="Static" CssClass="mB" ReadOnly="true"></asp:TextBox>--%>    
                                                        <asp:TextBox ID="txtCoverageName" runat="server" ClientIDMode="Static" CssClass="mB" Enabled="false"></asp:TextBox>  
                                                        <%--fin wcastro 26-04-2017--%>
                                                        <label class="label">Coverage Amount:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <%--<asp:TextBox ID="txtCoverageAmount" runat="server" ClientIDMode="Static" CssClass="DFormat" ReadOnly="true"></asp:TextBox> --%>   
                                                        <asp:TextBox ID="txtCoverageAmount" runat="server" ClientIDMode="Static" CssClass="DFormat" Enabled="false"></asp:TextBox> 
                                                        <%--fin wcastro 26-04-2017--%>
                                                        <label class="label">Total Insured Amount:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <%--<asp:TextBox ID="txtTotalAmtInsured" runat="server" ClientIDMode="Static" CssClass="DFormat" ReadOnly="true"></asp:TextBox>--%>  
                                                         <asp:TextBox ID="txtTotalAmtInsured" runat="server" ClientIDMode="Static" CssClass="DFormat" Enabled="false"></asp:TextBox>
                                                        <%--fin wcastro 26-04-2017--%>  
                                                    </div>
                                                    <%--<div class="boxes wd16 mR-2-p">--%>
                                                    <div class="boxes wd20 mR-2-p">
                                                        <label class="label txtBold">Risk Rating:</label>
                                                        <label class="label">Risk:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <%--<asp:DropDownList ID="ddlRiskRatingPercents" CssClass="select_1" runat="server"
                                                            AutoPostBack="true" DataTextField="Text" DataValueField="Value">
                                                        </asp:DropDownList>  --%>
                                                        <asp:DropDownList ID="ddlRiskRatingPercents" CssClass="select_1" runat="server"
                                                            AutoPostBack="true" DataTextField="Text" DataValueField="Value" Enabled="false">
                                                        </asp:DropDownList>  
                                                        <%--fin wcastro 26-04-2017--%>
                                                        <label class="label">Per Thousand:</label>
                                                        <%--wcastro 26-04-2017--%>
                                                        <%--<asp:TextBox ID="txtRiskPerThousand" runat="server" ClientIDMode="Static" CssClass="DFormat" ReadOnly="false"></asp:TextBox>--%>  
                                                         <asp:TextBox ID="txtRiskPerThousand" runat="server" ClientIDMode="Static" CssClass="DFormat" Enabled="false"></asp:TextBox>  
                                                        <label class="label">Facultative ID:</label>
                                                        <asp:TextBox ID="txtFacultativeReinsuranceId" runat="server" ClientIDMode="Static" CssClass="mB" Enabled="false"></asp:TextBox> 
                                                       <%-- <label class="label">Total Amount Authorized:</label>
                                                        <div style="color: #F00 !important;"><asp:Label ID="lblMaxAmountToAuth" runat="server" ClientIDMode="Static" CssClass="label"></asp:Label></div>--%>
                                                        <%--fin wcastro 26-04-2017--%>
                                                    </div>
                                                </div>
                                                <div class="row clear mT10"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--// .data_G -->
                                <div class="row mT20">
                                     <div class="boton_wrapper gradient_RJ bdrRJ fr">
                                    <span class="equis"></span>
                                        <asp:Button runat="server" ID="btnCancel" CssClass="boton" Text="Cancel" OnClick="btnCancel_Click" Enabled="true" />
                                    </div>

                                   <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                                        <span class="save"></span>
                                        <asp:Button runat="server" ID="btnSave" CssClass="boton" Text="Save" ClientIDMode="Static" OnClick="btnSave_Click" OnClientClick="return validateRiderFields(this);" />
                                    </div>
                                </div>
                           
                                <div class="row clear mT10">

                                </div>
                                <!--// .row -->
                            </div>
                        </div>
                        <%--wcastro 26-04-2017--%>
                        <asp:HiddenField ID="hdDateRequested" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdDateApproved" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdPolicyStatusId" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdFacultativeAmount" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdBenefitAmount" ClientIDMode="Static" runat="server" />
                        <%--fin wcastro 26-04-2017--%>
                        <!-- CONTENIDO -->
                    </li>
                </ul>
                <!--secundario-->
                <div class="limpiador">
                </div>
            </li>



            <!--SEND TO REINSURANCE-->
            <li><a href="#" id="aSendReinsurance" class="trigger shown open" onclick="setCurrentAccordeon(this,'#hfRightAccordeon');" lnk='lnk'>
                <div class="rect">
                </div>
                SEND TO REINSURANCE<span></span> </a>
                <ul class="secundario" style="display: block; overflow: hidden;">
                    <li class="send_reinsurance">
                        <!-- CONTENIDO -->
                        <div class="cont bdr0">
                            <div class="data_G tbl mB">
                                <asp:GridView ID="gvInbox" DataKeyNames="StepTypeId, StepId, StepCaseNo, CommunicationId, CommAttachment"
                                    runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="From" HeaderStyle-CssClass="c1" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="RiskType" runat="server" Text='<%# Eval("CommFrom ") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="Category" runat="server" Text='<%# Eval("CommSubject") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="c3" ItemStyle-CssClass="c3 alignC">
                                            <ItemTemplate>
                                                <asp:Label ID="ConditionType" runat="server" Text='<%# Eval("CommDate") != null? DateTime.Parse(Eval("CommDate").ToString()).ToString("MM/dd/yyy"): "" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time" HeaderStyle-CssClass="c4 wd9" ItemStyle-CssClass="c4 alignC">
                                            <ItemTemplate>
                                                <asp:Label ID="Reason" runat="server" Text='<%# Eval("CommDate") != null? DateTime.Parse(Eval("CommDate").ToString()).ToString("hh:mm tt"): "" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Attachments" HeaderStyle-CssClass="c5" ItemStyle-CssClass="c5 alignC">
                                            <ItemTemplate>
                                                <asp:Label ID="CommAttachment" runat="server" Text='<%# (Eval("CommAttachment") != null && ((Boolean)Eval("CommAttachment"))) ? "Yes": "No" %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="c6" ItemStyle-CssClass="c6 alignC">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSRView" runat="server" CssClass="eye" ClientIDMode="Static" OnClick="btnSRView_Click"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>
                            <!--// .data_G -->

                            <div class="box_titulos row bdrGR mB2 pd0-10">
                                <asp:Label ID="lblSRSubject" runat="server" ClientIDMode="Static"></asp:Label>
                            </div>
                            <div class=" cont_GR">
                                <ul class="barra_secc">
                                    <li class="gradient_azul last-child"><i class="email"></i>Message</li>
                                </ul>
                                <div class="cont mB25">
                                    <%--wcastro 14-05-2017--%>
                                    <%--<asp:Literal ID="ltCorreo" ClientIDMode="Static" TextMode="MultiLine" runat="server">
                                    </asp:Literal>--%>
                                    <asp:TextBox ID="ltCorreo" runat="server" Enabled="false" ClientIDMode="Static" TextMode="MultiLine" Height="350px" CssClass="comment_reinsurance"></asp:TextBox>
                                    <%--fin wcastro 14-05-2017--%>
                                </div>
                                <div class="data_G tbl mB">
                                    <asp:GridView ID="gvEmailAttachments" DataKeyNames="DocCategoryId, DocTypeId, DocumentId, DocumentName, Extension" Visible="false"
                                        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-CssClass="c1" ItemStyle-CssClass="c1">
                                                <ItemTemplate>
                                                    <asp:Label ID="DocumentName" runat="server" Text='<%# Eval("DocumentName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Document Type" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2">
                                                <ItemTemplate>
                                                    <asp:Label ID="DocTypeDesc" runat="server" Text='<%# Eval("DocTypeDesc ") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="c6" ItemStyle-CssClass="c6 alignC">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSRPreviewAttach" runat="server" CssClass="pdf_file" ClientIDMode="Static" OnClick="btnSRPreviewAttach_Click" Visible='<%# Eval("DocTypeDesc") != null ? (Eval("DocTypeDesc").ToString().ToLower() == "pdf"): false %>'></asp:Button><%--bmarroquin 16-05-17 Valido que la descripcion no sea Null--%>
                                                    <asp:UpdatePanel ID="upSendReinsurance" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="btnSRDownloadAttach" runat="server" CssClass="download_file" ClientIDMode="Static" OnClick="btnSRDownloadAttach_Click" Visible='<%# Eval("DocTypeDesc") != null ? (Eval("DocTypeDesc").ToString().ToLower() != "pdf"): false %>'></asp:LinkButton> <%--bmarroquin 16-05-17 Valido que la descripcion no sea Null--%>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSRDownloadAttach" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No data to display
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gradient_azul" />
                                    </asp:GridView>
                                </div>
                                <div class="row clear mT10">

                                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                                        <span class="equis"></span>
                                        <asp:Button ID="btnSRCloseEmail" runat="server" ClientIDMode="Static" OnClick="btnSRCloseEmail_Click" CssClass="boton" Text="Close" />
                                    </div>

                                    <div class="boton_wrapper azul mR-2-p fr">
                                        <span class="reply"></span>
                                        <%--wcastro 16-05-2017--%>
                                        <%--<input class="boton" type="button" value="Reply" onclick="ShowReplyAccordeon();">--%>
                                        <asp:Button ID="boton" runat="server" ClientIDMode="Static" Text="Reply" CssClass="boton" OnClick="replaySend_Click" />
                                        <%--fin wcastro 16-05-2017--%>
                                    </div>

                                </div>
                                <!--// .row -->
                            </div>
                        </div>

                        <!-- CONTENIDO -->
                    </li>
                </ul>
                <!--secundario-->
                <div class="limpiador">
                </div>
            </li>
            <!--principal 1-->
            <!-- SEND MESSAGE-->
            <li><a href="#" class="trigger" onclick="setCurrentAccordeon(this,'#hfRightAccordeon');" lnk='lnk' id="aReplyReinsurance">
                <div class="rect">
                </div>
                SEND MESSAGE <span></span></a>
                <ul class="secundario" style="display: none; overflow: hidden;">
                    <li class="accor_send_message last-child">
                        <!-- CONTENIDO -->
                        <div class="cont bdr0">
                            <div class="send_message">
                                <label class="label">To:</label>
                                <asp:TextBox ID="txtSRSendRecipients" runat="server" ClientIDMode="Static" CssClass="mB" ReadOnly="true"></asp:TextBox>
                                <label class="label">Subject:</label>
                                <asp:TextBox ID="txtSRSendSubject" runat="server" ClientIDMode="Static" CssClass="mB"></asp:TextBox>
                                <asp:TextBox ID="txtSRSendEmail" runat="server" ClientIDMode="Static" TextMode="MultiLine" CssClass="comment_reinsurance"></asp:TextBox>
                            </div>
                            <div id="attach" style="display: block;" class="animated">
                                <label class="label em0-8 txtBold mB txtNormal">Attach Policy File:</label>

                                <div class="row mB">
                                    <div class="wd35 fl">
                                        <label class="label label_1">Policy:</label>
                                        <asp:DropDownList ID="ddlSRPolicy" CssClass="select_1" runat="server" OnSelectedIndexChanged="ddlSRPolicy_SelectedIndexChanged"
                                            AutoPostBack="true" DataTextField="Text" DataValueField="Value">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="wd40 fr" style="display:none;"><%-- Bmarroquin 15-05-2017 Se Oculta el DropDownList--%>
                                        <label class="label label_2">Document Type:</label>
                                        <asp:DropDownList ID="ddlSRDocumentTypes" CssClass="select_2" runat="server" OnSelectedIndexChanged="ddlSRDocumentTypes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="tbl data_G row mB tabla1">
                                    <asp:UpdatePanel ID="upSRPolicyDocs" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvSRPolicyDocument" ClientIDMode="Static"
                                                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                                DataKeyNames="DocCategoryId, DocTypeId, DocumentId"
                                                AllowPaging="true" PageSize="8" OnPageIndexChanging="gvSRPolicyDocument_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Attach" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c1">
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="chkAttach" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c2">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDocumentName" runat="server" Text='<%# Eval("DocumentName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c3">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("DocCategoryDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Document Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDocumentDate" runat="server" Text='<%# Eval("DocumentDate", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Upload Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("UploadDate", "{0:d}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="PDF's Files" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnSRPreviewAttach" runat="server" CssClass="pdf_file" ClientIDMode="Static" OnClick="btnSRPreviewAttach_Click"></asp:Button>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <PagerTemplate>
                                                    <div class="pagination">
                                                        <p>
                                                            Page
                            <asp:Literal ID="indexPage" runat="server" />
                                                            of
                            <asp:Literal ID="totalPage" runat="server" />
                                                            (<asp:Literal ID="totalItems" runat="server" />
                                                            items)
                                                        </p>
                                                        <asp:Button runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                                        <asp:Button runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                                        <asp:Button runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                                        <asp:Button runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                                    </div>
                                                </PagerTemplate>
                                                <EmptyDataTemplate>
                                                    No data to display
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gradient_azul" />
                                                <PagerStyle CssClass="RCFooterPad" />
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvSRPolicyDocument" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="boton_wrapper azul fr mT10">
                                        <span class="attach"></span>
                                        <asp:Button ID="btnSRAttachDoc" runat="server" ClientIDMode="Static" Text="Attach" CssClass="boton" OnClick="btnSRAttachDoc_Click" OnClientClick="return SRAttachDocClick();" />
                                    </div>
                                </div>

                                <label class="label em0-8 txtBold txtNormal">Attach Local File:</label>

                                <div class="browse_up fl">
                                    <dx:ASPxUploadControl ID="fuSRUploadFile" ClientInstanceName="fuSRUploadFile" runat="server"
                                        ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto"
                                        ValidationSettings-AllowedFileExtensions=".pdf,.jpg,.docx,.xlsx,.pptx"
                                        ShowProgressPanel="false" BrowseButton-Text="Upload" OnFileUploadComplete="fuSRUploadFile_FileUploadComplete">
                                        <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="SRUploadFileComplete" />
                                    </dx:ASPxUploadControl>
                                </div>
                                <div class="boton_wrapper gradient_vd2 bdrVd2 fr mB">
                                    <span class="save"></span>
                                    <asp:Button ID="btnSRSaveUploadedAttach" runat="server" ClientIDMode="Static" Text="Save" CssClass="boton" OnClick="btnSRSaveUploadedAttach_Click" />
                                </div>

                                <div class="tbl data_G mT10 tabla2">
                                    <asp:GridView ID="gvSREmailSendAttachments" DataKeyNames="DocCountId"
                                        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                                        AllowPaging="true" PageSize="9" OnPageIndexChanging="gvSREmailSendAttachments_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDocumentName" runat="server" Text='<%# Eval("DocName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSize" runat="server" Text='<%# Eval("DocSize", "{0:N2}").ToString() + "MB" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="View" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSRViewEmailAttach" runat="server" CssClass="pdf_file" ClientIDMode="Static" OnClick="btnSRViewEmailAttach_Click" Visible='<%# Eval("DocExtension").ToString().ToLower() == ".pdf"%>'></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSRRemoveAttachment" runat="server" CssClass="delete_file" OnClientClick="return DlgConfirm(this);" ClientIDMode="Static" OnClick="btnSRRemoveAttachment_Click"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerTemplate>
                                            <div class="pagination">
                                                <p>
                                                    Page
                            <asp:Literal ID="indexPage" runat="server" />
                                                    of
                            <asp:Literal ID="totalPage" runat="server" />
                                                    (<asp:Literal ID="totalItems" runat="server" />
                                                    items)
                                                </p>
                                                <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                                <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                                <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                                <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                            </div>

                                        </PagerTemplate>
                                        <EmptyDataTemplate>
                                            No data to display
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="gradient_azul" />
                                        <PagerStyle CssClass="RCFooterPad" />
                                    </asp:GridView>
                                </div>
                                <div class="total_size mB15">
                                    <asp:Label ID="lblSRTotalSize" runat="server" Text="Total Size: 0.00MB"></asp:Label>
                                </div>
                            </div>

                            <div class="row">
                               <%-- Bmarroquin 13-05-2017 --%>
                                <div class="boton_wrapper gradient_vd2 bdrVd2 fr">
                                    <span class="save"></span>
                                    <asp:Button ID="btnGuardarDocReaseguro" runat="server" ClientIDMode="Static" Text="Save Doc" CssClass="boton" OnClick="btnGuardarDocReaseguro_Click" />
                                </div>
                                <%-- Fin Bmarroquin 13-05-2017 --%>
                                <div class="boton_wrapper gradient_RJ bdrRJ fr">
                                    <span class="equis"></span>
                                    <asp:Button ID="btnSRCancelEmail" runat="server" ClientIDMode="Static" Text="Cancel" CssClass="boton" OnClick="btnSRCancelEmail_Click" />
                                </div>
                                <div class="boton_wrapper azul fr mR">
                                    <span class="email"></span>
                                    <asp:Button ID="btnSRSendEmail" runat="server" ClientIDMode="Static" Text="Send" CssClass="boton" OnClick="btnSRSendEmail_Click" OnClientClick="return SRSendEmailClick();" />
                                </div>
                            </div>
                        </div>

                        <!-- CONTENIDO -->
                    </li>
                </ul>
                <!--secundario-->
                <div class="limpiador">
                </div>
            </li>
            <!--principal 2 // SEND MESSAGE-->

        </ul>
    </div>
</div>

<AJAX:ModalPopupExtender ID="ModalPdfPop" BehaviorID="ModalPdfPop" runat="server" Enabled="true" TargetControlID="hdnNSShowPDFPop"
    PopupControlID="pnPDFPop" DropShadow="false" BackgroundCssClass="ui-widget-overlay" ClientIDMode="Static">
</AJAX:ModalPopupExtender>
<asp:Panel ID="pnPDFPop" ClientIDMode="Static" runat="server" Style="display: none; margin: 0; padding: 0; cursor: move; border: solid 1px #c6c6c6;" CssClass="DraggablePop">
    <div class="titulos_azules head_contengridproxi PreviewPDF HeaderHandler" style="width: 100%;">
        <ul>
            <li style="position: absolute; left: 41%; top: 31%;">
                <asp:Literal ID="ltTypeDoc" Text="Reinsurance PDF Attachment" ClientIDMode="Static" runat="server"></asp:Literal>
            </li>
            <li style="top: 13%;">
                <input type="button" id="close_pop_up" class="cls_pup" onclick="CloseGeneralPdfPop();" />
            </li>
        </ul>
    </div>
    <uc1:UCPdfViewer runat="server" ID="UCPdfViewer1" />
</asp:Panel>
<asp:HiddenField ID="hdnNSShowPDFPop" runat="server" Value="false" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRUploadedFile" runat="server" Value="" ClientIDMode="Static" />

<asp:HiddenField ID="hdnSRStepCaseNo" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRStepId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRStepTypeId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRStepSeqReference" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRReinsurerId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSRCommunicationTypeId" runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="hdnSREmailRecipient" runat="server" ClientIDMode="Static" />



