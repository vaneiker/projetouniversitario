<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCTopMenu.ascx.cs" Inherits="WEB.NewBusiness.Common.UserControls.WUCTopMenu" %>
<div class="wrapper wrapper-fluid box_shw">
    <div class="main_menu menu2">
        <div class="box_logo">
            <asp:LinkButton runat="server" ID="lnkLogo" class="logo">
                <span class="letter" runat="server" id="spSytemName"></span>
            </asp:LinkButton>
            <asp:HiddenField runat="server" ID="hdnVersion" ClientIDMode="Static" />
        </div>
        <!--Menu Mobile DTL-->
        <div data-ks-navbar class="nav navbar">
            <nav>
                <ul>
                    <li class="active">Men&uacute;
                        <ul class="mT22">
                            <li class="">
                                <asp:LinkButton runat="server" ID="lnkDashboardMobile" path="Dashboard" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                    <span class="icon dashboard"></span>
                                    <span runat="server" id="DashboardMobile">DASHBOARD</span>
                                </asp:LinkButton>
                            </li>

                            <li class="">
                                <asp:LinkButton runat="server" ID="lnkClientsAndPoliciesMobile" class="" path="ClientsAndPolicies" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                    <span class="icon clients"></span>
                                    <span runat="server" id="ClientsAndPoliciesMobile">CLIENTS AND POLICIES</span>
                                </asp:LinkButton>
                            </li>

                            <li class="">
                                <a class="" onclick="Notify(this)">
                                    <span class="icon comisiones"></span>
                                    <span runat="server" id="CommissionsMobile">COMMISSIONS</span>
                                </a>
                            </li>

                            <li class="">
                                <asp:LinkButton runat="server" ID="lnkPaymentsMobile" class="" path="Payments" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                    <span class="icon pagos"></span>
                                    <span runat="server" id="PaymentsMobile">PAYMENTS</span>
                                </asp:LinkButton>
                            </li>

                            <li class="">
                                <asp:LinkButton runat="server" ID="lnkCancellationsMobile" class="" path="Cancellations" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                    <span class="icon cancelaciones"></span>
                                    <span runat="server" id="CancellationsMobile">CANCELLATIONS</span>
                                </asp:LinkButton>
                            </li>

                            <li class="">
                                <a class="" onclick="return false">
                                    <span class="icon formas"></span>
                                    <span class="" runat="server" id="formsAndCommunicationsMobile">FORMS & COMMUNICATIONS</span>
                                </a>

                                <ul class="" style="display: none;">

                                    <li class="">
                                        <a href="#" onclick="Notify(this)"><b class="mn_auto"></b>
                                            <span runat="server" id="CommunicationsMobile">CONMUNICATIONS</span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <asp:LinkButton runat="server" ID="lnkFormsMobile" path="Forms" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                            <b class="mn_auto"></b>
                                            <span runat="server" id="FormsMobil">Forms</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li class="">
                                        <asp:LinkButton runat="server" ID="lnkInvestmentsMobile" path="InvestmentReturns" appname="VirtualOffice" OnClick="lnkRedirectModule_Click" href="#">
                                            <b class="mn_auto"></b>
                                            <span runat="server" id="InvestmentsMobile">Investments</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li class="">
                                        <asp:LinkButton runat="server" ID="lnkReturnsMobile" path="InvestmentReturns" appname="VirtualOffice" OnClick="lnkRedirectModule_Click" href="#">
                                            <b class="mn_auto"></b>
                                            <span runat="server" id="ReturnsMobile">Returns</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li class="">
                                        <a href="#" onclick="Notify(this)"><b class="mn_auto"></b>
                                            <span runat="server" id="BrochureMobile">Brochure</span>
                                        </a>
                                    </li>
                                </ul>
                            </li>

                            <li class="">
                                <a href='<%=System.Configuration.ConfigurationManager.AppSettings["TrainingCenterUrl"] %>'>
                                    <span class="icon entretenimiento"></span>
                                    <span runat="server" id="TrainingCenterMobile">TRAINING CENTER</span>
                                </a>
                            </li>

                            <li class="">
                                <asp:LinkButton runat="server" ID="lnkContactsMobile" class="" OnClick="lnkContacts_Click">
                                    <span class="icon contactos"></span>
                                    <span runat="server" id="ContactsMobile">CONTACTS</span>
                                </asp:LinkButton>
                            </li>

                            <li class="">
                                <a class="">
                                    <span class="icon ventas"></span>
                                    <span class="" runat="server" id="SalesMobile">SALES</span>
                                </a>

                                <ul class="" style="display: none;">
                                    <li class="">
                                        <a onclick="Notify(this)"><b class="mn_auto"></b>
                                            <span runat="server" id="SalesSubMenuMobile">Sales
                                            </span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <asp:LinkButton runat="server" ID="lnkIllustrationMobile" OnClick="lnkIllustration_Click">
                                            <b class="mn_auto"></b>
                                            <span runat="server" id="IllustrationsMobile">Illustrations</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li class="">
                                        <asp:LinkButton runat="server" ID="lnkPendingMobile" path="Pending" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                            <b class="mn_auto"></b>
                                            <span runat="server" id="PendingMobile">Pending</span>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>
        </div>
        <!--// Menu Mobile DTL-->
        <div id="menu" class="nav">
            <ul>
                <li class="dropdown">
                    <asp:LinkButton runat="server" ID="lnkDashboard" path="Dashboard" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                        <span class="icon dashboard"></span>
                        <span runat="server" id="Dashboard" class="txt_lb">DASHBOARD</span>
                    </asp:LinkButton>
                    <%--<div class="name_dd"></div>
                    <ul class="drop-nav">
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkPolicyView"  path="Dashboard" appname="VirtualOffice"  OnClick="lnkRedirectModule_Click" ClientIDMode="Static">
                                            <b class="mn_auto"></b><%=RESOURCE.UnderWriting.NewBussiness.Resources.PolicyMenu %>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkProductivityView"  path="Dashboard?v=1" appname="VirtualOffice"  OnClick="lnkRedirectModule1_Click" ClientIDMode="Static">
                                            <b class="mn_auto"></b><%= RESOURCE.UnderWriting.NewBussiness.Resources.ProductivityMenu %>
                            </asp:LinkButton>
                        </li>

                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkProductivityCollView"  path="Dashboard" appname="VirtualOffice"  OnClick="lnkRedirectModule2_Click" ClientIDMode="Static">
                                            <b class="mn_auto"></b><%= RESOURCE.UnderWriting.NewBussiness.Resources.ProductivityCobranzas %>
                            </asp:LinkButton>
                        </li>
                    </ul>--%>
                </li>

                <li class="dropdown">
                    <asp:LinkButton runat="server" ID="lnkClientsAndPolicies" class="" path="ClientsAndPolicies" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                        <span class="icon clients"></span>
                        <span runat="server" id="ClientsAndPolicies">CLIENTS AND POLICIES</span>
                    </asp:LinkButton>
                </li>
                <li class="dropdown">
                    <a class="" onclick="Notify(this)">
                        <span class="icon comisiones"></span>
                        <span runat="server" id="Commisions">COMMISSIONS</span>
                    </a>
                </li>
                <li class="dropdown">
                    <asp:LinkButton runat="server" ID="lnkPayments" class="" path="Payments" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                        <span class="icon pagos"></span>
                        <span runat="server" id="Payments">PAYMENTS</span>
                    </asp:LinkButton>
                </li>

                <li class="dropdown">
                    <asp:LinkButton runat="server" ID="lnkCancelations" class="" path="Cancellations" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                        <span class="icon cancelaciones"></span>
                        <span runat="server" id="Cancelations">CANCELLATIONS</span>
                    </asp:LinkButton>
                </li>

                <li class="dropdown">
                    <a class="" onclick="return false">
                        <span class="icon formas"></span>
                        <span class="txt_lb" runat="server" id="formsAndCommunications">FORMS & COMMUNICATIONS</span>
                    </a>

                    <div class="name_dd"></div>
                    <ul class="drop-nav">
                        <li class="flyout">
                            <a href="#" onclick="Notify(this)"><b class="mn_auto"></b>
                                <span runat="server" id="Communications">Communications
                                </span>
                            </a>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkForms" path="Forms" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Forms">Forms
                                </span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkInvestments" path="InvestmentReturns" appname="VirtualOffice" OnClick="lnkRedirectModule_Click" href="#">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Investments">Investments
                                </span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkReturns" path="InvestmentReturns" appname="VirtualOffice" OnClick="lnkRedirectModule_Click" href="#">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Returns">Returns</span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <a href="#" onclick="Notify(this)"><b class="mn_auto"></b>
                                <span runat="server" id="Brochure">Brochure
                                </span>
                            </a>
                        </li>
                    </ul>
                </li>

                <li class="dropdown">

                    <a runat="server" id="lnkTrainingCenter_M2">
                        <span class="icon entretenimiento"></span>
                        <span runat="server" class="txt_lb" id="TrainingCenter">TRAINING CENTER</span>
                    </a>
                    <%-- <asp:LinkButton runat="server" ID="lnkTrainingCenter_M" ClientIDMode="Static">
                        <span class="icon entretenimiento"></span>
                        <span runat="server" class="txt_lb" id="TrainingCenter">TRAINING CENTER</span>
                    </asp:LinkButton>--%>

                    <div class="name_dd"></div>
                    <ul class="drop-nav">
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="LinkButton1" path="TrainingCenterGrid" appname="VirtualOffice" OnClick="lnkRedirectModule_Click">
                                                <b class="mn_auto"></b>PRODUCT TRAINING
                            </asp:LinkButton>
                        </li>
                    </ul>


                    <%--<a class="" onclick="Notify(this)">
                        <span class="icon entretenimiento"></span>
                        <span runat="server" id="TrainingCenter">TRAINING CENTER</span>
                    </a>--%>
                </li>


                <li class="dropdown">
                    <asp:LinkButton runat="server" ID="lnkContacts" class="" OnClick="lnkContacts_Click">
                        <span class="icon contactos"></span>
                        <span runat="server" id="Contacts">CONTACTS</span>
                    </asp:LinkButton>
                </li>

                <li class="dropdown">
                    <a class="" onclick="return false">
                        <span class="icon ventas"></span>
                        <span class="txt_lb" runat="server" id="Sales">SALES</span>
                    </a>
                    <div class="name_dd"></div>
                    <ul class="drop-nav">
                        <%--    <li class="flyout">                                                                                                   
                            <asp:LinkButton runat="server" ID="lnkSales" path="Home/Index" appname="SalesPoint" OnClick="lnkRedirectModule_Click" OnClientClick="window.document.forms[0].target='_blank';">
                                <b class="mn_auto"></b>
                                <span runat="server" id="SalesSubMenu">Point of Sale</span>
                            </asp:LinkButton>
                        </li>--%>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkIllustration"  CommandArgument="Auto" OnClick="lnkIllustration_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Illustrations">Illustrations</span>
                            </asp:LinkButton>
                        </li>

                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="LinkButton2" CommandArgument="Propiedad" OnClick="lnkIllustration_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="IllustrationGeneral">Illustration General</span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkillustationlife" OnClick="lnkillustationlife_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Illustrationslife">Illustrations Life</span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkAuto" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkAuto_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Span1">Punto Venta Auto </span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkHealth" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkHealth_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Span2">Punto Venta Salud</span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkLineaAleada" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkLineaAleada_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Span3">Punto Venta Comerciales</span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnkVivienda" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkVivienda_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Span4">Punto Venta Vivienda </span>
                            </asp:LinkButton>
                        </li>
                        <li class="flyout">
                            <asp:LinkButton runat="server" ID="lnlPending" path="Pending" appname="VirtualOffice" OnClientClick="return CorfimRedirect(this)" OnClick="lnkRedirectModule_Click">
                                <b class="mn_auto"></b>
                                <span runat="server" id="Pending">Pending </span>
                            </asp:LinkButton>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <!--menu class nav-->

    </div>
    <!--//main menu-->
</div>
