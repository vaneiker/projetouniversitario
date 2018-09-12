<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCSurvey.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation.WUCSurvey" %>

<ul>
    <li class="barra1 overflow_hidden">
        <div class="grupos radios_list">
            <div style="width: auto">
                <label class="label">DESEA LLENAR INFORMACION SOBRE OTROS PRODUCTOS</label>
            </div>
            <div style="width: auto; float: left">
                <table class="radio">
                    <tr>
                        <td>
                            <input name="radio_15" type="radio" value="" class="" id="si15" />
                            <label for="si15">Si</label>
                        </td>
                        <td>
                            <input name="radio_15" type="radio" value="" class="" id="no15" />
                            <label for="no15">No</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <!--grupos de_2 radios_list-->
    </li>
    <li class="fondo_gris seis">
        <div class="col-1-3">
            <div class="fondo_blanco min_height fix_height">
                <div class="titulos_azules"><strong>INFORMACION PERSONAL</strong></div>
                <div class="content_fondo_blanco">
                    <div class=" margin_t_20">
                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de hogar?</label>
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
                        <div data-input="1" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de vida?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_2" type="radio" value="Yes" data-input="2" class="static_class refresh_height" id="si2" />
                                            <label class="label-radio" for="si2">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_2" type="radio" value="No" data-input="2" class="static_class" id="no2" />
                                            <label class="label-radio" for="no2">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="2" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de Medico?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_3" type="radio" value="Yes" data-input="3" class="static_class" id="si3" />
                                            <label class="label-radio" for="si3">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_3" type="radio" value="No" data-input="3" class="static_class" id="no3" />
                                            <label class="label-radio" for="no3">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="3" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted hijos?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_4" type="radio" value="Yes" data-input="4" class="static_class" id="si4" />
                                            <label class="label-radio" for="si4">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_4" type="radio" value="No" data-input="4" class="static_class" id="no4" />
                                            <label class="label-radio" for="no4">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="4" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cuantos</label>
                                <div class="wrap_select">
                                    <select>
                                        <option>Option 1</option>
                                        <option>Option 2</option>
                                    </select>
                                </div>
                                <!--wrap_select-->
                            </div>
                        </div>

                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de Educacion?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_5" type="radio" value="Yes" data-input="5" class="static_class" id="si5" />
                                            <label class="label-radio" for="si5">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_5" type="radio" value="No" data-input="5" class="static_class" id="no5" />
                                            <label class="label-radio" for="no5">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="5" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene Familiares en Edad Escolar?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_6" type="radio" value="Yes" data-input="6" class="static_class" id="si6" />
                                            <label class="label-radio" for="si6">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_6" type="radio" value="No" data-input="6" class="static_class" id="no6" />
                                            <label class="label-radio" for="no6">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="6" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cuantos</label>
                                <div class="wrap_select">
                                    <select>
                                        <option>Option 1</option>
                                        <option>Option 2</option>
                                    </select>
                                </div>
                                <!--wrap_select-->
                            </div>
                        </div>
                        <br clear="all" />
                    </div>
                    <!--grupos-->
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><span class="email"></span><strong>E-MAIL ADDRESS</strong></div>
                <div class="content_fondo_blanco">
                    <div class="grupos de_2">
                        <div>
                            <label class="label">E-mail Type</label>
                            <div class="wrap_select">
                                <select>
                                    <option>Option 1</option>
                                    <option>Option 2</option>
                                </select>
                            </div>
                            <!--wrap_select-->
                        </div>
                        <div class="float_right">
                            <div class="boton_wrapper amarillo float_right">
                                <span class="add"></span>
                                <input class="boton" type="submit" value="Add">
                            </div>
                            <!--boton_wrapper-->
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grupos de_1">
                        <div>
                            <table>
                                <tr>
                                    <td>
                                        <label class="label">E-mail Address</label>
                                        <input type="text">
                                    </td>
                                    <td style="text-align: right">
                                        <label class="label" style="margin: 0 auto; text-align: center">Primary</label>
                                        <input name="primary" type="checkbox">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grid_wrap margin_t_10">
                        <table>
                            <thead class="headgrid">
                                <tr>
                                    <td class="c1">
                                        <div>Type</div>
                                    </td>
                                    <td class="c2">
                                        <div>Address</div>
                                    </td>
                                    <td class="c3">
                                        <div>Primary</div>
                                    </td>
                                    <td class="c4">
                                        <div>Edit</div>
                                    </td>
                                    <td class="c5">
                                        <div>Delete</div>
                                    </td>
                                </tr>
                            </thead>
                            <tbody class="datagrid">
                                <tr>
                                    <td class="c1">
                                        <div>Home</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Work</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"><span class="primary_chk"></span></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Other</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Other</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"><span class="primary_chk"></span></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="5">
                                        <div class="pagination">
                                            <p>Page 1 of 2 (4 items)</p>
                                            <!-- **todas las posibilidades** --
                                                                          <a href="#" class="rewd_dis"></a> 
                                                                          <a href="#" class="rewd"></a>                                                                 
                                                                          <a href="#" class="prev_dis"></a>                                                                
                                                                          <a href="#" class="prev"></a>
                                                                          <a href="#" class="next"></a>
                                                                          <a href="#" class="next_dis"></a>
                                                                          <a href="#" class="fwrd"></a> 
                                                                          <a href="#" class="fwrd_dis"></a> -->

                                            <a href="#" class="prev_dis"></a>
                                            <div class="current">1</div>
                                            <a href="#" class="numbers">2</a>
                                            <a href="#" class="next"></a>
                                        </div>
                                        <!--pagination-->
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!--grid_wrap-->
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><strong>VEHICULO</strong></div>
                <div class="content_fondo_blanco">

                    <div class="fondo_gris_claro">
                        <div class="grupos de_2 radios_list">
                            <div style="width: auto">
                                <label class="label">Tiene Usted Vehi­culo?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_13" type="radio" value="" class="" id="si13" />
                                            <label for="si13">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_13" type="radio" value="" class="" id="no13" />
                                            <label for="no13">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!--grupos de_2 radios_list-->
                    </div>
                    <!--fondo_gris_claro-->


                    <div class="grid_wrap">
                        <table>
                            <thead class="headergris">
                                <tr>
                                    <td class="c1">
                                        <div>
                                            <label class="label">Marca</label>
                                            <div class="wrap_select">
                                                <select>
                                                    <option>Option 1</option>
                                                    <option>Option 2</option>
                                                </select>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                    </td>
                                    <td class="c2">
                                        <div>
                                            <label class="label">Modelo</label>
                                            <div class="wrap_select">
                                                <select>
                                                    <option>Option 1</option>
                                                    <option>Option 2</option>
                                                </select>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                    </td>
                                    <td class="c3 padding-right2" style="width: 30%">

                                        <div style="width: ">
                                            <label class="label">Año</label>
                                            <div class="wrap_select">
                                                <select>
                                                    <option>Option 1</option>
                                                    <option>Option 2</option>
                                                </select>
                                            </div>
                                            <!--wrap_select-->
                                        </div>
                                        <input class="add_more" type="image" src="../../Content/images/ICONO-ADD.png" />

                                    </td>
                                </tr>
                            </thead>
                            <tbody class="datagrid">
                                <tr>
                                    <td class="c1">
                                        <div></div>
                                    </td>
                                    <td class="c2">
                                        <div></div>
                                    </td>
                                    <td class="c3">
                                        <div></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div></div>
                                    </td>
                                    <td class="c2">
                                        <div></div>
                                    </td>
                                    <td class="c3">
                                        <div></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div></div>
                                    </td>
                                    <td class="c2">
                                        <div></div>
                                    </td>
                                    <td class="c3">
                                        <div></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div></div>
                                    </td>
                                    <td class="c2">
                                        <div></div>
                                    </td>
                                    <td class="c3">
                                        <div></div>
                                    </td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="3">
                                        <div class="pagination">
                                            <p>Page 1 of 2 (4 items)</p>
                                            <!-- **todas las posibilidades** --
                                                                                      <a href="#" class="rewd_dis"></a> 
                                                                                      <a href="#" class="rewd"></a>                                                                 
                                                                                      <a href="#" class="prev_dis"></a>                                                                
                                                                                      <a href="#" class="prev"></a>
                                                                                      <a href="#" class="next"></a>
                                                                                      <a href="#" class="next_dis"></a>
                                                                                      <a href="#" class="fwrd"></a> 
                                                                                      <a href="#" class="fwrd_dis"></a> -->

                                            <a href="#" class="prev_dis"></a>
                                            <div class="current">1</div>
                                            <a href="#" class="numbers">2</a>
                                            <a href="#" class="next"></a>
                                        </div>
                                        <!--pagination-->
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!--grid_wrap-->

                    <div class="grid_wrap margin_t_10">
                        <table>
                            <thead class="headgrid">
                                <tr>
                                    <td class="c1">
                                        <div>Type</div>
                                    </td>
                                    <td class="c2">
                                        <div>Address</div>
                                    </td>
                                    <td class="c3">
                                        <div>Primary</div>
                                    </td>
                                    <td class="c4">
                                        <div>Edit</div>
                                    </td>
                                    <td class="c5">
                                        <div>Delete</div>
                                    </td>
                                </tr>
                            </thead>
                            <tbody class="datagrid">
                                <tr>
                                    <td class="c1">
                                        <div>Home</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Work</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"><span class="primary_chk"></span></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Other</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                                <tr>
                                    <td class="c1">
                                        <div>Other</div>
                                    </td>
                                    <td class="c2">
                                        <div>jrodriguez@mycompany.com</div>
                                    </td>
                                    <td class="c3"><span class="primary_chk"></span></td>
                                    <td class="c4">
                                        <input type="submit" class="edit_file"></td>
                                    <td class="c5">
                                        <input type="submit" class="delete_file"></td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="5">
                                        <div class="pagination">
                                            <p>Page 1 of 2 (4 items)</p>
                                            <!-- **todas las posibilidades** --
                                                                          <a href="#" class="rewd_dis"></a> 
                                                                          <a href="#" class="rewd"></a>                                                                 
                                                                          <a href="#" class="prev_dis"></a>                                                                
                                                                          <a href="#" class="prev"></a>
                                                                          <a href="#" class="next"></a>
                                                                          <a href="#" class="next_dis"></a>
                                                                          <a href="#" class="fwrd"></a> 
                                                                          <a href="#" class="fwrd_dis"></a> -->

                                            <a href="#" class="prev_dis"></a>
                                            <div class="current">1</div>
                                            <a href="#" class="numbers">2</a>
                                            <a href="#" class="next"></a>
                                        </div>
                                        <!--pagination-->
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!--grid_wrap-->

                    <div class="fondo_gris">
                        <div class="grupos de_2 radios_list">
                            <div style="width: auto">
                                <label class="label">Tiene Usted Vehiculo a su Nombre?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_14" type="radio" value="" class="" id="si14" />
                                            <label for="si14">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_14" type="radio" value="" class="" id="no14" />
                                            <label for="no14">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <!--grupos de_2 radios_list-->
                    </div>
                    <!--fondo_gris-->


                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><strong>SEGURO DE HOGAR</strong></div>
                <div class="content_fondo_blanco">
                    <div class=" margin_t_20">
                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de hogar?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_7" type="radio" value="Yes" data-input="7" class="static_class" id="si7" />
                                            <label class="label-radio" for="si7">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_7" type="radio" value="No" data-input="7" class="static_class" id="no7" />
                                            <label class="label-radio" for="no7">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="7" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="break_line"></div>

                        <div class="grupos radios_list de_2 margin_t_25">
                            <div>
                                <label class="label">Tiene usted algun tipo de seguro contra desastres naturales?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_8" type="radio" value="Yes" data-input="8" class="static_class" id="si8" />
                                            <label class="label-radio" for="si8">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_8" type="radio" value="No" data-input="8" class="static_class" id="no8" />
                                            <label class="label-radio" for="no8">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="8" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                    </div>
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height min_height2">
                <div class="titulos_azules"><strong>SEGURO DE SALUD</strong></div>
                <div class="content_fondo_blanco">

                    <div class=" margin_t_20">
                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Tiene usted seguro de salud?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_9" type="radio" value="Yes" data-input="9" class="static_class" id="si9" />
                                            <label class="label-radio" for="si9">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_9" type="radio" value="No" data-input="9" class="static_class" id="no9" />
                                            <label class="label-radio" for="no9">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="9" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                        <div class="break_line"></div>

                        <div class="grupos radios_list de_2 margin_t_25">
                            <div>
                                <label class="label">Tiene usted seguro salud con cobertura internacional?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_10" type="radio" value="Yes" data-input="10" class="static_class" id="si10" />
                                            <label class="label-radio" for="si10">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_10" type="radio" value="No" data-input="10" class="static_class" id="no10" />
                                            <label class="label-radio" for="no10">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="10" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Cual</label>
                                <input type="text">
                            </div>
                        </div>

                    </div>
                    <!--margin_t_20-->

                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><strong>SEGUROS DE VIAJES</strong></div>
                <div class="content_fondo_blanco">

                    <div class=" margin_t_20">
                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Viaja usted frecuentemente?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_11" type="radio" value="Yes" data-input="11" class="static_class" id="si11" />
                                            <label class="label-radio" for="si11">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_11" type="radio" value="No" data-input="11" class="static_class" id="no11" />
                                            <label class="label-radio" for="no11">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div data-input="11" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">A que paises viaja</label>
                                <input type="text">
                            </div>
                        </div>
                        <div data-input="11" class="extra grupos de_2" style="display: none;">
                            <div>
                                <label class="label">Motivo del viaje</label>
                                <input type="text">
                            </div>
                        </div>

                    </div>
                    <!--margin_t_20-->

                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

        <div class="col-1-3">
            <div class="fondo_blanco fix_height">
                <div class="titulos_azules"><strong>OTROS</strong></div>
                <div class="content_fondo_blanco">

                    <div class=" margin_t_20">
                        <div class="grupos">
                            <div>
                                <label class="label">Cual es su banco?</label>
                                <input type="text">
                            </div>
                        </div>
                        <div class="grupos radios_list de_2">
                            <div>
                                <label class="label">Le gustaria abrir una cuenta de banco internacional como StateTrust Bank?</label>
                            </div>
                            <div>
                                <table class="radio">
                                    <tr>
                                        <td>
                                            <input name="radio_12" type="radio" value="Yes" data-input="12" class="static_class" id="si12" />
                                            <label class="label-radio" for="si12">Si</label>
                                        </td>
                                        <td>
                                            <input name="radio_12" type="radio" value="No" data-input="12" class="static_class" id="no12" />
                                            <label class="label-radio" for="no12">No</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                    </div>
                    <!--margin_t_20-->

                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--col-1-3-->

    </li>
</ul>
