<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBeneficiaries.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Beneficiaries.UCBeneficiaries" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<ul class="secundario">
    <li class="insured_main fl">
        <asp:UpdatePanel ID="upBeneficiaries" runat="server">
            <ContentTemplate>
                <div class="head mB">
                    <div class="row_A ln_conn">
                        <div class="box_2 fr">
                            <strong>Last Updated:</strong>
                            <asp:Label ID="lblLUDateTime" runat="server" ClientIDMode="Static"></asp:Label>

                            <strong>User:</strong>
                            <asp:Label ID="lblLUUserName" runat="server" ClientIDMode="Static"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class=" box_4">
                            <label class="label ReqField">First Name:</label>
                            <asp:TextBox ID="txtFirstName" runat="server" ClientIDMode="Static" alphabetical="alphabetical"></asp:TextBox>
                        </div>

                        <div class=" box_4">
                            <label class="label">Middle Name:</label>
                            <asp:TextBox ID="txtMiddleName" runat="server" ClientIDMode="Static" alphabetical="alphabetical"></asp:TextBox>
                        </div>
                        <div class=" box_4">
                            <label class="label ReqField">Last Name:</label>
                            <asp:TextBox ID="txtLastName" runat="server" ClientIDMode="Static" alphabetical="alphabeticalLastName"></asp:TextBox>
                        </div>
                        <div class=" box_4">
                            <label class="label">2nd Last Name:</label>
                            <asp:TextBox ID="txtSecondLastName" runat="server" ClientIDMode="Static" alphabetical="alphabetical"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class=" box_4">
                            <label class="label ReqField">Date of Birth:</label>
                            <asp:TextBox ID="txtBEDateofBirth" runat="server" alt="validateFutureDate"></asp:TextBox>
                        </div>
                        <div class="box_4">
                            <label class="label ReqField">Relationship:</label>
                            <asp:DropDownList ID="ddlRelationship" ClientIDMode="Static" runat="server"></asp:DropDownList>
                        </div>

                        <div class="box_2">
                            <div class="fl">
                                <label class="label mT3">Document:</label>
                            </div>
                            <div class="browse_up fr">
                                <dx:ASPxUploadControl ID="fuBenediciarieFile" ClientInstanceName="fuBenediciarieFile" runat="server"
                                    ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Upload ID"
                                    ValidationSettings-AllowedFileExtensions=".pdf" OnFileUploadComplete="fuBenediciarieFile_FileUploadComplete">
                                    <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileComplete" />
                                </dx:ASPxUploadControl>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="box_2">
                            <div class="box_3 pd0">
                                <asp:Panel runat="server" ID="pnlPercentage">
                                    <label class="label ReqField">Percentage:</label>
                                    <asp:TextBox ID="txtPercentage" runat="server" ClientIDMode="Static" decimal="decimal" data-inputmask="'alias': 'decimal', 'repeat':3, 'groupSeparator': ',', 'autoGroup': true, 'allowMinus': false, 'allowPlus': false, 'digits': 2 "></asp:TextBox>
                                </asp:Panel>
                            </div>
                            <div class="box_3 pdT-0">
                                <label class="label">ID#:</label>
                                <asp:TextBox ID="txtIDNo" runat="server" ClientIDMode="Static" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="box_3 pd0">
                                <asp:Panel ID="pnlReplacing" ClientIDMode="Static" runat="server">
                                    <label class="label">Replacing:</label>
                                    <asp:DropDownList ID="ddlReplacing" ClientIDMode="Static" runat="server"></asp:DropDownList>
                                </asp:Panel>
                            </div>
                        </div>

                        <div class="box_2">
                            
                            <div class="fr mT10">
                                <div id="dvBtnAdd" runat="server" class="boton_wrapper gradient_AM_btn bdrAM fl mR">
                                    <span id="spBtnAdd" runat="server" class="add"></span>
                                    <asp:Button ID="btnAdd" runat="server" ClientIDMode="Static" Text="Add" OnClick="btnAdd_Click" OnClientClick="return ValidateBeneficiaries(this);" />
                                </div>
                                <div id="dvBtnClear" runat="server" class="boton_wrapper fl gris">
                                    <span id="spBtnClear" runat="server" class="erase"></span>
                                    <asp:Button ID="btnBEClear" runat="server" ClientIDMode="Static" Text="Clear" CssClass="boton" OnClick="btnBEClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <!--//.head -->
                <div class=" data_G tbl em1">
                    <asp:GridView ID="gvBeneficiaries" DataKeyNames="ContactId,ContactRoleTypeId,RelationshipToOwnerId,DocumentTypeId,DocumentId,DocumentCategoryId,SeqNo, PrimaryBeneficiaryId"
                        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="First Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("MiddleName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstLastName" runat="server" Text='<%# Eval("FirstLastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2nd Last Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSecondLastName" runat="server" Text='<%# Eval("SecondLastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Of Birth">
                                <ItemTemplate>
                                    <asp:Label ID="lblDob" runat="server" Text='<%# ((DateTime)Eval("Dob")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relationship">
                                <ItemTemplate>
                                    <asp:Label ID="lblRelationshipDesc" runat="server" Text='<%# Eval("RelationshipDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percentage">
                                <ItemTemplate>
                                    <asp:Label ID="lblBenefitsPercent" runat="server" Text='<%# Eval("BenefitsPercent") != null?  ((Decimal)Eval("BenefitsPercent")).ToString("N2") : "0.00"  + "%"%>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID#">
                                <ItemTemplate>
                                    <asp:Label ID="lblContactID" runat="server" Text='<%#  Eval("ContactMainId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Replacing">
                                <ItemTemplate>
                                    <asp:Label ID="lblReplacing" runat="server" Text='<%# Eval("ReplacingBeneficiaryFullName") == null ? "All" : String.IsNullOrWhiteSpace(Eval("ReplacingBeneficiaryFullName").ToString()) ? "All":Eval("ReplacingBeneficiaryFullName")  %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID File">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnFile" runat="server" CssClass="pdf_ico" OnClick="btnFile_Click" Visible='<%# Eval("DocumentExists") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CssClass="edit_file" OnClick="btnEdit_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
                                    <asp:Button ID="btnRemove" runat="server" CssClass="delete_file" OnClientClick="return DlgConfirm(this);" ClientIDMode="Static" OnClick="btnRemove_Click"></asp:Button>
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
                <div class="dvBeneficiarieEntity">
                    <div class="head_2">
                        <div class="boxes wd22 mR-1-p fl">
                            <label class="label ReqField">Entity Name:</label>
                            <asp:TextBox ID="txtEntityName" runat="server" ClientIDMode="Static"></asp:TextBox>

                            <label class="label ReqField">Type:</label>
                            <asp:DropDownList ID="ddlEntityType" ClientIDMode="Static" runat="server"></asp:DropDownList>
                        </div>
                        <div class=" boxes mR-1-p">
                            <label class="label ReqField">Percentage:</label>
                            <asp:TextBox ID="txtEntityPercentage" runat="server" ClientIDMode="Static" decimal="decimal" data-inputmask="'alias': 'decimal', 'repeat':3, 'groupSeparator': ',', 'autoGroup': true, 'allowMinus': false, 'allowPlus': false, 'digits': 2"></asp:TextBox>
                            <label class="label ReqField">Incorporation Date:</label>
                            <asp:TextBox ID="txtBEIncorporationDate" runat="server" alt="validateFutureDate"></asp:TextBox>
                        </div>
                        <div class=" boxes mR-1-p">
                            <asp:Panel ID="pnlReplacingCompany" ClientIDMode="Static" runat="server">
                                <label class="label">Replacing:</label>
                                <asp:DropDownList ID="ddlReplacingCompany" ClientIDMode="Static" runat="server"></asp:DropDownList>
                            </asp:Panel>

                            <label class="label">ID#:</label>
                            <asp:TextBox ID="txtEntityIDNo" runat="server" ClientIDMode="Static" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="box">
                            <div class="fl wd60">
                                <label class="label">Document:</label>
                            </div>

                            <div class="browse_up fr">
                                <dx:ASPxUploadControl ID="fuBenediciarieFileCompany" ClientInstanceName="fuBenediciarieFileCompany" runat="server"
                                    ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Upload ID"
                                    ValidationSettings-AllowedFileExtensions=".pdf" OnFileUploadComplete="fuBenediciarieFile_FileUploadComplete">
                                    <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileCompanyComplete" />
                                </dx:ASPxUploadControl>
                            </div>

                            <div class="fr mT20 wd60">
                                <div id="dvBtnAddCompany" runat="server" class="boton_wrapper gradient_AM_btn bdrAM fl mR">
                                    <span id="spBtnAddCompany" runat="server" class="add"></span>
                                    <asp:Button ID="btnBECompanyAdd" runat="server" ClientIDMode="Static" Text="Add" OnClick="btnBECompanyAdd_Click" OnClientClick="return ValidateBeneficiariesCompany(this);" />
                                </div>
                                <div id="dvBtnClearCompany" runat="server" class="boton_wrapper fr  gris">
                                    <span id="spBtnClearCompany" runat="server" class="erase"></span>
                                    <asp:Button ID="btnBECompanyClear" runat="server" ClientIDMode="Static" Text="Clear" CssClass="boton" OnClick="btnBECompanyClear_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class=" data_G tbl">
                        <asp:GridView ID="gvBeneficiariesCompany" DataKeyNames="ContactId,ContactRoleTypeId,OccupationId,DocumentTypeId,DocumentId,DocumentCategoryId,SeqNo, PrimaryBeneficiaryId"
                            runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                            <Columns>
                                <asp:TemplateField HeaderText="Entity Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstitutionalName" runat="server" Text='<%# Eval("InstitutionalName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incorporation Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDob" runat="server" Text='<%# ((DateTime)Eval("Dob")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMiddleName" runat="server" Text='<%# Eval("OccupationDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Percentage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBenefitsPercent" runat="server" Text='<%# Eval("BenefitsPercent") != null?  ((Decimal)Eval("BenefitsPercent")).ToString("N2") : "0.00"  + "%"%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID#">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactID" runat="server" Text='<%#  Eval("ContactMainId") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Replacing">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReplacing" runat="server" Text='<%# Eval("ReplacingBeneficiaryFullName") == null ? "All" : String.IsNullOrWhiteSpace(Eval("ReplacingBeneficiaryFullName").ToString()) ? "All":Eval("ReplacingBeneficiaryFullName")  %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID File">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnBECompanyFile" runat="server" CssClass="pdf_ico" OnClick="btnBECompanyFile_Click" Visible='<%# Eval("DocumentExists") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnBECompanyEdit" runat="server" CssClass="edit_file" OnClick="btnBECompanyEdit_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                    <ItemTemplate>
                                        <asp:Button ID="btnBECompanyRemove" runat="server" CssClass="delete_file" OnClientClick="return DlgConfirm(this);" OnClick="btnBECompanyRemove_Click"></asp:Button>
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
                </div>
                <div class="wd100 fl mT10">
                    <label class="label txtBold em1-1">SPECIAL INSTRUCTIONS</label>
                    <asp:TextBox ID="txtSpecialInstructions" runat="server" ClientIDMode="Static" TextMode="MultiLine" CssClass="wd100 fl hg80"></asp:TextBox>
                </div>
                <asp:HiddenField ID="hdnIsEdit" ClientIDMode="Static" runat="server" />
                <asp:HiddenField ID="hdnEditIndex" ClientIDMode="Static" runat="server" />
                <asp:TextBox ID="hdnUploadedPDFPath" ClientIDMode="Static" runat="server" Style="display: none;" />

                <asp:HiddenField ID="hdnIsEditCompany" ClientIDMode="Static" runat="server" />
                <asp:HiddenField ID="hdnEditIndexCompany" ClientIDMode="Static" runat="server" />
                <asp:TextBox ID="hdnUploadedPDFPathCompany" ClientIDMode="Static" runat="server" Style="display: none;" />

                <asp:HiddenField ID="hdnBeneficiarieType" ClientIDMode="Static" runat="server" />

                <asp:HiddenField ID="hdnBeneficiarieTypeID" ClientIDMode="Static" runat="server" />
                <asp:HiddenField ID="hdnIsInsured" ClientIDMode="Static" runat="server" Value="false" />
                <asp:HiddenField ID="hdnIsFuneral" ClientIDMode="Static" runat="server" Value="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </li>
</ul>
