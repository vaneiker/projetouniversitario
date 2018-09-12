<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPaymentHistory.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Payments.UCPaymentHistory" %>

<ul class="secundario">
	<li class="finfo">
		<div id="dvPersonalInfo" class="row mT20 mB20 ephon">
			<div class="tbl data_G mB mB20">
				<asp:GridView ID="gvPayments" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvPayments_PageIndexChanging" ShowHeaderWhenEmpty="true">
					<Columns>
						<asp:TemplateField HeaderText="Date of Payment" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div><%# Eval("DateOfPayment", "{0:MM/dd/yyyy}") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Payment Amount" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div><%# Eval("PaymentAmount", "{0:n2}") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Method Used" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div><%# Eval("MethodUsed") %></div>
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
						<div style="border-bottom-width: 0px; color: #F00 !important; text-align: center;" class="dxgv dxgvEmptyDataRow">
							No data to display
						</div>
					</EmptyDataTemplate>
				</asp:GridView>
				<asp:HiddenField ID="hdfRowIndex" runat="server" />
			</div>
		</div>
	</li>
</ul>
