<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCInsuredPersonalIinformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation.WUCInsuredPersonalIinformation" %>
<div class="titulos_azules"><span class="insured"></span><strong runat="server" id="ContactPersonalInformation">CONTACT PERSONAL INFORMATION</strong></div>
<div class="content_fondo_blanco" id="frmPersonalInformation">
    <div class="grupos de_2">
        <div>
            <label class="label red" runat="server" id="FirstName">First Name</label>
            <asp:TextBox runat="server" ID="txtFirtName" validation="Required" alphabetical='alphabetical'></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="MiddleName">Middle Name</label>
            <asp:TextBox runat="server" ID="txtMidleName" alphabetical='alphabetical'></asp:TextBox>
        </div>
        <div>
            <label class="label red" runat="server" id="LastName">Last Name</label>
            <asp:TextBox runat="server" ID="txtLastName" validation="Required" alphabetical='alphabetical'></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="SecondLastName">2nd Last Name</label>
            <asp:TextBox runat="server" ID="txt2ndLastName" alphabetical='alphabetical'></asp:TextBox>
        </div>
    </div>
    <!--grupos-->

    <div class="grupos de_4">
        <div>
            <label class="label red" runat="server" id="Gender"></label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlGender" validation="Required">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="Smoker">Smoker</label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlSmoker" validation="Required">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="MaritalStatus">Marital Status</label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlMaritalStatus" validation="Required">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="CountryofResidence">Country of Residence</label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlCountryOfResidence" validation="Required">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
    </div>
    <!--grupos-->

    <div class="grupos de_4">
        <div>
            <label class="label" runat="server" id="CountryofCitizenship">Country of Citizenship</label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlCountryOfCitizenship">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label" runat="server" id="CountryofBirth">Country of Birth</label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlCountryOfBirth">
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="DateofBirth">Date of Birth</label>
            <asp:TextBox runat="server" ID="txtDateOfBirth" class="datepicker_03" validation="Required" ClientIDMode="Static" />
        </div>
        <div>
            <label class="label red" runat="server" id="Age">Age</label>
            <asp:TextBox runat="server" ID="txtAge" ClientIDMode="Static" validation="Required" numberWithoutValidation = 'numberWithoutValidation'/>
        </div>
    </div>
    <!--grupos-->
</div>
<asp:HiddenField runat="server" ClientIDMode="Static" Value="0" ID="hdnAge"/>

<!--content_fondo_blanco-->
