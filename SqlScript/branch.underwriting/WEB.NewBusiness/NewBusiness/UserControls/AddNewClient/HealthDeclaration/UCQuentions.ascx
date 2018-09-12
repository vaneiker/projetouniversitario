<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCQuentions.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCQuentions" %>

<div class="grupos radios_list">
    <div>
        <table>
            <tr>
                <td style="width: 26px; padding-right: 6px">
                    <input class="desplegar" type="button" />
                </td>
                <td>
                    <label class="label"><span>1-</span>¿Ha usted aumentado o disminuido más de 10 lbs.(5 Kgs.) de peso en el último año?</label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table class="radio">
            <tr>
                <td>
                    <input name="radio_1" type="radio" value="Yes" data-input="1" class="static_class" id="si1" />
                    <label class="label-radio" for="si1">Si</label>
                </td>
                <td>
                    <input name="radio_1" type="radio" value="No" data-input="1" class="static_class" id="no1" />
                    <label class="label-radio" for="no1">No</label>
                </td>
            </tr>
        </table>
    </div>
</div>
