<%@ Page Language="C#"  AutoEventWireup="true" MasterPageFile="~/Administrator/AdministratorMaster.Master" CodeBehind="Geographic.aspx.cs" Inherits="WEB.UnderWriting.Administrator.Pages.Geographic" %>

<%@ Register Src="~/Administrator/UserControls/UCContinent.ascx" TagPrefix="uc1" TagName="UCContinent" %>
<%@ Register Src="~/Administrator/UserControls/UCCountry.ascx" TagPrefix="uc1" TagName="UCCountry" %>
<%@ Register Src="~/Administrator/UserControls/UCCity.ascx" TagPrefix="uc1" TagName="UCCity" %>
<%@ Register Src="~/Administrator/UserControls/UCRegion.ascx" TagPrefix="uc1" TagName="UCRegion" %>
<%@ Register Src="~/Administrator/UserControls/UCRegionCountry.ascx" TagPrefix="uc1" TagName="UCRegionCountry" %>
<%@ Register Src="~/Administrator/UserControls/UCState.ascx" TagPrefix="uc1" TagName="UCState" %>
<%@ Register Src="~/Administrator/UserControls/UCOffice.ascx" TagPrefix="uc1" TagName="UCOffice" %>
<%@ Register Src="~/Administrator/UserControls/UCAgent.ascx" TagPrefix="uc1" TagName="UCAgent" %>








<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPage">
       <table style="width: 100%; margin: 10px;">
        <thead>
            <tr>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>CONTINENT</strong>
                    </div>
                </th>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>REGION</strong>
                    </div>
                </th>

            </tr>
        </thead>
        <tr>

            <td style="width: 50%">
                <uc1:UCContinent runat="server" ID="UCContinent" />

            </td>
            <td style="width: 50%; vertical-align: top; padding-top: 10px">
                <uc1:UCRegion runat="server" id="UCRegion" />    
               
            </td>

        </tr>
    </table>


          <table style="width: 100%; margin: 10px;">
        <thead>
            <tr>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>COUNTRY</strong>
                    </div>
                </th>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>REGION COUNTRY</strong>
                    </div>
                </th>

            </tr>
        </thead>
        <tr>

            <td style="width: 50%">
                <uc1:UCCountry runat="server" ID="UCCountry" />

            </td>
            <td style="width: 50%; vertical-align: top; padding-top: 10px">
                         
                <uc1:UCRegionCountry runat="server" id="UCRegionCountry" />
            </td>

        </tr>
    </table>



              <table style="width: 100%; margin: 10px;">
        <thead>
            <tr>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>STATE</strong>
                    </div>
                </th>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>CITY</strong>
                    </div>
                </th>

            </tr>
        </thead>
        <tr>

            <td style="width: 50%">
                <uc1:UCState runat="server" id="UCState" />

            </td>
            <td style="width: 50%; vertical-align: top; padding-top: 10px">
               
                 <uc1:UCCity runat="server" ID="UCCity" />
                
            </td>

        </tr>
    </table>


    
              <table style="width: 100%; margin: 10px;">
        <thead>
            <tr>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>OFFICE</strong>
                    </div>
                </th>
                <th style="width: 50%">
                    <div class="titulos_azules">
                        <strong>AGENT</strong>
                    </div>
                </th>

            </tr>
        </thead>
        <tr>

            <td style="width: 50%">

                <uc1:UCOffice runat="server" id="UCOffice" />

            </td>
            <td style="width: 50%; vertical-align: top; padding-top: 10px">
               
                <uc1:UCAgent runat="server" id="UCAgent" />
                
            </td>

        </tr>
    </table>

</asp:Content>

