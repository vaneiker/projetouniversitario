<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCMainMenu.ascx.cs" Inherits="WEB.UnderWriting.Common.WUCMainMenu" %>
<asp:UpdatePanel ID="udpMainMenu" runat="server">
    <ContentTemplate>

        <div class="main_menu_atl menu2">
            <div class="box_logo">
                <asp:LinkButton ID="lnkCompanyLogo" runat="server" CssClass="logo_atl"></asp:LinkButton>
                <label id="lblSystem" runat="server" class="lblsystem">OFICINA VIRTUAL</label>
            </div>

            <div id="menu" class="nav">
                <ul>
                    <li>
                        <asp:LinkButton runat="server" ID="lnkDashboard" ClientIDMode="Static" PostBackUrl="~/Dashboard/Pages/Dashboard.aspx" CssClass="active">
                            <span class="icon dashboard"></span>
                            <asp:Label runat="server" ID="lblDashboard">
                             DASHBOARD
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkCOMMUNICATION" ClientIDMode="Static">
                            <span class="icon auto"></span>
                            <asp:Label runat="server" ID="lblCOMMUNICATION">
                             VEHICLE POLICIES
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkLifeAndAnnuittiesInsurance" ClientIDMode="Static" PostBackUrl="~/Case/Pages/Case.aspx">
                            <span class="icon p_vida"></span>
                            <asp:Label runat="server" ID="lblLifeAndAnnuittiesInsurance">
                        LIFE &amp; ANNUITIES INSURANCE 
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkGROUPPOLICIES" ClientIDMode="Static">
                            <span class="icon p_grupo"></span>
                            <asp:Label runat="server" ID="lblGROUPPOLICIES">
                          FIRE AND PROPERTIES
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkTRAVELPOLICIES" ClientIDMode="Static">
                            <span class="icon s_viaje"></span>
                            <asp:Label runat="server" ID="lblTRAVELPOLICIES">
                        HEALTH AND TRAVEL POLICIES
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkHEALTHPOLICIES" ClientIDMode="Static">
                            <span class="icon p_salud"></span>
                            <asp:Label runat="server" ID="lblHEALTHPOLICIES">
                           FUNERARY POLICIES
                            </asp:Label>
                        </asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton runat="server" ID="LnkREPORTINGTOOLS" ClientIDMode="Static">
                            <span class="icon ico_reporte"></span>
                            <asp:Label runat="server" ID="lblREPORTINGTOOLS">
                                COMMERCIAL POLICIES
                            </asp:Label>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
            <!--menu class nav-->
        </div>
        <!--main menu-->

        <asp:HiddenField ClientIDMode="Static" ID="hfCurrentTabSelected" runat="server" Value="LnkLifeAndAnnuittiesInsurance" />

    </ContentTemplate>
</asp:UpdatePanel>

