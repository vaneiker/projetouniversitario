<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEmailPhone.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.UCEmailPhone" %>
<ul class="secundario" style="display: none;">
    <li class="ephon"><span class="label mT0 mB22"><i class="email"></i><strong>Email Address:</strong>
    </span>
        <div class=" wd60 hg50">
            <div class=" fl wd34 mR-2-p">
                <label class="label ReqField">
                    Email Type:</label>
                <asp:DropDownList ID="EmailTypeDDL" runat="server" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class=" fl wd40 mR-2-p">
                <label class="label ReqField">
                    Email Address:</label>
                <asp:TextBox ID="EmailAddressTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="fl wd10 mR-2-p alignC">
                <label class="label">Primary:</label>
                <span class=" mT10 block">
                    <asp:CheckBox ID="EmailPrimaryChk" runat="server" class="" />
                </span>
            </div>
            <div class="fl wd9">
                <div class="boton_wrapper gradient_AM_btn bdrAM mT15">
                    <span class="add"></span>
                    <asp:Button ID="AddEmailBTN" runat="server" Text="Add" class="boton" OnClick="AddEmailBTN_Click"  OnClientClick="return ValidateEmailAddress();"/>
                    <asp:Button ID="EditEmailBTN" runat="server" Text="Save" class="boton" OnClick="EditEmailBTN_Click" OnClientClick="return ValidateEmailAddress();"/>
                </div>
            </div>
        </div>
        <div class=" spH15 mB22">
        </div>
        <div class="tbl-email mB22">
            <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="4" OnPageIndexChanging="gvEmail_PageIndexChanging"
                DataKeyNames="DirectoryId, DirectoryDetailId, CorpId, CommunicationTypeId, DirectoryTypeId, DirectoryTypeDesc, EmailAdress, IsPrimary">
                <Columns>
                    <asp:TemplateField HeaderText="Email Type" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVEmailType"><%# Eval("DirectoryTypeDesc")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email Address" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVAddress"><%# Eval("EmailAdress")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div id="DVEmailPrimary" runat="server">
                                <%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>"%>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnEditEmail" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="UpdateEmail" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnDeleteEmail" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="DeleteEmail" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

            </asp:GridView>
            <asp:HiddenField ID="hdfEmail" runat="server" />
        </div>
        <!-- //EMAIL -->
        <!-- PHONE NUMBERS  -->
        <span class="label mT0 mB22"><i class="phone"></i><strong>Phone Numbers:</strong>
        </span>
        <div class="add_line">
            <div class=" fl wd13 mR-2-p">
                <label class="label ReqField">
                    Phone Type:</label>
                <asp:DropDownList ID="DDLPhoneType" runat="server" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class=" fl wd13 mR-1-p">
                <label class="label ReqField">
                    Country Code:</label>
                <asp:TextBox ID="CountryCodeTxt" runat="server" alt="numberLeft" ClientIDMode="Static" data-inputmask="'alias': 'integer','rightAlign': false,'clearMaskOnLostFocus': true,'allowMinus': false, 'allowPlus': false"></asp:TextBox>
            </div>
            <div class=" fl wd10 mR-1-p" style="display: none;">
                <label class="label" visible="false">
                    <b>Area Code:</b>
                </label>
                <asp:TextBox ID="AreaCodeTxt" runat="server" alt="numberLeft" ClientIDMode="Static" Visible="false"></asp:TextBox>
            </div>
            <div class=" fl wd13 mR-1-p">
                <label class="label ReqField">
                    Phone Number:</label>
                <asp:TextBox ID="PhoneNumberTxt" alt="PhoneNumber" runat="server" ClientIDMode="Static" validateLength="7" data-inputmask="'mask': '999-9999','clearMaskOnLostFocus': true,'showTooltip': true"></asp:TextBox>
            </div>
            <div class=" fl wd8 mR-1-p">
                <label class="label">
                    <b>Extension:</b></label>
                <asp:TextBox ID="ExtensionTxt" alt="numberLeft" runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class=" fl wd13 mR-1-p">
                <label class="label ReqField">
                    Contact:</label>
                <asp:TextBox ID="ContactTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="fl wd5 mR-1-p alignC">
                <label class="label">Primary:</label>
                <span class=" mT10 block">
                    <asp:CheckBox ID="PhonePrimaryChk" runat="server" class="mT7" ClientIDMode="Static" />
                </span>
            </div>
            <div class="fl wd9">
                <div class="boton_wrapper gradient_AM_btn bdrAM mT15">
                    <span class="add"></span>
                    <asp:Button ID="AddPhoneBTN" runat="server" Text="Add" class="boton" OnClick="AddPhoneBTN_Click" OnClientClick="return ValidatePhoneNumber();" />
                    <asp:Button ID="EditPhoneBTN" runat="server" Text="Save" class="boton" Visible="false" OnClick="EditPhoneBTN_Click" OnClientClick="return ValidatePhoneNumber();" />
                </div>
            </div>
        </div>
        <div class=" spH15 mB22">
        </div>
        <div class="tbl-phone">
            <asp:GridView ID="gvPhone" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="4" OnPageIndexChanging="gvPhone_PageIndexChanging"
                DataKeyNames="CommunicationTypeId, DirectoryTypeId, DirectoryId, DirectoryDetailId, CorpId, DirectoryTypeDesc, CountryCode, AreaCode, PhoneNumber, PhoneExt, IsPrimary, PersonToContact">
                <Columns>
                    <asp:TemplateField HeaderText="Phone Type" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVPhoneType"><%# Eval("DirectoryTypeDesc")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country Code" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVCountryCode"><%# Eval("CountryCode")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area Code" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVAreaCode"><%# Eval("AreaCode")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone Number" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVPhoneNumber"><%# Eval("PhoneNumber")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Extension" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVPhoneExtension"><%# Eval("PhoneExt")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVPhoneContact"><%# Eval("PersonToContact")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div runat="server" id="DVPhonePrimary"><%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>"%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnEditPhone" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="UpdatePhone" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="gradient_gris">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnDeletePhone" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="DeletePhone" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

            </asp:GridView>
            <asp:HiddenField ID="hfdPhone" runat="server" />
        </div>
        <!-- //PHONE NUMBERS  -->
    </li>
</ul>
