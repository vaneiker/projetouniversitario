<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSistemMainMenu.ascx.cs" Inherits="WEB.NewBusiness.Common.UserControls.WUCSistemMainMenu" %>
<!--menu-->
<li class="menu_left"><a href="#item1" id="current"><span></span>
    <h4>Menu</h4>
</a>
    <ul id="Menu">
        <li>
            <h2 class="sub_div_menu"><%=RESOURCE.UnderWriting.NewBussiness.Resources.NewBusiness %></h2>

            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkClientInfo" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.AddNewCaseLabel %> </asp:LinkButton>

            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkCasesInProcess" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.CasesInProcessLabel %> </asp:LinkButton>

            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkReadyToReview" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)">  <%=RESOURCE.UnderWriting.NewBussiness.Resources.ReadyToReviewLabel %></asp:LinkButton>

            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkSubmitted" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SubmittedPoliciesLabel %>  </asp:LinkButton>

            <%--<asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenuLnkExceptions" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.Exceptions %> </asp:LinkButton>--%>

            <h2 class="sub_div_menu"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContactManagement %></h2>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkContactList" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ContactsList %>  </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkAddNewContact" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.AddNewContact %> </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkIllustrationsTab" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.Illustration %> </asp:LinkButton>

            <h2 class="sub_div_menu"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Reporting %></h2>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkIllustrations" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.Illustrations %> </asp:LinkButton>
            <%--<asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkIllustrationsLife" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.IllustrationsLife %> </asp:LinkButton>--%>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenulnkReports" ClientIDMode="Static" OnClick="ManageLinkTabs" OnClientClick="return CorfimRedirect(this)"> <%=RESOURCE.UnderWriting.NewBussiness.Resources.Reports %> </asp:LinkButton>

            <h2 class="sub_div_menu" runat="server" id="HeaderAdminAgent"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AdminAgent %></h2>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenuNewAgent" ClientIDMode="Static" OnClick="lnkRedirectModule_Click" path="AdminNewAgent" appname="VirtualOffice">  <%=RESOURCE.UnderWriting.NewBussiness.Resources.NewAgent %> </asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="btn_izquierda" ID="MenuAgentList" ClientIDMode="Static" OnClick="lnkRedirectModule_Click" path="AdminListAgent" appname="VirtualOffice">  <%=RESOURCE.UnderWriting.NewBussiness.Resources.AgentList %> </asp:LinkButton>
            
            <asp:Panel runat="server" ID="pnUserTest">
                <h2 class="sub_div_menu" runat="server" id="H1">User Test</h2>
            <asp:DropDownList runat="server" ID="cbkUsers" AutoPostBack="true" OnSelectedIndexChanged="cbkUsers_SelectedIndexChanged">              
            </asp:DropDownList>
            </asp:Panel>
           
        </li>
    </ul>
</li>
<!--end menu-->
