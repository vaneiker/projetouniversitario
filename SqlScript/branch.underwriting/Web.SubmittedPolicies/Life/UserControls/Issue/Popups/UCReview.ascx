<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCReview.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Popups.UCReview" %>
  <div class="revisar_pp modal pop1">
          <header>
            <h1>REVISAR</h1>
            <a data-modal-close="true" href="#">&times;</a>
          </header>
           <!--CAMPOS EDITABLES-->
            <div class="row">
                <!--COL-1-->
                <div class=" col-6">
                
                <div class="col-6 fl">
                    <div class="row_A">
                        <div class="label_plus_input mT10"> <span>Propietario</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input"> <span>Tipo de Plan</span>
                            <input type="text" value="-">
                        </div>
                        
                        <div class="label_plus_input mT10"> <span>Asegurado</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input mT10"> <span>Edad Asegurado</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input"> <span>Sexo</span>
                            <input type="text" value="-">
                        </div>
                        
                        <div class="label_plus_input mT10"> <span>Fumador</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                    
                    <div class="row_A mT10">
                        <div class="label_plus_input mT10"> <span>Prima Inicial</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input"> <span>Prima Peri&oacute;dica</span>
                            <input type="text" value="-">
                        </div>
                        
                        <div class="label_plus_input mT10"> <span>Prima Min. Anual</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input mT10"> <span>Prima Min. Mensual</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                </div>
                
                <div class="col-6 fl">
                  <div class="row_A mT10">
                        <div class="label_plus_input mT10"> <span>Suma Asegurada</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input"> <span>Perfil de Inversi&oacute;n</span>
                            <input type="text" value="-">
                        </div>
                        
                        <div class="label_plus_input mT10"> <span>Valor de Rescate</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                    
                    <div class="row_A mT10">
                        <div class="label_plus_input mT10"> <span># de P&oacute;liza</span>
                            <input type="text" value="-">
                        </div>
                        <div class="label_plus_input"> <span>Plan</span>
                            <input type="text" value="-">
                        </div>
                        
                        <div class="label_plus_input mT10"> <span>Fecha Efectiva</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                    
                    <div class="row_A mT10">
                        <div class="label_plus_input mT10 mt"> <span>Frecuencia</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                    
                    <div class="row_A mT10">
                        <div class="label_plus_input mT10 mt"> <span>Años de Contribuci&oacute;n</span>
                            <input type="text" value="-">
                        </div>
                    </div>
                    
                </div>
                
                </div>
                
                
                <!--COL-2-->
                <div class=" col-6 fl">
                     <!--PDF-->
                     <div class=" row_box hei550"> <iframe src="images/Overlay_Forms.pdf"></iframe></div>
                     <!--PDF /> -->
                </div>
                <!--COL-2 /> -->
            </div>
            <!--CAMPOS EDITABLES /> -->
       <div class="col-12 fl"><a href="#" class="btn1 btn bgreen fr">Cerrar</a></div>
     </div>