<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPropertyDetailFeature.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCPropertyDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div id="dvPropertyDetailForm" style="padding: 10px">
    <div class="">
        <fieldset>
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Product%></legend>
            <div class="bloqTransportDetail addDobleDynamic">
                <div class="row_B">
                    <asp:Panel ID="Panel_txt_producto" runat="server" class="label_plus_input par col-4">
                        <span>Producto</span>
                        <asp:TextBox runat="server" ID="txt_producto" ReadOnly="true"></asp:TextBox>
                    </asp:Panel>
                    <asp:Repeater runat="server" ID="rpCondiciones" OnItemDataBound="rpCondiciones_ItemDataBound">
                        <ItemTemplate>
                            <div class="label_plus_input par col-4">
                                <span><%# Eval("descripcion") %></span>
                                <asp:TextBox runat="server" ID="txtCondicion" Text='<%# Eval("valor") %>' ReadOnly="true"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:HiddenField ID="hdnProductName" runat="server" />
            </div>
        </fieldset>
        <fieldset style="height: 300px;" runat="server" id="fieldSetFeatures">
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.PropertyFeatures %></legend>
            <asp:Panel runat="server" ID="dvPropertyFeature" ClientIDMode="Static">
                <div>
                    <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" OnClick="btnAdd_Click" />
                </div>
                <asp:UpdatePanel runat="server" ID="udpGridView">
                    <ContentTemplate>
                        <dx:ASPxGridView
                            ID="gvPropertyDetailFeature"
                            runat="server"
                            EnableCallBacks="False"
                            KeyFieldName="UniquePropertyId;SeqId;PositionId;CertificateId;MeasureTypeId;DetailBuildTypeId;MaterialId;DetailPropertyStatId;RecessedOrScrewed"
                            ClientIDMode="Static"
                            AutoGenerateColumns="false"
                            Width="100%"
                            OnRowCommand="gvPropertyDetailFeature_RowCommand"
                            OnPreRender="gvPropertyDetailFeature_PreRender"
                            OnPageIndexChanged="gvPropertyDetailFeature_PageIndexChanged">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center" Name="Operation">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="grupos de_2" style="text-align: center">
                                                    <asp:Panel runat="server" ID="pnDelete">
                                                        <asp:LinkButton runat="server" ID="btnDelete"  CssClass="delete_file" CommandName="DeleteFeature" OnClientClick="return DlgConfirm(this);" />
                                                    </asp:Panel>
                                                    <div>
                                                        <asp:LinkButton runat="server" ID="btnEditOrSave" CssClass="myedit_file" CommandName="EditFeature" OnClientClick="return validateForm('dvPropertyFeature');" />
                                                    </div>
                                                    <div>
                                                        <asp:LinkButton runat="server" ID="btnCancel" Visible="false" CssClass="mycancel_file" CommandName="Cancel" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnEditOrSave" />
                                                <asp:AsyncPostBackTrigger ControlID="btnCancel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Description" Settings-AllowSort="true" Name="Description" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtDescription" Text='<%#Eval("Description")%>' label="Description" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltDescription" Text='<%#Eval("Description")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Brand" Settings-AllowSort="true" Name="Brand" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtBrand" Text='<%#Eval("Brand")%>' label="Brand" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltBrand" Text='<%#Eval("Brand")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Model" Settings-AllowSort="true" Name="Model" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtModel" Text='<%#Eval("Model")%>' label="Model" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltModel" Text='<%#Eval("Model")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Year" Settings-AllowSort="true" Name="Year" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtYear" Text='<%#Eval("Year")%>' label="Year" number="number4" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltYear" Text='<%#Eval("Year")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="SerialKey" Settings-AllowSort="true" Name="SerialKey" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtSerialKey" Text='<%#Eval("SerialKey")%>' label="Serial Key" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltSerialKey" Text='<%#Eval("SerialKey")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="AuthorLabel" Settings-AllowSort="true" Name="AuthorLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtAuthor" Text='<%#Eval("Author")%>' label="AuthorLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltAuthor" Text='<%#Eval("Author")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="CapacityLabel" Settings-AllowSort="true" Name="CapacityLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCapacity" Text='<%#Eval("Capacity")%>' label="CapacityLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltCapacity" Text='<%#Eval("Capacity")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Position" Settings-AllowSort="true" Name="Position" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:DropDownList ID="ddlPositionId" runat="server" Visible="false" validation="Required"></asp:DropDownList>
                                        <asp:Literal runat="server" ID="ltPositionId" Text='<%#Eval("PositionDesc")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="MeasureTypeLabel" Settings-AllowSort="true" Name="MeasureTypeLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:DropDownList ID="ddlMeasureTypeId" runat="server" Visible="false" validation="Required"></asp:DropDownList>
                                        <asp:Literal runat="server" ID="ltMeasureTypeId" Text='<%#Eval("MeasureTypeDesc")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="HeightLabel" Settings-AllowSort="true" Name="HeightLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtHeight" Text='<%#Eval("Height")%>' label="HeightLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltHeight" Text='<%#Eval("Height")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="WidthLabel" Settings-AllowSort="true" Name="WidthLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtWidth" Text='<%#Eval("Width")%>' label="WidthLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltWidth" Text='<%#Eval("Width")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="CertificateLabel" Settings-AllowSort="true" Name="CertificateLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:DropDownList ID="ddlCertificateId" runat="server" Visible="false" validation="Required"></asp:DropDownList>
                                        <asp:Literal runat="server" ID="ltCertificateId" Text='<%#Eval("CertificateDesc")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Quantity" Settings-AllowSort="true" Name="Quantity" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtQuantity" Text='<%#Eval("QuantityF")%>' label="Quantity" number="number" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltQuantity" Text='<%#Eval("QuantityF")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Value" Settings-AllowSort="true" Name="Value" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtValue" Text='<%#Eval("ValueF")%>' label="Value" decimal='decimal' validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltValue" Text='<%#Eval("ValueF")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Deductible" Settings-AllowSort="true" Name="Deductible" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtDeductible" Text='<%#Eval("DeductibleF")%>' label="Deductible" decimal='decimal' validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltDeductible" Text='<%#Eval("DeductibleF")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="MinimumDeductibleLabel" Settings-AllowSort="true" Name="MinimumDeductibleLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtMinimumDeductible" Text='<%#Eval("MinimumDeductibleF")%>' label="MinimumDeductibleLabel" decimal='decimal' validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltMinimumDeductible" Text='<%#Eval("MinimumDeductibleF")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsPager PageSize="8" AlwaysShowPager="true">
                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
                            <Settings ShowFooter="True" />
                        </dx:ASPxGridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvPropertyDetailFeature" />
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </fieldset>
    </div>
    <div style="height: 34px;"></div>
    <div style="float: right;">
        <asp:Panel runat="server" ID="pnGuardar" class="fl" Style="margin-left: 10px;" Visible="false">
            <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvPropertyDetailFeatureForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save%></span>
            </asp:LinkButton>
        </asp:Panel>
        <div class="fl" style="position: absolute; right: 10px; bottom: 10px;">
            <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel%>" onclick="ClosePopPropertyDetail();" />
        </div>
    </div>
</div>
