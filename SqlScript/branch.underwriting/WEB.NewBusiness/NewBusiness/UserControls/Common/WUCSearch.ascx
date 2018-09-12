<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSearch.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.PlanPolicy.WUCSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/PlanPolicy/WUCIllustrationPopup.ascx" TagPrefix="uc1" TagName="WUCIllustrationPopup" %>
<asp:UpdatePanel runat="server" ID="udpSearch" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="barra1 no_padding">
            <div class="filter">
                <div class="grupos de_5">
                    <div>
                        <label class="label" runat="server" id="Policy">Policy #</label>
                        <asp:TextBox ID="txtPolicy" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="FirstName">First Name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="true" disabled ></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="MiddleName">Middle Name</label>
                        <asp:TextBox ID="txtMiddleName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="LastName">Last Name</label>
                        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                    <div>
                        <label class="label" runat="server" id="SecondLastName">2nd Last Name</label>
                        <asp:TextBox ID="txtSecondLastName" runat="server" ReadOnly="true" disabled></asp:TextBox>
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--filter-->
            <asp:Panel runat="server" class="client_searchbox" ID="pnsearch">
                <asp:CheckBox runat="server" />
                <label class="label" runat="server" id="IllustrationSearch">If Illustration already made , search here</label>
                <asp:TextBox runat="server" class="custom_search" onclick="$('#btnShowPopIllustrations').click();" onkeydown="return (event.keyCode!=13);" />
            </asp:Panel>
            <!--client_searchbox-->
        </div>
        <asp:ModalPopupExtender ID="ModalPopupIllustrations" BackgroundCssClass="modalPopup2" PopupControlID="pnIllustrations" TargetControlID="hfIllustrations" BehaviorID="popupIllustrations" runat="server">
        </asp:ModalPopupExtender>
        <asp:Panel runat="server" ID="pnIllustrations" ClientIDMode="Static" style="display:none">           
            <uc1:WUCIllustrationPopup runat="server" ID="WUCIllustrationPopup" />
        </asp:Panel>
        <asp:HiddenField runat="server" ID="hfIllustrations" ClientIDMode="Static" value="false"/>
        <asp:Button runat="server" OnClick="btnShowPopIllustrations_Click" ID="btnShowPopIllustrations" ClientIDMode="Static" Style="display: none" />
    </ContentTemplate>
</asp:UpdatePanel>

