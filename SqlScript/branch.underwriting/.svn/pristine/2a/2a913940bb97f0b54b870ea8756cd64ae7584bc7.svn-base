<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEduplan.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.PlanPolicy.Products.UCEduplan" %>
<div class="col-1-4-c">
    <div class="fondo_blanco fix_height">
        <div class="titulos_azules"><span class="insured"></span><strong><asp:Literal runat="server" ID="planinformation">PLAN INFORMATION</asp:Literal></strong></div>
        <asp:Panel runat="server" ClientIDMode="Static" class="content_fondo_blanco" id="frmPlan">
            <div class="grupos de_3">
                <div>
                    <label class="label red" runat="server" id="FamilyProduct">Family Product</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlFamilyProduct" runat="server" validation="Required" AutoPostBack="true" ></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="PlanName">Plan Name</label>
                    <div class="wrap_select"> 
                        <asp:DropDownList ID="ddlProductName" runat="server" validation="Required" AutoPostBack="true" >
                        </asp:DropDownList>  
                    </div>
                    <!--wrap_select-->
                </div>
                <asp:panel runat="server" ID="pnPlanType">
                    <label class="label red" runat="server" id="PlanType">Plan Type</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlPlanType" runat="server"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </asp:panel>
                <div>
                    <label class="label red" runat="server" id="Currency">Currency</label>
                    <div class="wrap_select">   
                        <asp:DropDownList ID="ddlCurrency" runat="server" validation="Required"  AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="FrequencyofPayment">Frequency of Payment</label>
                    <div class="wrap_select"> 
                        <asp:DropDownList ID="ddlFrequencyofPayment" ClientIDMode="Static" onchange="GetAnnualPremium('txtPeriodicPremium','ddlFrequencyofPayment')" runat="server" validation="Required"></asp:DropDownList>                        
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="ContributionPeriod">Contribution Period</label>
                    <asp:TextBox ID="txtContributionPeriod" validation="Required" runat="server" number="number2"  ClientIDMode="Static"></asp:TextBox>

                </div>
                <div>
                    <label class="label red" runat="server" id="DefermentPeriod">Deferment Period</label>
                    <div class="wrap_select"> 
                        <asp:DropDownList ID="ddlDefermentPeriod" runat="server" validation="Required" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label red" runat="server" id="EducationPeriod">Education Period</label>
                    <div class="wrap_select"> 
                        <asp:DropDownList ID="ddlEducationPeriod" runat="server" validation="Required" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
            </div>
            <!--grupos-->
            <fieldset class="margin_t_10">
                <legend><asp:Literal runat="server" ID="ltStudentInformation"> STUDENT INFORMATION</asp:Literal></legend>
                <div class="grupos de_2">
                    <div>
                        <label class="label red" runat="server" id="StudentName">Student Name</label>
                        <asp:TextBox ID="txtStudentName" alphabetical="alphabetical" runat="server" validation="Required"></asp:TextBox>
                    </div>
                    <div>
                        <label class="label red" runat="server" id="DateOfBirth">Date of Birth</label>
                        <asp:TextBox ID="txtAge" runat="server" CssClass="datepicker" alt="validateFutureDate" validation="Required"></asp:TextBox>

                    </div>
                </div>
                <!--grupos-->
            </fieldset>  
            <div class="break_line"></div>
            <div class="grupos de_2">
                <div>
                    <label class="label" runat="server" id="InitialContribution">Initial Contribution</label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlInitialContribution" runat="server" AutoPostBack="true" OnPreRender="TranslateDrop_PreRender">
                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>   
                            <asp:ListItem Text="YES" Value="1"></asp:ListItem>                               
                        </asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label" runat="server" Id="Amount">Amount</label>
                    <asp:TextBox ID="txtAmount" runat="server" decimal="decimal"></asp:TextBox>
                </div>
            </div>
            <!--grupos-->

            <div class="grupos radios_list margin_t_10">
                <div style="width: auto">
                    <label class="label" runat="server" id="HaveDesignatedPensioner">Have Designated Pensioner?</label>
                </div>
                <div style="width: auto; float: left">
                     <table class="radio" id="QuestionHaveDesignatedPensioner">
                        <tr>
                            <td>
                                <asp:RadioButton runat="server" ID="si1" GroupName="Question" AutoPostBack="true"/>
                                <label for="<%=si1.ClientID%>">Yes</label>
                            </td>
                            <td>
                                <asp:RadioButton runat="server" ID="no1" GroupName="Question" AutoPostBack="true"/>

                                <label for="<%=no1.ClientID %>">No</label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!--grupos radios_list margin_t_10-->

        </asp:Panel>
        <!--content_fondo_blanco-->
    </div>
    <!--fondo_blanco-->
</div>
<!--col-1-4-c-->
