<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeaderIllustrationInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.UCHeaderIllustrationInformation" ClientIDMode="Static" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="accordion_tabulado">
            <ul class="principal" id="acc1">
                <li>
                    <a href="#item1" id="current">
                        <asp:Literal runat="server" ID="ltPlanType"></asp:Literal>
                        <%=RESOURCE.UnderWriting.NewBussiness.Resources.Illustration %> / <%=RESOURCE.UnderWriting.NewBussiness.Resources.INSURED.ToUpper() %><span><!--icono--></span></a>
                    <ul>
                        <li>
                            <div class="barra1 no_padding">
                                <div class="filter">
                                    <div class="grupos de_6">
                                        <div>
                                            <label class="label"><%=WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.ILLUSTRATIONNUMBERLabel) %></label>
                                            <asp:TextBox runat="server" ID="txtIllustrationNumber" Enabled="false" />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Status %></label>
                                            <asp:TextBox runat="server" ID="txtStatus" Enabled="false" />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FirstNameLabel %></label>
                                            <asp:TextBox runat="server" ID="txtFirstName" alphabetical='alphabetical' validation="Required" />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MiddleNameLabel %></label>
                                            <asp:TextBox runat="server" ID="txtMiddleName" alphabetical='alphabetical' />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.LastNameLabel %></label>
                                            <asp:TextBox runat="server" ID="txtLastName" alphabetical='alphabeticalLastName' validation="Required" />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SecondLastNameLabel %></label>
                                            <asp:TextBox runat="server" ID="txtSecondLastName" alphabetical='alphabeticalLastName' />
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FamilyProductLabel %></label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlFamilyProduct" OnSelectedIndexChanged="ddlFamilyProduct_SelectedIndexChanged" validation="Required" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label"><%=WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.PlanName) %></label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlPlanInformation" OnSelectedIndexChanged="ddlPlanInformation_SelectedIndexChanged" validation="Required" AutoPostBack="true">
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Office.ToLower() %></label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlOffice" validation="Required">
                                                    <asp:ListItem Text="Option 1" />
                                                    <asp:ListItem Text="Option 2" />
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td style="width: 50%; padding-right: 5px">
                                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.GenderLabel %></label>
                                                        <div class="wrap_select">
                                                            <asp:DropDownList runat="server" ID="ddlIllusGender" validation="Required">
                                                                <asp:ListItem Text="Option 1" />
                                                                <asp:ListItem Text="Option 2" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="width: 50%; padding-left: 5px">
                                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MaritalStatusLabel %></label>
                                                        <div class="wrap_select">
                                                            <asp:DropDownList runat="server" ID="ddlIllusMaritalStatus" validation="Required">
                                                                <asp:ListItem Text="Option 1" />
                                                                <asp:ListItem Text="Option 2" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.CountryOfResidenceLabel %></label>
                                            <div class="wrap_select">
                                                <asp:DropDownList runat="server" ID="ddlCountryResidence" validation="Required">
                                                    <asp:ListItem Text="Option 1" />
                                                    <asp:ListItem Text="Option 2" />
                                                </asp:DropDownList>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td style="width: 50%; padding-right: 5px">
                                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SmokerLabel %></label>
                                                        <div class="wrap_select">
                                                            <asp:DropDownList runat="server" ID="ddlSmoker" validation="Required">
                                                                <asp:ListItem Text="Yes" />
                                                                <asp:ListItem Text="No" />
                                                            </asp:DropDownList>
                                                        </div>
                                                        <!--wrap_select-->
                                                    </td>
                                                    <td style="width: 50%; padding-left: 5px">
                                                        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AgeLabel %></label>
                                                        <asp:TextBox runat="server" ID="txtAge" number='number3' validation="Required" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <!--grupos-->
                                </div>
                                <!--filter-->

                                <div class="client_searchbox">
                                    <asp:CheckBox runat="server" ID="chkClientSearch" ClientIDMode="Static" /><label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.If_owner_is_different_than_Main_Insured_search_here %></label>
                                    <asp:TextBox runat="server" ID="txtClientSearch" CssClass="custom_search" ReadOnly="true" />
                                    <asp:HiddenField runat="server" ID="hdnClientName" />

                                    <dx:ASPxPopupControl ID="ppcListClient" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcListClient" AllowDragging="True"
                                        PopupAnimationType="None" HeaderText="Contact">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl runat="server" Width="800px" Height="500px">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" OnUnload="UpdatePanel_Unload">
                                                    <ContentTemplate>
                                                        <dx:ASPxGridView ID="gvContactList"
                                                            DataSourceID="LinqDS" runat="server"
                                                            KeyFieldName="ContactId;FirstName;LastName"
                                                            EnableCallBacks="false"
                                                            Width="800px"
                                                            AutoGenerateColumns="False" OnPageIndexChanged="gvContactList_PageIndexChanged" OnAfterPerformCallback="gvContactList_AfterPerformCallback"
                                                            ClientSideEvents-RowClick="SelectRow">
                                                            <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
                                                            <Columns>
                                                                <dx:GridViewDataTextColumn Caption="First Name" Name="FirstNameLabel" FieldName="FirstName" VisibleIndex="0">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Last Name" Name="LastNameLabel" FieldName="LastName" VisibleIndex="1">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="ID Number" Name="IDNumberLabel" FieldName="IdNumber" VisibleIndex="2">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataDateColumn FieldName="DateOfBirth" Name="DateofBirthLabel" Caption="Date Of Birth" CellStyle-HorizontalAlign="Center">
                                                                    <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                                                                </dx:GridViewDataDateColumn>
                                                                <dx:GridViewDataTextColumn Caption="Country Of Resident" Name="CountryOfResidenceLabel" FieldName="Country" VisibleIndex="3">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataDateColumn FieldName="LastUpdate" Name="LastUpdateLabel" Caption="Last Update" CellStyle-HorizontalAlign="Center">
                                                                    <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                                                                </dx:GridViewDataDateColumn>
                                                            </Columns>
                                                            <Settings VerticalScrollableHeight="600" VerticalScrollBarMode="Visible" />
                                                            <SettingsPager PageSize="20" NumericButtonCount="3" AlwaysShowPager="true">
                                                                <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                                                            </SettingsPager>
                                                            <SettingsPopup>
                                                                <HeaderFilter Height="200" />
                                                            </SettingsPopup>
                                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                            <SettingsBehavior AllowFocusedRow="true" />
                                                        </dx:ASPxGridView>
                                                        <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="FirstName" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="gvContactList" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                </div>
                                <!--client_searchbox-->
                            </div>
                            <!--barra1-->
                        </li>
                    </ul>
                </li>
                <!--principal-->
            </ul>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlFamilyProduct" />
        <asp:AsyncPostBackTrigger ControlID="ddlPlanInformation" />
    </Triggers>
</asp:UpdatePanel>
