<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSearch.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.ContactsInfo.WUCSearch" %>
<asp:UpdatePanel runat="server" ID="udpSearch">
    <ContentTemplate>
        <div class="barra1 no_padding">
            <div class="filter">
                <div class="grupos de_4">
                    <asp:panel runat="server" ID="pnDdlOffice" Visible="false">
                        <label  runat="server" id="lblOffice" class="label red">Office</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_Office" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddl_Office_SelectedIndexChanged"></asp:DropDownList>
                        </div>                         
                    </asp:panel>
                    <div>
                        <label  runat="server" id="lblAgentName" class="label red">Agent Name</label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_P_ANC_AgentName" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddl_P_ANC_AgentName_SelectedIndexChanged"></asp:DropDownList>
                        </div>                         
                    </div>
                    <div>
                        <label class="label red">
                            <asp:Literal runat="server" Text="Relationship With Insured" ID="lblRelationShip" />
                        </label>
                        <div class="wrap_select">
                            <asp:DropDownList runat="server" ID="ddl_P_ANC_Relationship" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddl_P_ANC_Relationship_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </div>
                </div>
                <!--grupos-->
                <div class="grupos de_4">
                    <asp:Panel runat="server" class="label_check" ID="pnOwnerIsSameAsInsured">
                        <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkOwnerIsSameAsInsured" AutoPostBack="true" onclick="BeginRequestHandler()" OnCheckedChanged="chkOwnerIsSameAsInsured_CheckedChanged" />
                        <label runat="server" id="OwnerisSameAsInsured" class="label">Owner is same as Insured</label>
                    </asp:Panel>

                    <asp:Panel runat="server" class="label_check" ID="pnIsCompany">
                        <asp:CheckBox runat="server" OnCheckedChanged="chkIsCompany_CheckedChanged" ClientIDMode="Static" AutoPostBack="true" onclick="BeginRequestHandler()" ID="chkIsCompany" />
                        <label class="label" runat="server" id="OwnerisACompany">Owner is a Company</label>
                    </asp:Panel>
                </div>
            </div>
            <!--filter-->
            <div ID="pnSearch" class="client_searchbox">
                <asp:CheckBox runat="server" ID="chkClientorOwnerAlreadyinContacts" ClientIDMode="Static"/>
                <label class="label">
                    <asp:Literal runat="server" ID="ltSearch"> If Client already in contacts search here</asp:Literal>
                </label>
                <asp:TextBox runat="server" CssClass="custom_search" ClientIDMode="Static" ID="txtClientSearch" onkeydown = "return (event.keyCode!=13);" onclick="validateAgent(this)" />
            </div>
            <!--client_searchbox-->
        </div>
        <!--barra1-->
        <asp:Button runat="server" ID="btnCallSearchOwnerInfo" ClientIDMode="Static" OnClick="btnCallSearch_Click" Style="display: none" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnCallSearchOwnerInfo" />
        <asp:PostBackTrigger ControlID="chkOwnerIsSameAsInsured" />
        <asp:PostBackTrigger ControlID="chkIsCompany" />
        <asp:AsyncPostBackTrigger ControlID="ddl_P_ANC_AgentName" />
        <asp:AsyncPostBackTrigger ControlID="ddl_P_ANC_Relationship" />
        <asp:AsyncPostBackTrigger ControlID="ddl_Office" />        
    </Triggers>
</asp:UpdatePanel>
