using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.businesslogic
{

    public class EformTables
    {
        public static Boolean getEformTable(String formname, long customerplanno)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                String str = formname.Replace(' ', '_');
                switch (str)
                {
                    case "Source_Document":
                        {
                            var query = from item in newdb.Source_Documents where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        }; break;
                    case "Aplicacion_Axys_y_Scholar":
                        {
                            var query = from item in newdb.Aplicacion_Axysy_Scholars where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }; break;

                    case "Life_insurance_form":
                        {
                            var query = from item in newdb.Aplicacion_Legacies where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }; break;
                    case "Designacion_Perfil_Personalizado":
                        {
                            var query = from item in newdb.Designacion_Perfil_Personalizados where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        };
                        break;
                    case "Planilla_Pagos_Automaticos":
                        {
                            var query = from item in newdb.Planilla_Pagos_Automaticos where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Planilla_Pagos_One_Time":
                        {
                            var query = from item in newdb.Planilla_Pagos_One_Times where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }


                        };
                        break;
                    case "Instrucciones_Transferenciaen_USD":
                        {
                            var query = from item in newdb.InstruccionestransferenciaenESDs where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Instrucciones_Transferencia_en_Euros":
                        {

                            var query = from item in newdb.Instrucciones_Transferencia_en_Euros where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Cuestionario_para_Diabeticos":
                        {

                            var query = from item in newdb.Cuestionario_para_Diabeticos where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Cuestionario_para_Hipertensos":
                        {
                            var query = from item in newdb.Cuestionario_para_Hipertensos where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;

                    case "Cuestionario_Aviacion":
                        {
                            var query = from item in newdb.Cuestionario_Aviacions where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Cuestionario_Caceria_y_Tiro":
                        {
                            var query = from item in newdb.Cuestionario_Caceria_y_Tiros where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;

                    case "Cuestionario_Deportes_Peligrosos_Peligrosos":
                        {
                            var query = from item in newdb.Cuestionario_Deportes_Peligrosos_Peligrosos where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        };
                        break;
                    case "Cuestionario_Defensa_Personal":
                        {
                            var query = from item in newdb.Cuestionario_Defensa_Personals where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Cuestionario_Estado_Financiero":
                        {
                            var query = from item in newdb.Custionario_Estado_Financieros where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        };
                        break;
                    case "Cuestionario_Marina_Mercante":
                        {
                            var query = from item in newdb.Custionario_Marina_mercantes where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Planilla_Cambio_Condiciones_de_Poliza":
                        {
                            var query = from item in newdb.PlanillaCambiaCandicionesdepolizas where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;
                    case "Planilla_Cambios_Personales":
                        {
                            var query = from item in newdb.PlanillaCambiosPersonales where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;

                    case "Solicitud_Rehabilitación":
                        {
                            var query = from item in newdb.Solicitud_Rehabilitación20s where item.customerplanno == customerplanno select item;
                            if (query.Count() > 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        };
                        break;

                    default:
                        {
                            return false;
                        };
                        break;

                }

                return false;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return false;
        }
    }
}