<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCActivities.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.FinancialInfo.UCActivities" %>


<%--
<ul class="secundario">
	<li class="allfinfo">
						<div class=" fl wd13 mR-2-p">
					<label class="label ReqField">Phone Type:</label>
					<asp:DropDownList ID="DropDownList1" runat="server" ClientIDMode="Static"></asp:DropDownList>
				</div>

		<div class="wd100 fl mB lh27">
			<label class=" label mB0">AVOCATIONS</label>
			<div class="boton_wrapper gradient_AM_btn bdrAM fr">
				<span class="add"></span>
				<input class="boton" name="" type="button" value="Add Avocation">
			</div>
		</div>

			<div class="add_line">
				<div class=" fl wd13 mR-2-p">
					<label class="label ReqField">Phone Type:</label>
					<asp:DropDownList ID="DDLPhoneType" runat="server" ClientIDMode="Static"></asp:DropDownList>
				</div>
				<div class=" fl wd13 mR-1-p">
					<label class="label ReqField">
						Country Code:</label>
					<asp:TextBox ID="CountryCodeTxt" runat="server" alt="numberLeft" ClientIDMode="Static"></asp:TextBox>
				</div>
				<div class=" fl wd10 mR-1-p">
					<label class="label ReqField">
						Area Code:</label>
					<asp:TextBox ID="AreaCodeTxt" runat="server" alt="numberLeft" ClientIDMode="Static"></asp:TextBox>
				</div>
				<div class=" fl wd13 mR-1-p">
					<label class="label ReqField">
						Phone Number:</label>
					<asp:TextBox ID="PhoneNumberTxt" alt="PhoneNumber" runat="server" ClientIDMode="Static"></asp:TextBox>
				</div>
				<div class=" fl wd8 mR-1-p">
					<label class="label">
						Extension:</label>
					<asp:TextBox ID="ExtensionTxt" alt="numberLeft" runat="server" ClientIDMode="Static"></asp:TextBox>
				</div>
				<div class=" fl wd13 mR-1-p">
					<label class="label ReqField">
						Contact:</label>
					<asp:TextBox ID="ContactTxt" runat="server" ClientIDMode="Static"></asp:TextBox>
				</div>
				<div class="fl wd9">
					<div class="boton_wrapper gradient_AM_btn bdrAM mT15">
						<span class="add"></span>
						<!--<asp:Button ID="AddPhoneBTN" runat="server" Text="Add" class="boton" OnClick="AddPhoneBTN_Click" OnClientClick="return ValidatePhoneNumber();"/>
							<asp:Button ID="EditPhoneBTN" runat="server" Text="Save" class="boton" Visible="false" OnClick="EditPhoneBTN_Click" OnClientClick="return ValidatePhoneNumber();" />-->

						<asp:Button ID="AddPhoneBTN" runat="server" Text="Add" class="boton" />
						<asp:Button ID="EditPhoneBTN" runat="server" Text="Save" class="boton" Visible="false" />
					</div>
				</div>
			</div>
			<div class=" spH15 mB22">
			</div>
			<div class="tbl-phone">
				<asp:GridView ID="gvAvocations" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="4">
					<Columns>
						<asp:TemplateField HeaderText="Phone Type" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div runat="server" id="DVPhoneType"><%# Eval("DirectoryTypeDesc")%></div>
							</ItemTemplate>
						</asp:TemplateField>
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
						<asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div>
									<!-- <asp:Button ID="btnEditPhone" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="UpdatePhone" /> -->
									<asp:Button ID="btnEditPhone" ClientIDMode="Static" runat="server" CssClass="edit_file" />
								</div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div>
									<!-- <asp:Button ID="btnDeletePhone" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="DeletePhone" OnClientClick="return DlgConfirm(this);" /> -->
									<asp:Button ID="btnDeletePhone" ClientIDMode="Static" runat="server" CssClass="delete_file" />
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
				<asp:HiddenField ID="hfdAvocation" runat="server" />
			</div>


		<div class="tbl data_G mB20">
			<label class=" label mB0">Questionnaires</label>
			<div class="spH13 fl"></div>
			<asp:GridView ID="gvQuestionnaires" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvQuestionnaires_PageIndexChanging"
				ShowHeaderWhenEmpty="true" DataKeyNames="FormId" HeaderStyle-CssClass="gradient_azul">
				<Columns>
					<asp:TemplateField HeaderText="Questionary" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left">
						<ItemTemplate>
							<div><%# Eval("FormDesc")%></div>
						</ItemTemplate>
					</asp:TemplateField>

					<asp:TemplateField HeaderText="Date Received" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Left" ItemStyle-CssClass="c2" ItemStyle-HorizontalAlign="Left">
						<ItemTemplate>
							<div><%# Convert.ToDateTime(Eval("CreateDate").ToString()).ToString("MM/dd/yyyy")%></div>
						</ItemTemplate>
					</asp:TemplateField>

					<asp:TemplateField HeaderText="View PDF" HeaderStyle-CssClass="c3" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center">
						<ItemTemplate>
							<div>
								<asp:LinkButton ID="btnFile" runat="server" CssClass="pdf_ico" OnClick="btnFile_Click"></asp:LinkButton>
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
		<!--// tbl-2 -->
		<!--<div class="wd100 fl hg35">

            <div class="boton_wrapper gradient_RJ bdrRJ fl">
                <span class="pdf"></span>
                <input class="boton" type="submit" value="See Questionnaires">
            </div>

            <div class="wd30 fr">
                <label class="label label2 wd50 mT13 alignR pdR">Date Received:</label>
                <input name="" type="text" class="wd50 fl" value="09/03/2014" readonly="readonly">
            </div>
        </div> -->

	</li>
