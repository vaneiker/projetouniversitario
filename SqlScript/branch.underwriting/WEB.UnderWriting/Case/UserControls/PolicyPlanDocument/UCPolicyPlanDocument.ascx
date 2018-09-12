<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPolicyPlanDocument.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanDocument.UCPolicyPlanDocument" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="row" style="margin-top:5px;margin-bottom:5px;">
    <label class="">DOCUMENT TYPE:</label>
    <asp:DropDownList runat="server" ID="ddlDocumentType" AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentType_SelectedIndexChanged" CssClass="select_esp_dos" />
</div>


<div class="tbl data_G" style="margin-top:5px;">
    <asp:GridView ID="gvPolicyDocument"
        runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
        DataKeyNames="DocTypeId,DocCategoryId,DocumentId,HasDocument"
        AllowPaging="true" PageSize="9" OnPageIndexChanging="gvPolicyDocument_PageIndexChanging" OnRowDataBound="gvPolicyDocument_RowDataBound">
        <Columns>

            <asp:TemplateField HeaderText="Description" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("DocCategoryDesc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Document Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c">
                <ItemTemplate>
                    <asp:Label ID="lblDocumentDate" runat="server" Text='<%# Eval("DocumentDate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Upload Date" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("UploadDate", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="PDF's Files" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPdf" runat="server" CssClass="pdf_ico" OnClick="lnkPdf_Click" />
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

<asp:Button ID="btnShowPopup" Style="display: none" runat="server" Text="ShowPopup" />


<%--<div id="dvPdfPopUpPolicyDocument" style="display: none; padding: 0">
    <uc1:UCShowPDFPopup runat="server" id="UCShowPDFPopup" />
</div>--%>

<asp:HiddenField runat="server" ID="hfPdfPopUp" ClientIDMode="Static" Value="false" />
