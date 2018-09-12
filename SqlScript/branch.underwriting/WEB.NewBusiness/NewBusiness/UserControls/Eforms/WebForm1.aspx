<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Eforms.WebForm1" %>

<!DOCTYPE html>
<html lang="en" class="no-js">
<head>
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Formulario</title>
  <meta name="author" content="w-suero" />
  <link href="css/style.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
	<div class="contenedor_formilario">
    	<div class="pagina_formilario">
        	<div class="header_formilario">
            	<table class="header-01">
                	<tr>
                    	<td rowspan="3"><div class="logo"></div></td>
                        <td class="aling-right valing"><h2>Bank Check Request</h2></td>
                    </tr>
                </table>
            </div><!--header_formilario-->
            
            <div class="break_line"></div>
            
            <div class="content_formulario">
            	
                <div class="col-1-1">
                  <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	To:
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Date( MM/DD/YY):
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	From:
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Customer Number:
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Ref:
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                  </table>
              </div><!--col-1-1-->
              
              <div class="col-1-1">
                  <div class="titulos"><strong>Beneficiary Information</strong> (Información del Beneficiario):</div>
                  <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Check Amount
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Check Currency
                                    </td>
                                    <td>
                                    	<table class="sin-border">
                                            <tr>
                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <input type="checkbox" value="None" id="check_01_13" name="check_01_13" class="check_03"/>
                                                        <label for="check_01_13"></label>
                                                    </div>
                                                </td>
                                                <td class="aling-left">US Dollar</td>
                                                
                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <input type="checkbox" value="None" id="check_01_14" name="check_01_14" class="check_03"/>
                                                        <label for="check_01_14"></label>
                                                    </div>
                                                </td>
                                                <td class="aling-left">Euro</td>
                                                
                                                <td width="16">
                                                    <div class="squaredFour-pequenos">
                                                        <input type="checkbox" value="None" id="check_01_14" name="check_01_14" class="check_03"/>
                                                        <label for="check_01_14"></label>
                                                    </div>
                                                </td>
                                                <td class="aling-left">Other, Specify:</td>
                                                <td width="74%">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Beneficiary Name
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Beneficiary Address
                                    </td>
                                    <td>
                                    	<textarea class="inputClear"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Reference
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Notes
                                    </td>
                                    <td>
                                    	<textarea class="inputClear"></textarea>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                  </table>
              </div><!--col-1-1-->
              
              <div class="col-1-1">
                  <div class="titulos"><strong>Debit ( - )</strong></div>
                  <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Account Number
                                    </td>
                                    <td class="align_left">
                                    	<table class="sin-border ancho-01 margin_left">
                                            <tr>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                                <td width="">
                                                    <input type="text" class="formulario-01 inputClear"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td class="align_right" width="15%">
                                    	Account Name
                                    </td>
                                    <td>
                                    	<input type="text" class="formulario-01 inputClear"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                  </table>
              </div><!--col-1-1-->
              
              <div class="col-1-1">
                  <div class="titulos"><strong>Authorization</strong></div>
                  <table class="horizontal-border">
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr height="60">
                                    <td class="align_left texto_gris">
                                    	I hereby authorize StateTrust Bank & Trust Ltd. to issue an Official Bank Check on my behalf and to debit my bank account
                                        (plus any transactional fee) accordingly.Account Number
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="texto_rojo valing">
                                    	“A” Type signatures, only one required; “B” Type signatures, two signatures are required.
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td height="80">
                                    	<table class="sin-border">
                                            <tr>
                                                <td>
                                                	<table class="sin-border ancho-02 no_margin_right">
                                                        <tr>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="">
                                                  Customer Signature
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    	<table class="sin-border">
                                            <tr>
                                                <td>
                                                	<table class="sin-border ancho-02 no_margin_right">
                                                        <tr>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="">
                                                  Customer Signature
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <table class="vertical-border">
                                <tr>
                                    <td width="60%">
                                    	<table class="sin-border">
                                            <tr>
                                                <td class="aling-left texto_gris">
                                                  For Bank Use Only
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                	<table class="sin-border margin_left">
                                                        <tr>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td>.</td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td>.</td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td>.</td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td>.</td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                            <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td colspan="3" class="texto_gris">Branch</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">dd</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">mm</td>
                                                            <td></td>
                                                            <td colspan="2" class="texto_gris">yy</td>
                                                            <td></td>
                                                            <td colspan="4" class="texto_gris">Reference</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                    	<table class="sin-border">
                                            <tr>
                                                <td class="aling-left" width="20%">
                                                  Input By:
                                                </td>
                                                <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="aling-left" width="">
                                                  Verified By:
                                                </td>
                                                <td width=""><input type="text" class="formulario-01 inputClear"/></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                  </table>
              </div><!--col-1-1-->
              
              
              <div class="break_line"></div>
              
              
            </div><!--content_formulario-->
            
        </div><!--pagina_formilario-->





    	
    </div>	
</body>
</html>