<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWork.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PersonalData.UCWork" %>
<ul class="secundario" style="display: none;">
    <li class="pd10 wdata">
        <asp:UpdatePanel ID="upWork" runat="server">
            <ContentTemplate>
                <ul class="list_campos grupo_de_cuatro">
                    <li class="wd100">
                        <label>Company Name:</label>
                        <asp:TextBox ID="CompanyNameTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </li>

                    <li class="mR-2-p">
                        <label>Occupation Type:</label>
                        <asp:DropDownList ID="OcupationTypeDDL" runat="server" ClientIDMode="Static" OnSelectedIndexChanged="OcupationTypeDDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </li>
                    <li class="">
                        <label class="ReqField">
                            Occupation:</label>
                        <asp:DropDownList ID="OccupationDLL" runat="server" ClientIDMode="Static" CssClass="validationElement"></asp:DropDownList>
                    </li>

       <%--             <li class="mR-2-p">
                        <label class="">SIC Code:</label>
                        <asp:TextBox ID="txtSicCode" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </li>
                    <li class="">
                        <label>SIC Factors:</label>
                        <asp:TextBox ID="txtSicFactor" runat="server"></asp:TextBox>
                    </li>--%>

                    <li class="mR-2-p">
                        <label class="">Line Of Business 1:</label>
                        <asp:TextBox ID="LineOfBussinessTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </li>
                    <li class="">
                        <label>Line Of Business 2:</label>
                        <asp:TextBox ID="LineOfBussiness2Txt" runat="server"></asp:TextBox>
                    </li>
                    <li class="mR-2-p">
                        <label>Tasks Performed:</label>
                        <asp:TextBox ID="TaskPerformedTxt" runat="server"></asp:TextBox>
                    </li>

                    <li class="">
                        <label class="txtBold fl wd25 pdR-5 alignL mT25">Length at Work:</label>
                        <div class=" wd37 mR-2-p fl">
                            <label>
                                Year:</label>
                            <asp:TextBox ID="LengthAtWorkYearTxt" runat="server" ClientIDMode="Static" CssClass="NFormat"></asp:TextBox>
                        </div>
                        <div class="wd36 fl">
                            <label>
                                Months:</label>
                            <asp:TextBox ID="LengthAtWorkMonthTxt" runat="server" ClientIDMode="Static" CssClass="NFormat"></asp:TextBox>
                        </div>
                    </li>

                    <!--// Tabla2 -->
                    <div class="wd49 fl mR-2-p">
                        <li class="wd100">
                            <label class="txtBold em1-1">Yearly Income</label>
                        </li>
                        <li class="mR-2-p">
                            <label>
                                Personal Income:</label>
                            <asp:TextBox ID="PersonalIncomeTxt" runat="server" ClientIDMode="Static" CssClass="DFormat" onChange="CalculateMonthly(this,'#txtMonthlyPIncome');"></asp:TextBox>
                        </li>
                        <li class="">
                            <label>
                                Family Income:</label>
                            <asp:TextBox ID="YearFamilyIncomeTxt" runat="server" ClientIDMode="Static" CssClass="DFormat" onChange="CalculateMonthly(this,'#txtMonthlyFIncome');"></asp:TextBox>
                        </li>
                    </div>
                    <!--// Tabla3 -->
                    <div class="wd49 fl">
                        <li class="wd100">
                            <label class="txtBold em1-1">Monthly Income</label>
                        </li>
                        <li class="mR-2-p">
                            <label>
                                Personal Income:</label>
                            <asp:TextBox ID="txtMonthlyPIncome" runat="server" ClientIDMode="Static" CssClass="DFormat" ReadOnly="True"> </asp:TextBox>
                        </li>
                        <li class="">
                            <label>
                                Family Income:</label>
                            <asp:TextBox ID="txtMonthlyFIncome" runat="server" ClientIDMode="Static" CssClass="DFormat" ReadOnly="True"></asp:TextBox>
                        </li>

                    </div>
                  
                </ul>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="OcupationTypeDDL" />
            </Triggers>
        </asp:UpdatePanel>
    </li>
</ul>
