<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAddresses.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.UCAddresses" %>
<ul class="secundario" style="display: none;">
    <li>
        <asp:UpdatePanel ID="upAddresses" runat="server">
            <ContentTemplate>
                <div class="list_addresses">
                    <div class="boxes">
                        <div class="row mB">
                            <label class="label fl wd27 ReqField">
                                Address Type:
                            </label>
                            <asp:DropDownList ID="AddresTypeDDL" runat="server" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="box1 ">
                            <label class="label ReqField">Street Address:</label>
                            <asp:TextBox ID="StreetAdressTxt" runat="server" TextMode="MultiLine" class="hg80" ClientIDMode="Static"></asp:TextBox>

                        </div>
                        <div class="box2 ">
                            <label class="label ReqField">Country:</label>
                            <asp:DropDownList ID="CountryDDL" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged" ClientIDMode="Static">
                            </asp:DropDownList>
                            <label class="label ReqField">City:</label>
                            <asp:DropDownList ID="CityDDL" runat="server" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                        <div class="box3 ">
                            <label class="label wd67 ReqField">
                                State:
                            </label>
                            <asp:DropDownList ID="StateDDL" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="StateDDL_SelectedIndexChanged" ClientIDMode="Static">
                            </asp:DropDownList>
                            <div class=" fl wd50 mR-2-p">
                                <label class="label">Postal Code:</label>
                                <asp:TextBox ID="PostalCodeTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class=" alignC fl mR-2-p wd15">
                                <label class=" label">Primary</label>
                                <span class=" mT10 block">
                                    <asp:CheckBox ID="AddressPrimaryChk" runat="server" class="" />
                                </span>
                            </div>
                            <div class="fl wd30 mT10">
                                <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f">
                                    <span class="add"></span>
                                    <asp:Button ID="AddAddresBTN" runat="server" Text="Add" class="boton" OnClick="AddAddresBTN_Click" OnClientClick="return ValidateAddress();" />
                                    <asp:Button ID="EditAddressBTN" runat="server" Text="Save" class="boton" OnClick="EditAddressBTN_Click" OnClientClick="return ValidateAddress();" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--// .boxes -->

                    <div class="tbl data_G">
                        <asp:GridView ID="gvAddress" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvAddress_PageIndexChanging"
                            DataKeyNames="RegionId,CorpId, DirectoryId, DirectoryDetailId, CommunicationTypeId, DirectoryTypeId,CountryDesc,CityDesc,StateProvDesc,ZipCode,DirectoryTypeDesc,StreetAddress,IsPrimary,CountryId,StateProvId,DomesticregId,CityId">
                            <Columns>
                                <asp:TemplateField HeaderText="Address Type" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVAddress_Type"><%# Eval("DirectoryTypeDesc") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Street Address" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVStreet_Address"><%# Eval("StreetAddress") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVCountry_Desc"><%# Eval("CountryDesc") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVCity_Desc"><%# Eval("CityDesc") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVState_Prov_Desc"><%# Eval("StateProvDesc") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Postal Code" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div class="alignC" runat="server" id="DVZip_Code"><%# Eval("ZipCode") %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div runat="server" id="DVIs_Primary"><%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>" %></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Button ID="btnEditAddres" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="UpdateAddress" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="gradient_gris">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Button ID="btnDeleteAddres" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="DeleteAddress" OnClientClick="return DlgConfirm(this);" />
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
                        <asp:HiddenField ID="hdfRowIndex" runat="server" />
                        
                    </div>
                    <!--// tbl -->
                </div>
                <!--// .list_addresses -->
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CountryDDL" />
                <asp:AsyncPostBackTrigger ControlID="StateDDL" />
            </Triggers>
        </asp:UpdatePanel>
    </li>
</ul>


