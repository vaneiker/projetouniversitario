<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopTeamCommunication.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.UCPopTeamCommunication" %>

<asp:UpdatePanel ID="upPopTeamCommunication" runat="server">
    <ContentTemplate>
        <div class="tcommunication ">
            <div class="cont wd100">
                <div class="wd100 fl">
                    <div id="TabbedPanels3" class="TabbedPanels">
                        <ul class="TabbedPanelsTabGroup bdr0 ">
                            <li id="liMessageTab" class="TabbedPanelsTab bdr0 tabNull last-child mR-8 rdsT4 TabbedPanelsTabSelected" tabindex="0">Message</li>
                            <li id="liNewMessageTab" class="TabbedPanelsTab bdr0 last-child rdsT4 tabNull" tabindex="1">New Message</li>
                        </ul>
                        <div class="TabbedPanelsContentGroup">
                            <div class="TabbedPanelsContent mT0 TabbedPanelsContentVisible" id="divMessageCommunicationTeamTab" style="display: block;">
                                <div class="tbl">

                                    <asp:GridView ID="gvTeamComunication" CssClass="gvTeamComunication" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="NoteId"
                                        OnPageIndexChanging="gvTeamComunication_PageIndexChanging" AllowPaging="true" PageSize="6" OnRowDataBound="gvTeamComunication_RowDataBound">


                                        <Columns>
                                            <asp:TemplateField HeaderText="Confidential" HeaderStyle-CssClass="c1" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div>
                                                        <%# bool.Parse(Eval("Confidential").ToString()) ? "<img src=\"../../../images/icon_primary.png\" class=\"icon_communication\" >" : "" %>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkNoteNameTeamCommunication" Text='<%# Eval("NoteName") %>' runat="server" ClientIDMode="Static" OnClick="lnkNoteNameTeamCommunication_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Date started" HeaderStyle-CssClass="c3" ItemStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>

                                                    <asp:Label runat="server" Text='<%# Eval("DateAdded") %>' ID="lblDateAdded" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Date Last Reply" HeaderStyle-CssClass="c4" ItemStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label runat="server" Text='<%# Eval("DateModified") %>' ID="lblDateModified" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-CssClass="c9Remove">
                                                <ItemTemplate>
                                                    <div class="cont_message">
                                                        <div id="dvMessageCommunication" style="display: none;">
                                                            <asp:Literal ID="lblMessageThread" runat="server" />
                                                            <p>
                                                                <strong>Participants:</strong><br>
                                                                <asp:Literal ID="ltrParticipants" runat="server" />
                                                            </p>
                                                            <div class="row">
                                                                <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mR mB">
                                                                    <span class="add"></span>
                                                                    <input class="boton" onclick="new_comments(<%# Eval("NoteId") %>)" value="New Comments">
                                                                </div>
                                                            </div>
                                                            <div id='<%# Eval("NoteId") %>' style="display: none;">
                                                                <div class="wd48 fl mR-2-p">
                                                                    <label class=" label txtBold row">Participants:</label>
                                                                    <asp:ListBox ID="ddlParticipantComment" runat="server" CssClass="combox_all fl mT0 ddlParticipantComment" DataTextField="Text" DataValueField="Value" SelectionMode="Multiple" />
                                                                </div>

                                                                <div class="wd48 fl">
                                                                    <label class=" label txtBold">Message:</label>
                                                                    <asp:TextBox ID="txtMessageThread" CssClass="txtMessageThread" runat="server" Rows="5" Columns="3" TextMode="MultiLine" />

                                                                    <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mT10">
                                                                        <span class="add"></span>
                                                                        <asp:Button ID="btnAddCommentThread" runat="server" CssClass="boton" Text="Add" OnClick="btnAddCommentThread_Click" OnClientClick=" return validateTeamCommunicationsCommentThread(this);" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
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
                                        <PagerStyle CssClass="RCFooterPad" />
                                        <HeaderStyle CssClass="gradient_gris" />
                                        <EmptyDataTemplate>
                                            No data to display
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                    </asp:GridView>


                                </div>
                                <!--// Botones -->
                            </div>
                            <div class="TabbedPanelsContent" id="divNewMessageCommunicationTeamTab" style="display: none;">
                                <div class=" wd48 fl mR-2-p">
                                    <div class=" wd48 fl mR-2-p">
                                        <label class=" label txtBold row">Subject:</label>
                                        <asp:TextBox ID="txtTMSubject" runat="server" ClientIDMode="Static" />
                                    </div>

                                    <div class="wd49 fl mT30 ">
                                        <label class=" label txtBold mL-12-p">Confidential:</label>

                                        <asp:CheckBox ID="chkConfidential" runat="server" CssClass="centralizado mL-12 mT4 PostionAbsolute" />
                                    </div>
                                    <label class=" label txtBold row">Participants:</label>
                                    <asp:ListBox ID="ddlParticipantAddNew" runat="server" CssClass="combox_all2 fl mT0" ClientIDMode="Static" DataTextField="Text" DataValueField="Value" SelectionMode="Multiple" />
                                </div>

                                <div class="wd49 fl">
                                    <label class=" label txtBold">Message:</label>
                                    <asp:TextBox runat="server" CssClass="mB" ID="txtTMMessage" TextMode="MultiLine" ClientIDMode="Static" Columns="10" Rows="10" />

                                </div>
                                <!-- Botones -->
                                <div class="wd100 fl hg35">

                                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                                        <span class="equis"></span>
                                        <input class="boton" type="submit" value="Cancel" onclick="return CloseTeamCommunicationsPop();">
                                    </div>

                                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                                        <span class="save"></span>
                                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="boton" OnClick="btnSave_Click" OnClientClick=" return changeCommunicationTeamTab();" />
                                    </div>

                                </div>
                                <!--// Botones -->
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <asp:HiddenField ID="hdnIndexGvTeamCommunication" runat="server" ClientIDMode="Static" Value="" />
    </ContentTemplate>

</asp:UpdatePanel>
