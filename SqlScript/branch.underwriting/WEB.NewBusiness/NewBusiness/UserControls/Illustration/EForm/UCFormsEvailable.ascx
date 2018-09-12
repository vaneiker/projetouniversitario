<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFormsEvailable.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.EForm.UCFormsEvailable" %>
<div class="col-1-2-1-a">
    <div class="titulos_sin_accion">FORMS AVAILABLE</div>
    <div class="fondo_blanco fix_height">
        <!--<div class="titulos_azules"><span class="insured"></span><strong>PLAN INFORMATION</strong></div>-->
        <div class="content_fondo_blanco">
            
            <div id="menu-2">
                <div class="st-effect-2" id="scroll_1">

                    <!-- perfil del agente part-->
                    <div class="accordion-2">
                        <ul id="accordeonEforms" class="principal">
                            <asp:Repeater ID="rtCategory" runat="server" OnItemDataBound="rtCategory_ItemDataBound">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfCategoryID" Value='<%# DataBinder.Eval(Container.DataItem, "FormCategoryId") %>' runat="server" />
                                    <li class="menu_left" ><a href="#item1">
                                        <h2 class="sub_div_menu"><%# Eval("FormCatDesc") %></h2>
                                    </a>
                                        <ul class="max-height" style="list-style: decimal;">

                                            <asp:Repeater ID="rtCategoryForms" runat="server">
                                                <ItemTemplate>
                                                    <li class="btn_izquierda">
                                                        <asp:LinkButton ID="btnFormView" runat="server"  CommandName='<%# DataBinder.Eval(Container.DataItem, "FormId") %>'
                                                            OnClick="lnkCategory_Click">
                                                               <%# DataBinder.Eval(Container.DataItem, "FormDesc") %>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ItemTemplate>

                            </asp:Repeater>
                        </ul>
                        <%--    <ul id="accordeonEforms" class="principal">
                            <!--menu-->
                            <li class="menu_left" id="current"><a href="#item1">
                                <h2 class="sub_div_menu">All</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Applications-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Life Insurance Application</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Annuities Application</a>
                                    </li>

                                    <!--Avocation Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Caving and SPELUNKING Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Climbing and Mountaineering Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda  activo">
                                        <a class="" href="#">Motor Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Parachuting Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Private Aviation Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Sailing Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Scuba Diving Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Winter Sport Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Hunting and Firearm use Questionnarie</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Self Defense Sport Questionnaire</a>
                                    </li>

                                    <!--Cancellation-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Policy Cancellation Request</a>
                                    </li>

                                    <!--Changes-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Changes to Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Changes to Personal Information</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Rehabilitation Request</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Loss Claim (beneficiary)</a>
                                    </li>

                                    <!--Financial Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Financial Statement Questionnaires</a>
                                    </li>
                                    <!--<li class="btn_izquierda">
                                                                        <a class="" href="#">Others</a>
                                                                    </li>-->

                                    <!--Foreign Travel Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Foreign Travel and Residence Questionnaire</a>
                                    </li>

                                    <!--Medical Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Medical Report from Treating Physician</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Anxiety/ Depression Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Arthritis Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Asthma Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Attending Physician Statement</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Blood Pressure Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Coronary Artery Disease Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Diabetics Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Epilepsy Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Gynecological Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Mammoplasty Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Tumors Questionnaire</a>
                                    </li>

                                    <!--Occupation Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Commercial Aviation Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Commercial Diving Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Emergency Services Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Fishing Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Merchant Marine Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Mining & Quarrying Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Oil & Natural Gas Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Body Guard and Police Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Soccer Player Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">General Occupation Questionnaire</a>
                                    </li>

                                    <!--Payment/ Authorization-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Payment Authorization - Check</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Payment Autorizacion - Credit Card</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">STL Wire Transfer Instructions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">STL Wire Transfer Instructions for EUROS</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Client's Payment Authorization</a>
                                    </li>

                                    <!--Policies Forms/Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Source Doc</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Investment Profiles - Changes</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Questionnaire for Diabetics</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Questionnaire for Hypertensive Patients</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Questionnaire - Passengers</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Questionnaire - Pilots</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Hunting and Shooting Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Dangerous or Extreme Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Self Defense Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Financial Statement Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Merchant Marine Questionnaire</a>
                                    </li>

                                    <!--Returns / Payments-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Control de Cheques</a>
                                    </li>

                                    <!--Applications-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Guaranteed Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Conditions for Temporary Products</a>
                                    </li>

                                    <!--Financial Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Others</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Applications</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Applications-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Life Insurance Application</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Annuities Application</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Guaranteed Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Acknowledgement of Conditions for Temporary Products</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Avocation Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Avocation Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Caving and SPELUNKING Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Climbing and Mountaineering Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Motor Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Parachuting Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Private Aviation Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Sailing Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Scuba Diving Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Winter Sport Questionnaire </a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Hunting and Firearm use Questionnarie</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Self Defense Sport Questionnaire</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Cancellation</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Cancellation-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Policy Cancellation Request</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Changes</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Changes-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Changes to Conditions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Changes to Personal Information</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Rehabilitation Request</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Loss Claim (beneficiary)</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Financial Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Financial Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Financial Statement Questionnaires</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Others</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Foreign Travel Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Foreign Travel Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Foreign Travel and Residence Questionnaire</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Medical Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Medical Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Medical Report from Treating Physician</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Anxiety/ Depression Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Arthritis Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Asthma Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Attending Physician Statement</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Blood Pressure Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Coronary Artery Disease Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Diabetics Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Epilepsy Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Gynecological Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Mammoplasty Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Tumors Questionnaire</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Occupation Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Occupation Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Commercial Aviation Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Commercial Diving Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Emergency Services Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Fishing Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Merchant Marine Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Mining & Quarrying Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Oil & Natural Gas Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Body Guard and Police Questionnaire </a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Soccer Player Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">General Occupation Questionnaire</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Payment/Authorization</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Payment/ Authorization-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Payment Authorization - Check</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Payment Autorizacion - Credit Card</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">STL Wire Transfer Instructions</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">STL Wire Transfer Instructions for EUROS</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Client's Payment Authorization</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Policies Forms/Questionnaires</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Policies Forms/Questionnaires-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Source Doc</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Investment Profiles - Changes</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Questionnaire for Diabetics</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Questionnaire for Hypertensive Patients</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Questionnaire - Passengers</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Aviation Questionnaire - Pilots</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Hunting and Shooting Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Dangerous or Extreme Sports Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Self Defense Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Financial Statement Questionnaire</a>
                                    </li>
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Merchant Marine Questionnaire</a>
                                    </li>
                                </ul>
                            </li>

                            <li class="menu_left"><a href="#item1">
                                <h2 class="sub_div_menu">Returns / Payments</h2>
                            </a>
                                <ul class="max-height" style="list-style: decimal;">
                                    <!--Returns / Payments-->
                                    <li class="btn_izquierda">
                                        <a class="" href="#">Control of Payments by Check</a>
                                    </li>
                                </ul>
                            </li>
                            <!--end menu-->


                        </ul>--%>
                        <!--end ul acordeon-->

                    </div>
                    <!--accordion-->
                </div>
                <!--st-menu st-effect-2-->
            </div>
            <!-- id menu-2 -->


        </div>
        <!--content_fondo_blanco-->
    </div>
    <!--fondo_blanco-->
</div>
<!--col-1-4-c-->