</ul>
--%>

<ul class="secundario">
	<li>
		<div id="divAvocations" class="row">
			<span class="label" style="font-size: 0.7em; float: left; padding-left: 15px;"><strong>Avocations:</strong></span>
			<div class="list_addresses">
				<div class="row mB">
					<div class="boxes">
						<div class="row mB">
							<label class="label fl wd27">Type of Avocation:</label>
							<asp:DropDownList ID="ddlTypeOfAvocation" runat="server" ClientIDMode="Static"></asp:DropDownList>
						</div>
						<div class="box1 ">
							<label class="label">Detail:</label>
							<asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" class="hg80" ClientIDMode="Static"></asp:TextBox>
						</div>
						<div class="box2 ">
							<label class="label">Years of Experience:</label>
							<asp:TextBox ID="txtYearsOfExperience" runat="server" ClientIDMode="Static"></asp:TextBox>
						</div>
						<div class="box3 ">
							<label class="label wd67">License:</label>
							<asp:TextBox ID="txtLicense" runat="server" ClientIDMode="Static"></asp:TextBox>
							<div class=" fl wd50 mR-2-p">
								<label class="label">Avocation Factor:</label>
								<asp:TextBox ID="txtAvocationFactor" runat="server" ClientIDMode="Static"></asp:TextBox>
							</div>
							<div class="fl wd30 mT10">
								<div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f">
									<span class="add"></span>
									<asp:Button ID="AddAddresBTN" runat="server" Text="Add" class="boton" />
									<asp:Button ID="EditAddressBTN" runat="server" Text="Save" class="boton" Visible="false" />
								</div>
							</div>
						</div>
					</div>
					<!--// .boxes -->
				</div>
			</div>

			<div class="tbl data_G mB" style="padding: 30px 15px;">
				<asp:GridView ID="gvAvocations" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" ShowHeaderWhenEmpty="true" DataKeyNames="TypeOfAvocationId" OnPageIndexChanging="gvAvocations_PageIndexChanging">
					<Columns>
						<asp:TemplateField HeaderText="Type Of Avocation" HeaderStyle-CssClass="gradient_gris wd15">
							<ItemTemplate>
								<div><%# Eval("TypeOfAvocationDesc")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Years Of Experience" HeaderStyle-CssClass="gradient_gris wd10">
							<ItemTemplate>
								<div><%# Eval("YearsOfExperience")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="License" HeaderStyle-CssClass="gradient_gris wd15">
							<ItemTemplate>
								<div><%# Eval("License")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Avocation Factor" HeaderStyle-CssClass="gradient_gris wd15">
							<ItemTemplate>
								<div><%# Eval("AvocationFactor")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Detail" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div><%# Eval("Detail")%></div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="gradient_gris wd7">
							<ItemTemplate>
								<div>
									<asp:Button ID="btnEditAvocation" ClientIDMode="Static" runat="server" CssClass="edit_file" />
								</div>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="gradient_gris wd7">
							<ItemTemplate>
								<div>
									<asp:Button ID="btnDeleteAvocation" ClientIDMode="Static" runat="server" CssClass="delete_file" />
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
				<asp:HiddenField ID="hdfAvocationsRowIndex" runat="server" />
			</div>
		</div>

		<div id="divQuestionnaires" class="row mB20">
			<span class="label" style="font-size: 0.7em; float: left; padding-left: 15px;"><strong>Questionnaires:</strong></span>
			<div class="tbl data_G mB" style="padding: 30px 15px;">
				<asp:GridView ID="gvQuestionnaires" runat="server" AutoGenerateColumns="false" PageSize="5" AllowPaging="true" ShowHeaderWhenEmpty="true" DataKeyNames="FormId" OnPageIndexChanging="gvQuestionnaires_PageIndexChanging">
					<Columns>
						<asp:TemplateField HeaderText="Questionary" HeaderStyle-CssClass="gradient_gris">
							<ItemTemplate>
								<div><%# Eval("FormDesc")%></div>
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="Date Received" HeaderStyle-CssClass="gradient_gris wd15">
							<ItemTemplate>
								<div><%# Convert.ToDateTime(Eval("CreateDate").ToString()).ToString("MM/dd/yyyy")%></div>
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="View PDF" HeaderStyle-CssClass="gradient_gris wd10">
							<ItemTemplate>
								<div>
									<asp:LinkButton ID="btnFile" runat="server" CssClass="pdf_ico" OnClick="btnFile_Click"></asp:LinkButton>
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
				<asp:HiddenField ID="hdfQuestionnairesRowIndex" runat="server" />
			</div>
		</div>
	</li>
</ul>

<!--// allfinfo -->
