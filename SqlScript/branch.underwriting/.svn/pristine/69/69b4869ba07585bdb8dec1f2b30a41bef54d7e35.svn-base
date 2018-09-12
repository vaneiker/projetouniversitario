<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWorkFlow.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Workflow.UCWorkFlow" %>
<div class="tbl_wf">
    <table width="100%" border="0">
        <tr>
            <td class=""></td>
            <td rowspan="2" class="">
                <div class=" prl">
                    <div class="flecha_derecha2 mB70"></div>
                    <!--<div class="lineWF_v_T"></div>-->
                </div>

            </td>
            <td class="">
                <asp:Panel ID="pnBackgrounCheck" runat="server">
                    <asp:HyperLink runat="server" ID="lnkBackgroundCheck">
                        <asp:Literal runat="server" ID="ltrBackGroundCheck" />

                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvBackgroundCheck" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>


                            </div>

                        </span>

                        </asp:HyperLink>
                    </asp:Panel>
            </td>
            <td class=""></td>
            <td rowspan="2" class="">
                <div class=" prl">
                    <div class="flecha_abajo2"></div>
                </div>
            </td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class=""></td>
            <td class="">
         <asp:Panel ID="pnNeverIssued" runat="server" CssClass="step_name rds10 rojoGR_in ">
           <asp:HyperLink runat="server" ID="lnkNeverIssued" CssClass="step_in rds10 tooltip3 rojoGR">Never<br />
                        Issued

                         <span class="last">
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvNeverIssued" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>


                            </div>

                        </span>


                    </asp:HyperLink>
                </asp:Panel>
            </td>
        </tr>
        <tr class="hg70">
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>

                <div class="flecha_arriba"></div>

            </td>
        </tr>
        <tr>
            <td>
          <asp:Panel ID="pnReadyForUnderWriting" runat="server">
           <asp:HyperLink runat="server" ID="lnkReadyForUnderWriting">
                        <asp:Literal runat="server" ID="ltrReadyForUnderWriting" />

                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvReadyForUnderWriting" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>



                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
         <asp:Panel ID="pnPaymentReview" runat="server">
           <asp:HyperLink runat="server" ID="lnkPaymentReview">
                        <asp:Literal runat="server" ID="ltrPaymentReview" />

                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvPaymentReview" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>


                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
         <asp:Panel ID="pnWaitingForMedicalInfo" runat="server">
           <asp:HyperLink runat="server" ID="lnkWaitingForMedicalInfo">
                        <asp:Literal runat="server" ID="ltrWaitingForMedicalInfo" />

                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvWaitingForMedicalInfo" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>

                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
         <asp:Panel ID="pnEvaluation" runat="server">
           <asp:HyperLink runat="server" ID="lnkEvaluation">
                        <asp:Literal runat="server" ID="ltrEvaluation" />
                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
 <asp:GridView ID="gvEvaluation" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>

                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
         <asp:Panel ID="pnWaitingForClientInfo" runat="server">
           <asp:HyperLink runat="server" ID="lnkWaitingForClientInfo">
                        <asp:Literal runat="server" ID="ltrWaitingForClientInfo" />
                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                 <asp:GridView ID="gvWaitingForClientInfo" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>

                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
        <asp:Panel ID="pnReinsurance" runat="server">
           <asp:HyperLink runat="server" ID="lnkReinsurance">
                        <asp:Literal runat="server" ID="ltrReinsurance" />

                        <span class="last">
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvReinsurance" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>

                            </div>

                        </span>


                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td>
                <div class=" min-wd14 hg11">
                    <div class="flecha_derecha"></div>
                </div>
            </td>
            <td>
         <asp:Panel ID="pnFinalReview" runat="server">
           <asp:HyperLink runat="server" ID="lnkFinalReview">
                        <asp:Literal runat="server" ID="ltrFinalReview" />

                        <span class="last">
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvFinalReview" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>
                        </span>

                    </asp:HyperLink>
                </asp:Panel>
            </td>

            <td>
                <div class=" prl">
                    <div class="lineWF"></div>
                </div>

            </td>
        </tr>
        <tr class="hg70">
            <td></td>
            <td rowspan="2">
                <div class=" prl">
                    <div class="flecha_derecha2b mT70"></div>
                </div>
            </td>
            <td></td>
            <td></td>
            <td rowspan="2">
                <div class=" prl">
                    <div class="flecha_arriba2 mB110"></div>
                </div>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>

                <div class="flecha_abajo"></div>

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
         <asp:Panel ID="pnConfirmationCall" runat="server">
           <asp:HyperLink runat="server" ID="lnkConfirmationCall">
                        <asp:Literal runat="server" ID="ltrConfirmationCall" />
                        <span>
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                               <asp:GridView ID="gvConfirmationCall" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>
                            </div>

                        </span>

                    </asp:HyperLink>
                </asp:Panel>
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td>
         <asp:Panel ID="pnIssuance" runat="server" CssClass="step_name rds10 rojoGR_in">
           <asp:HyperLink runat="server" ID="lnkIssuance" CssClass="step_in rds10 tooltip3 rojoGR">Issuance
                        
                        <span class="last">
                            <div class="bgGR_acc">Day In This Step</div>

                            <b></b>
                            <div class="tbl-day_step">
                                <asp:GridView ID="gvIssuance" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                    <Columns>

                                        <asp:TemplateField HeaderText="Open Actions" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpenAction" runat="server" Text='<%# Eval("StepDesc") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Opened" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOpened" runat="server" Text='<%# Eval("Opened", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Closed" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClosed" runat="server" Text='<%# Eval("Closed", "{0:d}") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No data to display
                                    </EmptyDataTemplate>
                                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="gradient_azul" />
                                </asp:GridView>

                            </div>

                        </span>                        	
                                                
                   </asp:HyperLink>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
<div class=" tbl-legend">
    <table width="100%" border="0">
        <tr>
            <td class="c1">
                <div class="step_in rds10 verdeGR"></div>
            </td>
            <td class="c2">
                <div class="label">Completed Step</div>
            </td>
        </tr>
        <tr>
            <td class="c1">
                <div class="step_in rds10 naranjaGR"></div>
            </td>
            <td class="c2">
                <div class="label">Current Step</div>
            </td>
        </tr>
        <tr>
            <td class="c1">
                <div class="step_in rds10 cremaGR"></div>
            </td>
            <td class="c2">
                <div class="label">Pending Step</div>
            </td>
        </tr>
        <tr>
            <td class="c1">
                <div class="step_in rds10 rojoGR"></div>
            </td>
            <td class="c2">
                <div class="label">Process Ends</div>
            </td>
        </tr>
        <tr>
            <td class="c1">
                <div class="step_in rds10 violetaGR"></div>
            </td>
            <td class="c2">
                <div class="label">N/A</div>
            </td>
        </tr>
    </table>
</div>

<div class="msj rds10 gradient_AZ_btn">
    For further information: Tooltip available over each section.
</div>
