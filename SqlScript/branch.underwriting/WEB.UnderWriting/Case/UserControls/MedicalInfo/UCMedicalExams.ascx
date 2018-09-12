<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMedicalExams.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.MedicalInfo.UCMedicalExams" %>
<ul class="secundario">
    <li class="med_info">
        <!--// 2da tabla -->
        <label class=" label">
            ALL MEDICAL EXAMS RECEIVED</label>
        <div class="tbl data_G tbl-2 wd100 mB20">

            <asp:GridView ID="gvMedicalExams" DataKeyNames="condition"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:TemplateField HeaderText="Exam Name" HeaderStyle-HorizontalAlign="left" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <i class="bombillo bomb fl"></i>
                            <asp:Label ID="lblExamName" runat="server" Text='<%# Eval("RequirementTypeDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Requested" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                            `
                                    <asp:Label ID="lblDateRequested" runat="server" Text='<%# Eval("DateRequested") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Received" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="lblDateReceived" runat="server" Text='<%# Eval("DateReceived") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Lab / Physician" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="lblLabPhysician" runat="server" Text='<%# Eval("LabDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="PDF's File" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkPdfFile" CssClass="pdf_ico" OnClick="lnkPdfFile_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
            </asp:GridView>




            <div class="pagination">
                <p>
                    Page 1 of 4 (32 items)
                </p>
                <!-- **todas las posibilidades** --
                <a href="#" class="rewd_dis"></a> 
                <a href="#" class="rewd"></a>                                                                 
                <a href="#" class="prev_dis"></a>                                                                
                <a href="#" class="prev"></a>
                <a href="#" class="next"></a>
                <a href="#" class="next_dis"></a>
                <a href="#" class="fwrd"></a> 
                <a href="#" class="fwrd_dis"></a> -->
                <a href="#" class="prev_dis"></a>
                <div class="current">
                    1
                </div>
                <a href="#" class="numbers">2</a> <a href="#" class="numbers">3</a> <a href="#" class="numbers">4</a> <a href="#" class="next"></a>
            </div>
            <!--pagination-->
        </div>
        <!--// 2da tabla -->
        <!-- 3era tabla -->
        <div class="wd100 fl">
            <label class=" label fl">MEDICAL INFORMATION DETAILS</label>

            <asp:DropDownList ID="ddlExamType" runat="server" CssClass="select_esp" DataTextField="Text" DataValueField="Value" AutoPostBack="true" OnSelectedIndexChanged="ddlExamType_SelectedIndexChanged"/>

        </div>
        <div class="tbl data_G tbl-3 wd100 mB20">
          
            <asp:GridView ID="gvMedicalInfoDetail" DataKeyNames="ExmaDate"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" OnDataBound="gvMedicalInfoDetail_DataBound">
                <Columns>

              <asp:BoundField DataField="ExmaDate" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c1"/>
              <asp:BoundField DataField="ExmaTime" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c2"/>
              <asp:BoundField DataField="MedTestDesc" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c3"/>
              <asp:BoundField DataField="SubtestDesc" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c4"/>
              <asp:BoundField DataField="Units" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c5"/>
              <asp:BoundField DataField="Result" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="hide-element" ShowHeader="false" ItemStyle-CssClass="c6"/>



                        <asp:BoundField DataField="LabFromParam" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c7" HeaderText="From" ItemStyle-CssClass="c7" />
                    
                      <asp:BoundField DataField="LabToParam" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c7" HeaderText="To" ItemStyle-CssClass="c7" />

                      <asp:BoundField DataField="ReinsurerFromParam" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c8" HeaderText="From" ItemStyle-CssClass="c8" />
                    
                      <asp:BoundField DataField="ReinsurerToParam" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c8" HeaderText="To" ItemStyle-CssClass="c8" />


                </Columns>
                                                       
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
            </asp:GridView>

            <div class="pagination">
                <p>
                    Page 1 of 4 (32 items)
                </p>
                <!-- **todas las posibilidades** --
                <a href="#" class="rewd_dis"></a> 
                <a href="#" class="rewd"></a>                                                                 
                <a href="#" class="prev_dis"></a>                                                                
                <a href="#" class="prev"></a>
                <a href="#" class="next"></a>
                <a href="#" class="next_dis"></a>
                <a href="#" class="fwrd"></a> 
                <a href="#" class="fwrd_dis"></a> -->
                <a href="#" class="prev_dis"></a>
                <div class="current">
                    1
                </div>
                <a href="#" class="numbers">2</a> <a href="#" class="numbers">3</a> <a href="#" class="numbers">4</a> <a href="#" class="next"></a>
            </div>
            <!--pagination-->
        </div>
        <!--// 3era tabla -->


    </li>
</ul>
