<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHealthView.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCHealthView" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationsVehicle/UCHsuplementos.ascx" TagPrefix="uc1" TagName="UCHsuplementos" %>
<%@ Register Src="~/NewBusiness/UserControls/IllustrationsVehicle/UCHdependientes.ascx" TagPrefix="uc1" TagName="UCHdependientes" %>

 <div class="wrapper wrapper-fluid box_shw agent_cont">
            <!-- Contenedor -->
            <div class="row blue cotizacion">
                <div class="agent_fbox">
                    <div class="row_A cont_tabs mB">
                        <ul id="ulTabsseg" class="tabs " data-ks-tabs>
                            <!--<asp:Literal runat="server" id="Literal1" EnableViewState="false" />-->
                            <li class=""><a id="iddependientes"  onclick="btndependientes.click()" href="javascript:void(0)">Dependientes</a><i class="arr_ico"></i></li>
                            <li class=""><a id="idsuplementos" onclick="btnsuplementos.click();" href="javascript:void(0)">Suplementos</a></li>
                        </ul>

                        <div id="divInsuredAmount" class="cont_gnl tab_pane_container ">

                            <article id="h_dependientes">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel2" >
                                    <ContentTemplate>
                                        <uc1:UCHdependientes runat="server" ID="ucHdependientes"  />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </article>

                            <article id="h_suplementos" >
                                <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                    <ContentTemplate>
                                        <div id="divsuplementos">
                                        <uc1:UCHsuplementos runat="server" ID="ucHsuplementos"/>
                                            </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel> 
                            </article>

                            <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                <ContentTemplate>
                                   <asp:Button runat="server" ID="btndependientes" ClientIDMode="Static"  OnClick="btndependientes_Click"  style="display:none;"/>
                                    <asp:Button runat="server" ID="btnsuplementos" ClientIDMode="Static"  OnClick="btnsuplementos_Click"  style="display:none;"/>
                                </ContentTemplate>
                                <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btndependientes" EventName="Click" />
                            </Triggers>
                                  <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnsuplementos" EventName="Click" />
                            </Triggers>

                            </asp:UpdatePanel>
                        </div>
                        <!--// END .tab_pane_container-->
                    </div>

                </div>

            </div>
            <!--// Contenedor -->
        </div>