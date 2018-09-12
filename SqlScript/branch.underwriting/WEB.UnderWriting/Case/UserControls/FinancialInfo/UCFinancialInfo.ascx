<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFinancialInfo.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.FinancialInfo.UCFinancialInfo" %>

<ul class="secundario">
	<li class="finfo">
		<!-- Columna 100% -->
		<div class="rowB">
			<div class=" boxes mR-2-p">
				<label class="label">Annual Personal Income:</label>
				<asp:TextBox ID="txtFIPersonalIncome" runat="server" ReadOnly="true" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Monthly Personal Income:</label>
				<asp:TextBox ID="txtFIPersonalIncomeM" runat="server" ReadOnly="true" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Occupation:</label>
				<asp:TextBox ID="txtFIOcupation" runat="server" ReadOnly="true"></asp:TextBox>
			</div>
			<div class=" boxes">
				<label class="label">Annual Family Income:</label>
				<asp:TextBox ID="txtFIFamilyIncome" runat="server" ReadOnly="true" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Monthly Family Income:</label>
				<asp:TextBox ID="txtFIFamilyIncomeM" runat="server" ReadOnly="true" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Line Of Business:</label>
				<asp:TextBox ID="txtFILineofBusiness" runat="server" ReadOnly="true"></asp:TextBox>
			</div>

			<label class="label fl">Company:</label>
			<asp:TextBox ID="txtFICompany" runat="server" ReadOnly="true"></asp:TextBox>

			<label class="label">Tasks Performed:</label>
			<asp:TextBox ID="txtFITaskPerformed" runat="server" ReadOnly="true"></asp:TextBox>

			<div class=" boxes mR-2-p">
				<label class="label">SIC Code:</label>
				<asp:TextBox ID="txtSICCode" runat="server" ReadOnly="true"></asp:TextBox>
			</div>
			<div class=" boxes">
				<label class="label">SIC Factor:</label>
				<asp:TextBox ID="txtSICFactor" runat="server" ReadOnly="true"></asp:TextBox>
			</div>
		</div>
		<div id="dvPersonalInfo" class="row mT20 mB20 ephon">
			<span class="label mT0 mB22"><i class="address"></i><strong>Work Addresses:</strong></span>
			<div class="tbl data_G mB mB20">
				<asp:GridView ID="gvAddress" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" OnPageIndexChanging="gvAddress_PageIndexChanging" ShowHeaderWhenEmpty="true">
					<Columns>
						<asp:TemplateField HeaderText="Street Address" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVStreet_Address"><%# Eval("StreetAddress") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Country" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVCountry_Desc"><%# Eval("CountryDesc") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="City" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVCity_Desc"><%# Eval("CityDesc") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="State" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVState_Prov_Desc"><%# Eval("StateProvDesc") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Postal Code" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div class="alignC" runat="server" id="DVZip_Code"><%# Eval("ZipCode") %></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVIs_Primary"><%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>" %></div>
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
			<span class="label mT0 mB22"><i class="email"></i><strong>Work Email Addresses:</strong></span>
			<div class="tbl data_G mB mB20">
				<asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvEmail_PageIndexChanging" ShowHeaderWhenEmpty="true">
					<Columns>
						<asp:TemplateField HeaderText="Email Address" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVAddress"><%# Eval("EmailAdress")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div id="DVEmailPrimary" runat="server">
									<%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>"%>
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
					<EmptyDataTemplate>
						<div style="border-bottom-width: 0px; color: #F00 !important; text-align: center;" class="dxgv dxgvEmptyDataRow">
							No data to display
						</div>
					</EmptyDataTemplate>
				</asp:GridView>
			</div>
			<span class="label mT0 mB22"><i class="phone"></i><strong>Work Phone Numbers:</strong></span>
			<div class="tbl data_G  mB">
				<asp:GridView ID="gvPhone" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvPhone_PageIndexChanging" ShowHeaderWhenEmpty="true">
					<Columns>
						<asp:TemplateField HeaderText="Country Code" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVCountryCode"><%# Eval("CountryCode")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Area Code" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVAreaCode"><%# Eval("AreaCode")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Phone Number" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVPhoneNumber"><%# Eval("PhoneNumber")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Extension" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVPhoneExtension"><%# Eval("PhoneExt")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Contact" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVPhoneContact"><%# Eval("PersonToContact")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Primary" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVPhonePrimary"><%# !(bool)Eval("IsPrimary") ? "" : "<i class='check'></i>"%></div>
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
			</div>
		</div>
		<!-- Columna 1 -->
		<div class=" wd49 fl mR-2-p mB">

			<label class="label wd100 fl txtBold em1-1">Financial Statement</label>
			<div class=" boxes mR-2-p">
				<label class="label">Total Estate Amount:</label>
				<asp:TextBox ID="txtFITotalEstateAmount" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Annual Income Other Jobs:</label>
				<asp:TextBox ID="txtFIAnnualInOtherJobs" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Annual Income Trade:</label>
				<asp:TextBox ID="txtFIAnnualInTrade" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
			<div class=" boxes">
				<label class="label">Annual Revenue Of Main Activity:</label>
				<asp:TextBox ID="txtFIAnnualRevMainAct" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Annual Income From Investment:</label>
				<asp:TextBox ID="txtFIAnnualInInvestment" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
			
			<div class="spH13 fl"></div>

			<label class="label wd100 fl txtBold em1-1">Liabilities</label>
			<div class=" boxes mR-2-p">
				<label class="label">Total Liabilities:</label>
				<asp:TextBox ID="txtFITotalLiabilities" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Note Playable:</label>
				<asp:TextBox ID="txtFINotePlayable" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Personal Debts:</label>
				<asp:TextBox ID="txtFIPersonalDebts" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Outstanding Taxes:</label>
				<asp:TextBox ID="txtFIOutstandingTaxes" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Other Liabilities:</label>
				<asp:TextBox ID="txtFIOtherLiabilities" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
			<div class=" boxes">
				<label class="label">MACHINERY AND EQUIPMENT:</label>
				<asp:TextBox ID="txtFIMachineryEquipLI" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Bank Debts:</label>
				<asp:TextBox ID="txtFIBankDebts" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Mortgage Debts:</label>
				<asp:TextBox ID="txtFIMortageDebts" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Short Term Loans:</label>
				<asp:TextBox ID="txtFIShortTermLoans" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
		</div>
		<!--// Columna 1 -->

		<!-- Columna 2 -->
		<div class=" wd49 fl mB">

			<div class=" boxes mR-2-p mT20">
				<label class="label wd100 fl txtBold em1-1">Home Status:</label>

				<ul class="radio">

					<asp:RadioButtonList runat="server" ID="rbtHomeStatus" CssClass="fl mR" CellPadding="10" CellSpacing="10" DataValueField="Value" DataTextField="Text">
					</asp:RadioButtonList>
				</ul>
			</div>

			<div class=" boxes mT20">
				<label class="label wd100 fl txtBold em1-1">Labor Played:</label>
				<ul class="radio">
					<asp:RadioButtonList runat="server" ID="rbtLaborPlayed" CssClass="fl mR" DataValueField="Value" DataTextField="Text">
					</asp:RadioButtonList>
				</ul>
			</div>

			<div class="spH13 fl"></div>
			<div class="spH13 fl"></div>
			<div class="spH13 fl"></div>

			<label class="label wd100 fl txtBold em1-1">Assets</label>
			<div class=" boxes mR-2-p">
				<label class="label">Total Assets:</label>
				<asp:TextBox ID="txtFITotalAssets" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Personal Effects:</label>
				<asp:TextBox ID="txtFIPersonEffects" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">MACHINERY AND EQUIPMENT:</label>
				<asp:TextBox ID="txtFIMachineryEquip" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Other Assets:</label>
				<asp:TextBox ID="txtFIOtherAssets" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
			<div class=" boxes">
				<label class="label">Real Estate:</label>
				<asp:TextBox ID="txtFIRealEstate" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Vehicle:</label>
				<asp:TextBox ID="txtFIVehicle" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>

				<label class="label">Stock And Bonds</label>
				<asp:TextBox ID="txtFIStockAndBonds" runat="server" ClientIDMode="Static" CssClass="PPDecimalFormat"></asp:TextBox>
			</div>
		</div>
		<!--// Columna 2 -->

	</li>
</ul>
