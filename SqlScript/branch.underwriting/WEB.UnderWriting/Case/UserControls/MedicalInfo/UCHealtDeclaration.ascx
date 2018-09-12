<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHealtDeclaration.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.MedicalInfo.UCHealtDeclaration" %>

<ul class="secundario">
	<li class="med_info">
		<div class="row">
			<div class="wd49 fl mR-2-p">
				<label class="label label-1 wd100 hg11">
				</label>
				<div class="wd49 mR-2-p fl">
					<label class="label label-1">
						SELECT INSURED:</label>
					<asp:DropDownList ID="ddlInsuredType" runat="server" CssClass="mB" DataTextField="Text" DataValueField="Value" OnSelectedIndexChanged="ddlInsuredType_SelectedIndexChanged" AutoPostBack="true" />

					<label class="label-age label label-1 wd30-7 mB0">
						Age:
                        <asp:TextBox ID="txtAge" runat="server" />
					</label>
					<label class="label-age label label-1 wd30-7 mB0">
						Gender:
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="mB" />
					</label>
					<label class="label-age label label-1 wd30-7 mB0">
						Smoker:
                        <asp:DropDownList ID="ddlSmoker" runat="server" CssClass="mB" />
					</label>
				</div>
				<div class="wd49 fl">
					<label class="label label-1">Main Insured:</label>
					<asp:TextBox ID="txtMainInsured" runat="server" ReadOnly="true" />

					<label class="label label-1 mR-2-p fl wd100 mT10">
						EXERCISE:
                        <select class="">
                            <option></option>
                            <option></option>
                        </select>
                    </label>
                </div>

            </div>

            <!-- BLOQUE 2 -->
            <div class="wd49 fl">
                <label class="label wd100 label-1 txtBold">MEASUREMENTS:</label>
                <div class="wd49 mR-2-p fl mB">
                    <label class="label label-1">
                        WEIGHT:</label>
                    <asp:TextBox ID="txtHealthWeight" runat="server" onblur="CalcularBMI()" Style="text-align: right;" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdHealthWeightType" runat="server" />
                    <label class="label label-1 row mT15">USE OF DRUGS OR ALCHOOL:</label>
                    <select class="">
                        <option></option>
                        <option></option>
                    </select>
                </div>
                <div class="wd49 fl">
                    <div class="wd49 mR-2-p fl mB">
                        <label class="label label-1">
                            HEIGHT:</label>
                        <asp:TextBox ID="txtHealthHeight" runat="server" onblur="CalcularBMI()" Style="text-align: right;" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdHealthHeightType" runat="server" />
                    </div>
                    <div class="wd49 fl">
                        <label class="label label-1">BMI:</label>
                        <asp:TextBox ID="txtHealthBMI" runat="server" ReadOnly="true" Style="text-align: right;" ClientIDMode="Static" />
                    </div>

                    <div class="fl" id="divBP" runat="server">
                        <label class="label label-1 wd49 fl mR-2-p">BP Systolic:</label>
                        <label class="label label-1 wd49 fl">BP Diastolic:</label>
                        <asp:TextBox ID="txtSystolic" runat="server" CssClass="wd49 mR-2-p fl mT0" />
                        <asp:TextBox ID="txtDiastolic" runat="server" CssClass="wd49 fl mT0" />
                    </div>

                </div>
            </div>

            <%--2016-01-28 | Marcos J. Perez--%>
            <script type="text/javascript">
                function CalcularBMI() {			        
                    var height = $('#<%= txtHealthHeight.ClientID %>').val(),
						weight = $('#<%= txtHealthWeight.ClientID %>').val();                        

                    var HealthWeigthTypeId =$('#<%= hdHealthWeightType.ClientID %>').val();
                    var HealthHeightTypeId = $('#<%= hdHealthHeightType.ClientID %>').val();
			        //2 es peso en libras hay que convertirlo a metros para la formula del bmi
                    if (HealthWeigthTypeId == 2) {
                        if (weight != null || weight != "") {
                            var weighttoperation = parseFloat(weight);
                            var result = weighttoperation / 2.2046;                            
                            weight = String(result);
                            
                        }                        
			        }
			        // 4 es altura en pies hay que convertirlo a metros para la formula del bmi
                    if (HealthHeightTypeId == 4) {
                        if (height != null || height != "") {
                            var heighttoperation = parseFloat(height);
                            var result = heighttoperation / 3.2808;
                            height = String(result);
                        }			        
			        }
			        bmi = BMI(height, weight, true);
			        $('#<%= txtHealthBMI.ClientID %>').val(bmi);
                }
			</script>
		</div>

		<!-- BLOQUE 3 -->
		<div class="row mB20">
			<div class="wd23-5 mR-1-p fl">
				<label class="label label-1">
					LAST MEDICAL VISIT:</label>
				<asp:TextBox ID="txtLastVisit" runat="server" CssClass="datepicker mB" />

				<label class="label label-1">
					DR. NAME:</label>
				<asp:TextBox ID="txtDrName" runat="server" />
			</div>
			<div class="wd50-6 mR-1-p fl">
				<label class="label label-1">
					REASON:</label>
				<asp:TextBox ID="txtReason" runat="server" CssClass="mB" />
				<label class="label label-1">
					ADDRESSES:</label>
				<asp:TextBox ID="txtAddresses" runat="server" />
			</div>
			<div class="wd23-5 fl">
				<label class="label label-1">
					RESULT:</label>
				<asp:TextBox ID="txtResult" runat="server" />

				<div class="fl mT10">

					<label class="label label-1 wd100">
						PHONE NUMBER:</label>
					<%--<asp:TextBox ID="txtPhoneNumber1" runat="server" CssClass="wd23-5 mR-2-p fl mT0" />
					<asp:TextBox ID="txtPhoneNumber2" runat="server" CssClass="wd23-5 mR-2-p fl mT0" />--%>
					<asp:TextBox ID="txtPhoneNumber3" runat="server" phone="phone"  />
				</div>
			</div>
			<div class="wd49 mR-2-p fl mT10">
				<div class="tbl tbl-1 data_G wd100 mB20">
					<asp:GridView ID="gvMedicalCondition" DataKeyNames="MedConditionId"
						runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
						<Columns>
							<asp:TemplateField HeaderText="Medical Condition" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c1">
								<ItemTemplate>
									<asp:Label ID="lblCondition" runat="server" Text='<%# Eval("MedConditionDesc") %>'></asp:Label>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
						<EmptyDataTemplate>
							No data to display
						</EmptyDataTemplate>
						<EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
						<HeaderStyle CssClass="gradient_azul" />
					</asp:GridView>
					<!--pagination-->
				</div>
			</div>
			<div class="wd49 fl mT10">
				<label class="label label-1 wd100">Medications:</label>
				<asp:TextBox runat="server" ID="txtMedications" placeholder="Add Medications..." TextMode="MultiLine" CssClass="hg190" />
			</div>

			<!--// 1era tabla -->
			<label class=" label">FAMILY MEDICAL HISTORY</label>
			<div class="tbl tbl-1  data_G wd100 mB20">

				<asp:GridView ID="gvFamilyMedicalHistory"
					runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
					<Columns>

						<asp:TemplateField HeaderText="Relationship" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:Label ID="lblRelationship" runat="server" Text='<%# Eval("RelationshipDesc") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="Illness / Cause Of Death" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c2">
							<ItemTemplate>
								<asp:Label ID="lblCauseOfDeath" runat="server" Text='<%# Eval("CauseOfDeath") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="Current Age" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:Label ID="lblCurrentAge" runat="server" Text='<%# Eval("CurrentAge") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>

						<asp:TemplateField HeaderText="Age At Death" HeaderStyle-HorizontalAlign="center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:Label ID="lblAgeAtDeath" runat="server" Text='<%# Eval("AgeDeath") %>'></asp:Label>
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
					<a href="#" class="prev_dis"></a>
					<div class="current">
						1
					</div>
					<a href="#" class="numbers">2</a> <a href="#" class="numbers">3</a> <a href="#" class="numbers">4</a> <a href="#" class="next"></a>
				</div>
				<!--pagination-->

			</div>
			<!--// Fin de las tablas \\-->
		</div>
	</li>
</ul>
