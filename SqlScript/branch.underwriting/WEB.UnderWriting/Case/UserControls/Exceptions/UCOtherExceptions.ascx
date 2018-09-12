<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOtherExceptions.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Exceptions.UCOtherExceptions" %>
<ul class="secundario">
    <li class="exception">
        <!-- 1era tabla -->
        <div class="tbl tbl-2 wd100 mB20">

            <asp:GridView ID="gvOtherException"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                <Columns>

                    <asp:TemplateField HeaderText="Policy #" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="lblPolicy" runat="server" Text='<%# Eval("policy") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("role") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Exception Type" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="lblExceptionType" runat="server" Text='<%# Eval("exceptionType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Exception" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="lblException" runat="server" Text='<%# Eval("exception") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Date<br>Approved / Declined" HeaderStyle-CssClass="c6" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Time Period" HeaderStyle-CssClass="c7" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="lblTimePeriod" runat="server" Text='<%# Eval("time") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c8" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
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


            <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="gradient_azul">
                    <th class="c1">
                        <div>Policy #</div>
                    </th>
                    <th class="c2">
                        <div>Name</div>
                    </th>
                    <th class="c3">
                        <div>Role</div>
                    </th>
                    <th class="c4">
                        <div>Exception Type</div>
                    </th>
                    <th class="c5">
                        <div>Exception</div>
                    </th>
                    <th class="c6">
                        <div>
                            Date<br>
                            Approved / Declined
                        </div>
                    </th>
                    <th class="c7">
                        <div>Time Period</div>
                    </th>
                    <th class="c8">
                        <div>Status</div>
                    </th>
                    <th class="c9">
                        <div>Files</div>
                    </th>

                </tr>

                <tr>
                    <td align="left" class="c1">
                        <div>S451245</div>
                    </td>
                    <td align="left" class="c2">
                        <div>Maria T Perez</div>
                    </td>
                    <td align="center" class="c3">
                        <div>Owner/Additional Insured</div>
                    </td>
                    <td align="center" class="c4">
                        <div>Spouse / Other Insured Rider: Owner/Insured Relationship</div>
                    </td>
                    <td align="center" class="c5">
                        <div>Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment</div>
                    </td>
                    <td align="center" class="c6">
                        <div>06/20/2012</div>
                    </td>
                    <td align="center" class="c7">
                        <div>1</div>
                    </td>
                    <td align="center" class="c8">
                        <div>Pending</div>
                    </td>
                    <td align="center" class="c9">
                        <div><a href="#" class="pdf_ico"></a></div>
                    </td>

                </tr>

                <tr>
                    <td align="left" class="c1">
                        <div>S451245</div>
                    </td>
                    <td align="left" class="c2">
                        <div>Maria T Perez</div>
                    </td>
                    <td align="center" class="c3">
                        <div>Owner/Additional Insured</div>
                    </td>
                    <td align="center" class="c4">
                        <div>Spouse / Other Insured Rider: Owner/Insured Relationship</div>
                    </td>
                    <td align="center" class="c5">
                        <div>Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment</div>
                    </td>
                    <td align="center" class="c6">
                        <div>06/20/2012</div>
                    </td>
                    <td align="center" class="c7">
                        <div>1</div>
                    </td>
                    <td align="center" class="c8">
                        <div>Pending</div>
                    </td>
                    <td align="center" class="c9">
                        <div><a href="#" class="pdf_ico"></a></div>
                    </td>

                </tr>

                <tr>
                    <td align="left" class="c1">
                        <div>S451245</div>
                    </td>
                    <td align="left" class="c2">
                        <div>Maria T Perez</div>
                    </td>
                    <td align="center" class="c3">
                        <div>Owner/Additional Insured</div>
                    </td>
                    <td align="center" class="c4">
                        <div>Spouse / Other Insured Rider: Owner/Insured Relationship</div>
                    </td>
                    <td align="center" class="c5">
                        <div>Agent 1 year / Owner-Insured:Family Member / Non-Annual Payment</div>
                    </td>
                    <td align="center" class="c6">
                        <div>06/20/2012</div>
                    </td>
                    <td align="center" class="c7">
                        <div>1</div>
                    </td>
                    <td align="center" class="c8">
                        <div>Pending</div>
                    </td>
                    <td align="center" class="c9">
                        <div><a href="#" class="pdf_ico"></a></div>
                    </td>

                </tr>
            </table>--%>
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

    </li>
</ul>
