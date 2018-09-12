<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHdependientes.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCHdependientes" %>

  <div id="divDependientes" class="tbl RiesgoAsegurado data_Gpl mT10">
        <!--[if lte IE 9]>
<div class="old_ie_wrapper">
<!--<![endif]-->
        
      
                <table id="tblDependienteshealth" class="tblBottom">
                    <thead>
                        <tr class="gradient_azul trHeader">
                            <th align="center" class="c1"><span>Nombre</span></th>
                            <th align="center" class="c2"><span>Apellido</span></th>
                            <th align="center" class="c3"><span>Identificacion</span></th>
                            <th align="center" class="c4"><span>Fecha Nacimiento</span></th>
                            <th align="center" class="c5"><span>Relacion con asegurado principal</span></th>
                            <th align="center" class="c6"><span>Estudiante tiempo completo</span></th>
                            <th align="center" class="c7"><span>Plan Seleccionado</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="dependientesrow">
            <ItemTemplate>
                <tr>
                    <td align="center" class="c1"><%#Eval("Nombre") %></td>
                    <td align="center" class="c2"><%#Eval("Apellido") %></td>
                    <td align="center" class="c3"><%#Eval("Id") %></td>
                    <td align="center" class="c4"><%#Eval("Dob") %></td>
                    <td align="center" class="c5"><%#Eval("RelationshipDesc") %></td>
                    <td align="center" class="c6"><%#Eval("FullTimeStudent") %></td>
                    <td align="center" class="c7"><%#Eval("BenefitPlanDesc") %></td>
                  
                </tr>
            </ItemTemplate>
        </asp:Repeater>
       </tbody>
   </table>

        <!--[if lte IE 9]>
</div>
<!--<![endif]-->
    </div>