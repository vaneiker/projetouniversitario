<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPaymentCurrentPremium.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Payments.UCPaymentCurrentPremium" %>

<ul class="secundario">
	<li class="finfo">
		<div class="list_addresses">
			<div class="row mB" style="font-size: 1.3em;">
<%--
				<table class="tbl data_G mB">
					<tbody>
						<tr>
							<td style="border: 0"></td>
							<td class="gradient_gris wd12">Medical</td>
							<td class="gradient_gris wd12">Rider</td>
							<td class="gradient_gris wd12">Modification</td>
							<td class="gradient_gris wd12">Adjustments</td>
							<td class="gradient_gris wd12">Premium</td>
							<td class="gradient_gris wd12">Carrier</td>
						</tr>
						<tr>
							<td class="gradient_gris">Principle</td>
							<td>
								<div><%# Eval("PrincipleMedical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("PrincipleRider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("PrincipleModification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("PrincipleAdjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("PrinciplePremium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("PrincipleCarrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris">Spouse</td>
							<td>
								<div><%# Eval("SpouseMedical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("SpouseRider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("SpouseModification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("SpouseAdjustments")%></div>
							</td>
							<td>
								<div><%# Eval("SpousePremium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("SpouseCarrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris">Child 1</td>
							<td>
								<div><%# Eval("Child1Medical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child1Rider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child1Modification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child1Adjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child1Premium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child1Carrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris">Child 2</td>
							<td>
								<div><%# Eval("Child2Medical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child2Rider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child2Modification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child2Adjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child2Premium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child2Carrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris">Child 3</td>
							<td>
								<div><%# Eval("Child3Medical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child3Rider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child3Modification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child3Adjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child3Premium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child3Carrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris">Child 4</td>
							<td>
								<div><%# Eval("Child4Medical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child4Rider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child4Modification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child4Adjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child4Premium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("Child4Carrier", "{0:n2}")%></div>
							</td>
						</tr>
						<tr>
							<td class="gradient_gris wd10">Total Premium</td>
							<td>
								<div><%# Eval("TotalPremiumMedical", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("TotalPremiumRider", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("TotalPremiumModification", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("TotalPremiumAdjustments", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("TotalPremiumPremium", "{0:n2}")%></div>
							</td>
							<td>
								<div><%# Eval("TotalPremiumCarrier", "{0:n2}")%></div>
							</td>
						</tr>
					</tbody>
				</table>
--%>
				<asp:GridView ID="gvCurrentPremium" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" ShowHeaderWhenEmpty="true" DataKeyNames="PaymentsId">
					<Columns>
						<asp:TemplateField HeaderText="CURRENT PAYMENT" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<table class="tbl data_G mB">
									<tbody>
										<tr>
											<td style="border: 0"></td>
											<td class="gradient_gris wd12">Medical</td>
											<td class="gradient_gris wd12">Rider</td>
											<td class="gradient_gris wd12">Modification</td>
											<td class="gradient_gris wd12">Adjustments</td>
											<td class="gradient_gris wd12">Premium</td>
											<td class="gradient_gris wd12">Carrier</td>
										</tr>
										<tr>
											<td class="gradient_gris">Principle</td>
											<td>
												<div><%# Eval("PrincipleMedical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("PrincipleRider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("PrincipleModification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("PrincipleAdjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("PrinciplePremium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("PrincipleCarrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris">Spouse</td>
											<td>
												<div><%# Eval("SpouseMedical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("SpouseRider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("SpouseModification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("SpouseAdjustments")%></div>
											</td>
											<td>
												<div><%# Eval("SpousePremium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("SpouseCarrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris">Child 1</td>
											<td>
												<div><%# Eval("Child1Medical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child1Rider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child1Modification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child1Adjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child1Premium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child1Carrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris">Child 2</td>
											<td>
												<div><%# Eval("Child2Medical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child2Rider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child2Modification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child2Adjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child2Premium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child2Carrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris">Child 3</td>
											<td>
												<div><%# Eval("Child3Medical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child3Rider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child3Modification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child3Adjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child3Premium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child3Carrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris">Child 4</td>
											<td>
												<div><%# Eval("Child4Medical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child4Rider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child4Modification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child4Adjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child4Premium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("Child4Carrier", "{0:n2}")%></div>
											</td>
										</tr>
										<tr>
											<td class="gradient_gris wd10">Total Premium</td>
											<td>
												<div><%# Eval("TotalPremiumMedical", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("TotalPremiumRider", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("TotalPremiumModification", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("TotalPremiumAdjustments", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("TotalPremiumPremium", "{0:n2}")%></div>
											</td>
											<td>
												<div><%# Eval("TotalPremiumCarrier", "{0:n2}")%></div>
											</td>
										</tr>
									</tbody>
								</table>
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
						<div style="border-bottom-width: 0px; color: #F00 !important; text-align: center; font-size: 1.1em; padding-top: 10px;" class="dxgv dxgvEmptyDataRow">
							No data to display
						</div>
					</EmptyDataTemplate>
				</asp:GridView>
				<asp:HiddenField ID="hdfCurrentPremiumRowIndex" runat="server" />
			</div>
		</div>
	</li>
</ul>
