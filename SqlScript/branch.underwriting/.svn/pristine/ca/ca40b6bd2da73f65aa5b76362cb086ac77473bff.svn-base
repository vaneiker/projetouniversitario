<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSearch.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.Common.WUCSearch" %>
<asp:UpdatePanel runat="server" ID="udpSearch">
    <ContentTemplate>
        <div class="titulos_sin_accion02">
            <asp:Literal runat="server" ID="ltTitle" Text="SUBMITTED POLICIES ON DATA REVIEW" />
        </div>
        <div class="barra1 no_padding">
            <asp:Panel runat="server" class="barra1 no_padding" DefaultButton="btnSearch" ID="pnSearch">
                <div class="filter">
                    <div class="grupos de_7">
                        <div>
                            <label class="label" runat="server" id="Policy">Policy</label>
                            <asp:TextBox runat="server" ID="txtPolicy" ClientIDMode="Static" Policy = 'Policy' />
                        </div>
                        <div>
                            <label class="label" runat="server" id="Plan">Plan</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlPlan" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label class="label" runat="server" id="From">From</label>
                            <asp:TextBox runat="server" ID="FromTxt" CssClass="datepicker" ClientIDMode="Static" />
                        </div>
                        <div>
                            <label class="label" runat="server" id="To">To</label>
                            <asp:TextBox runat="server" ID="ToTxt" CssClass="datepicker" ClientIDMode="Static" />
                        </div>
                        <div>
                            <label class="label" runat="server" id="AgentName">Agent Name</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="ddlAgents" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div>
                            <label class="label" runat="server" id="InsuredName">Insured Name</label>
                            <asp:TextBox runat="server" ID="InsuredNameTxt" ClientIDMode="Static" alphabetical='alphabetical' />
                        </div>
                        <div>
                            <label class="label" runat="server" id="OwnerName">Owner Name</label>
                            <asp:TextBox runat="server" ID="OwnerNameTxt" ClientIDMode="Static" alphabetical='alphabetical'/>
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grupos">
                        <div class="float_right">
                            <div class="boton_wrapper verde">
                                <span class=" search"></span>
                                <asp:Button CssClass="boton" Text="Search" runat="server" ID="btnSearch" ClientIDMode="Static" OnClick="btnSearch_Click"  OnClientClick="return validateDate()"/>
                            </div>
                            <div class="boton_wrapper gris">
                                <span class="borrar"></span>
                                <asp:Button CssClass="boton" Text="Clear" runat="server" OnClick="btnClear_Click" ID="btnClear" />
                            </div>
                        </div>
                    </div>
                    <!--grupos-->

                </div>
                <!--filter-->
            </asp:Panel>

            <!--filter-->
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
