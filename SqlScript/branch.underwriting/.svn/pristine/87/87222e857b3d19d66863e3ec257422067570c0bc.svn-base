<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/NewBusiness/UserControls/IllustrationsVehicle/UCHsuplementos.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCHsuplementos" %>

  <div id="divSuplementos" class="tbl RiesgoAsegurado data_Gpl mT10">
        <!--[if lte IE 9]>
<div class="old_ie_wrapper">
<!--<![endif]-->
        
      
                <table id="tblSuplementoshealth" class="tblBottom">
                    <thead>
                        <tr class="gradient_azul trHeader">
                            <th align="center" class="c1"><span>Tipo de suplemento</span></th>
                            <th align="center" class="c2"><span>Asegurado</span></th>
                            <th align="center" class="c3"><span>Producto</span></th>
                            <th align="center" class="c4"><span>Cobertura</span></th>
                            <th align="center" class="c5"><span>Prima</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="suplementosrow">
            <ItemTemplate>
                <tr>
                    <td align="center" class="c1"><%#Eval("tiposuplemento") %></td>
                    <td align="center" class="c2"><%#Eval("Asegurado") %></td>
                    <td align="center" class="c3"><%#Eval("Producto") %></td>
                    <td align="center" class="c4"><%#Eval("Cobertura") %></td>
                    <td align="center" class="c5"><%#Eval("Prima") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
       </tbody>
                    <tfoot>
                        <tr  class="label_plus_input"> 
                        <td></td>
                        <td></td>
                         <td></td>
                         <td align="center" ><span style="font-size:medium;">Total</span></td>
                         <td align="center"><asp:Label ID="Total" style="font-size:medium;text-align:center;" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                    </tfoot>
   </table>

        <!--[if lte IE 9]>
</div>
<!--<![endif]-->
    </div>