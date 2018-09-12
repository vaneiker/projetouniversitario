<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCExceptions.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Exceptions.UCExceptions" %>
<ul class="secundario">
    <li class="exception">
        <!-- 1era tabla -->

        <div class="tbl tbl-1 wd100 mB20">

            <asp:GridView ID="gvException"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:TemplateField HeaderText="Exception Type" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="lblExceptionType" runat="server" Text='<%# Eval("exceptionType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Exception" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                            <asp:Label ID="lblException" runat="server" Text='<%# Eval("exception") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Requestor" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="lblRequestor" runat="server" Text='<%# Eval("Requestor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Approved" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="lblApproved" runat="server" Text='<%# Eval("Approved") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date Requested" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="lblDateRequested" runat="server" Text='<%# Eval("DateRequested") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date<br>Approved / Declined" HeaderStyle-CssClass="c6" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("DateApproved") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Time Period" HeaderStyle-CssClass="c7" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="lblTimePeriod" runat="server" Text='<%# Eval("TimePeriod") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c8" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Files" HeaderStyle-CssClass="c9" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c9">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkPdf" CssClass="pdf_ico" />
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
                <p>Page 1 of 4 (32 items)</p>
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
                <div class="current">1</div>
                <a href="#" class="numbers">2</a>
                <a href="#" class="numbers">3</a>
                <a href="#" class="numbers">4</a>
                <a href="#" class="next"></a>
            </div>
            <!--pagination-->
        </div>
        <!--// 1era tabla -->
        <div class="wd100 fl">
            <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr">
                <span class="add"></span>
                <input class="boton" type="submit" onclick="" value="New Exceptions">
            </div>
        </div>

    </li>
</ul>
