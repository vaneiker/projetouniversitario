<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRiderInformation.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Riders.UCRiderInformation" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Src="~/Case/UserControls/Riders/UCRiderReason.ascx" TagPrefix="uc1" TagName="UCRiderReason" %>

<ul class="secundario" style="display: block; overflow: hidden;">
    <li class="riders_info fl last-child">
        <asp:UpdatePanel ID="upRiderInformation2" runat="server">
            <ContentTemplate>

                <div class="head">
                    <div class=" boxes mR-1-p">
                        <label class="label ReqField">Riders Type</label>
                        <asp:DropDownList ID="ddlRiderType" runat="server" ClientIDMode="Static" DataValueField="Value" DataTextField="Text" OnSelectedIndexChanged="ddlRiderType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <label class="label ReqField">Benefit Amount</label>
                        <asp:TextBox ID="txtBeneficiaryAmount" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class=" boxes mR-1-p">
                        <label class="label ReqField">Status</label>
                        <asp:DropDownList ID="ddlStatus" runat="server" ClientIDMode="Static" DataValueField="Value" DataTextField="Text"></asp:DropDownList>

                        <label class="label ReqField">Start Date</label>
                        <asp:TextBox ID="txtEffectiveDate" runat="server" ClientIDMode="Static" CssClass="datepicker alignL" Enabled="false"></asp:TextBox>
                    </div>
                    <div class=" boxes mR-1-p">
                        <label class="label ReqField">No. of Years</label>
                        <asp:TextBox ID="txtNumberOfYear" runat="server" alt="numberLeft" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class=" boxes dvEntityExtraPremium">
                        <label class="label">Extra Premium</label>
                        <asp:TextBox ID="txtExtraPremiumComment" TextMode="MultiLine" CssClass="hg80" runat="server" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="row mT20">
                        <div class="boton_wrapper gradient_RJ bdrRJ fr" runat="server" id="pnBtnCancel">
                            <span class="equis"></span>
                            <asp:Button runat="server" ID="btnCancel" CssClass="boton" Text="Cancel" OnClick="btnCancel_Click" Enabled="false" />
                        </div>

                        <%--2016-01-28 | Marcos J. Perez--%>
						<%--
						<div class="boton_wrapper gradient_vd bdrVd fr mR" runat="server" id="pnBtnDelete">
                            <span class="delbtn"></span>
                            <asp:Button runat="server" ID="btnDelete" CssClass="boton" Text="Delete" OnClick="btnDelete_Click" Enabled="false" OnClientClick="return DlgConfirm(this);" />
                        </div>

                        <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR" runat="server" id="pnBtnEdit">
                            <span class="edit"></span>
                            <asp:Button runat="server" ID="btnEdit" CssClass="boton" Text="Edit" ClientIDMode="Static" OnClick="btnEdit_Click" OnClientClick="return validateRiderFields(this);" />
                        </div>
						--%>

                        <div class="boton_wrapper gradient_AM_btn bdrAM fr mR" runat="server" id="pnBtnAdd">
                            <span id="spnAdd" runat="server" class="add"></span>
                            <asp:Button runat="server" ID="btnAdd" CssClass="boton" Text="Add" ClientIDMode="Static" OnClick="btnAdd_Click" OnClientClick="return validateRiderFields(this);" />
                        </div>
                    </div>
                </div>
                <div class="tbl-rider mB tbl data_G">
                    <asp:GridView ID="gvRiders" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                        DataKeyNames="RiderId,RiderTypeId,RiderStatusId,RyderTypeDesc,BeneficiaryAmount,EffectiveDate,ExpireDate,NumberOfYear,ExtraPremiumCommentCompleted" Autopostback="True"
                        OnRowCreated="gvRiders_RowCreated" OnRowDataBound="gvRiders_RowDataBound"
                        SelectedRowStyle-CssClass="selected_row" ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Riders Type" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                <ItemTemplate>
                                    <asp:Label ID="lblRyderTypeDesc" runat="server" Text='<%# Eval("RyderTypeDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c1">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("SEGFAMADCount") == null ? "" : int.Parse(Eval("SEGFAMADCount").ToString()).ToString() %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Benefit Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="c2">
                                <ItemTemplate>
                                    <asp:Label ID="lblBeneficiaryAmount" runat="server" Text='<%# Eval("BeneficiaryAmount")==null ? "": Decimal.Parse(Eval("BeneficiaryAmount").ToString()).ToString("N2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                <ItemTemplate>
                                    <asp:Label ID="lblEffectiveDate" runat="server" Text='<%# Eval("EffectiveDate")==null ? "": DateTime.Parse(Eval("EffectiveDate").ToString()).ToString("MM/dd/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Expire Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                <ItemTemplate>
                                    <asp:Label ID="lblExpireDate" runat="server" Text='<%# Eval("ExpireDate")==null ? "": DateTime.Parse(Eval("ExpireDate").ToString()).ToString("MM/dd/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Years" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumberOfYear" runat="server" Text='<%# Eval("NumberOfYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extra Premium" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6 dvEntityExtraPremiumColumn" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6 dvEntityExtraPremiumColumn">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblcomment" data='tooltip' Text='<%# Eval("ExtraPremiumCommentShort") %>' alt='<%# Eval("ExtraPremiumCommentCompleted") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Declined/Excluded Reason" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c7" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c7">
                                <ItemTemplate>
                                    <asp:Button ID="lnkAddCommentButton" CssClass="comment_add_icon" OnClick="lnkAddCommentButton_Click" runat="server" Style="background-color: transparent;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c8" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c8">
                                <ItemTemplate>
                                    <asp:Label ID="lblRiderStatusDesc" runat="server" Text='<%# Eval("RiderStatusDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
									<asp:LinkButton CommandArgument='<%# Container.DataItemIndex %>' CssClass="edit_file" ID="lnkEdit" OnClick="lnkEdit_Click" OnClientClick="return validateRiderFields(this);" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remove">
                                <ItemTemplate>
									<asp:Button CommandArgument='<%# Container.DataItemIndex %>' CssClass="delete_file" ID="btnRemove" OnClick="btnRemove_Click" OnClientClick="return DlgConfirm(this);" runat="server" style="background-color: transparent;" />
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
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="btnEdit" />--%>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                <%--<asp:AsyncPostBackTrigger ControlID="btnDelete" />--%>
                <asp:AsyncPostBackTrigger ControlID="gvRiders" />
                <asp:AsyncPostBackTrigger ControlID="ddlRiderType" />
            </Triggers>
        </asp:UpdatePanel>


    </li>
</ul>

<div id="dvRiderReason" style="display: none; padding: 0">
    <uc1:UCRiderReason runat="server" ID="UCRiderReason" />
</div>

<asp:HiddenField runat="server" ID="hfRiderReason" ClientIDMode="Static" Value="false" />

