<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCountry.ascx.cs" Inherits="WEB.UnderWriting.Administrator.UserControls.UCCountry" %>




        <div class="tbl data_G mB">
         
               <asp:GridView ID="gvCountry"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvCountry_PageIndexChanging">
                <Columns>

                    <asp:TemplateField HeaderText="Country Name" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="left" ItemStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Country_Desc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                                <asp:Button runat="server" ID="btnEdit" OnClick="btnEdit_Click" /> 
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" OnClick="btnDelete_Click" /> 
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

                <PagerTemplate>

                    <div class="pagination">
                        <p>
                            Page
                            <asp:Literal ID="indexPage" runat="server" />
                            of
                            <asp:Literal ID="totalPage" runat="server" />
                            (<asp:Literal ID="totalItems" runat="server" />
                            items)
                        </p>
                        <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                        <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                        <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                        <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                    </div>

                </PagerTemplate>


                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
            </asp:GridView>

        </div>

 <div class="wd100 fl hg35 mB">

                    <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fl">
                        <span class="add"></span>
                        <input class="boton" type="button" onclick="TogglePanel('#txtCountry', '#pnCountry')" value="Add Country">
                    </div>
                </div>


                <asp:Panel runat="server" ID="pnCountry" Style="display: none;" ClientIDMode="Static" CssClass="row">
                    <div class="wd100 fl hg35 m0">
                      <%--  <li class="mR-2-p">--%>
                         <asp:TextBox ID="txtCountry" ClientIDMode="Static" runat="server" placeholder="Add Country..." CssClass="row mB" />

                        <div class="boton_wrapper gradient_vd2 bdrVd2 fl mR">
                            <span class="save"></span>
                            <asp:Button runat="server" ID="btnSave" CssClass="boton" OnClick="btnSave_Click" Text="Save"/>
                        </div>
<%--</li>--%>
                    </div>

                </asp:Panel>