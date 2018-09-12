<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCheckBoxList.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCCheckBoxList" %>

  
        <asp:CheckBoxList ID="cbCheckBoxItem" runat="server" CssClass="refresh_height" RepeatColumns="2" 
            OnSelectedIndexChanged="cbCheckBoxItem_SelectedIndexChanged" AutoPostBack="false" validateCheckboxList="validateCheckboxList"
            RepeatLayout="Table" TextAlign="Right" OnPreRender="cbCheckBoxItem_PreRender" >
        </asp:CheckBoxList>                                                                                                                                                                
 

