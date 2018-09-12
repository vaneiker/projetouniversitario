using System;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Generalmethods
    {
        public static String getReportstringlastline(String name, String contributionperiod, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                " Operador #" + contributionperiod + " en nuestra sede principal. Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") +
     " Si desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.StateTrust Life and " +
 " Annuities, Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB')" +
 " Favor leer con detenimiento todas las páginas de la ilustración ";
            return str;
        }
        public static string getsuplementosline(string adb, string term, string oir, string adbamt, string termamt, string oiramt, string termage, string oirage)
        {
            string str = "";
            str = "Este Plan tiene las siguientes coberturas adicionales sujetas a la aprobación final por Atlántica Seguros, S.A.:\n";
            if (adb != "N")
            {
                str = str + "Cobertura por Muerte Accidental hasta los 65 Años por:   " + Convert.ToDecimal(adbamt).ToString("n2") + "\n";
            }
            if (term == "Y")
            {
                str = str + "Temporal Adicional hasta la Edad de " + termage + " Años:   " + Convert.ToDecimal(termamt).ToString("n2") + "\n";
            }
            if (oir == "Y")
            {
                str = str + "Temporal otro Asegurado hasta la Edad de " + oirage + " Años:   " + Convert.ToDecimal(oiramt).ToString("n2") + "\n";
            }

            return str;
        }

        public static string getsuplementosline(String productcode, string adb, string term, string oir, string adbamt, string termamt, string oiramt, string termage, string oirage)
        {
            string str = "";
            str = "Esta póliza tiene las siguientes coberturas adicionales, o suplementos, sujetos a la aprobación final por Atlántica Seguros, S.A.:\n";
            if (adb != "N")
            {
                str = str + "Cobertura por Muerte Accidental hasta los 65 Años por:   " + double.Parse(adbamt).ToString("n2") + "\n";
            }
            if (term == "Y")
            {
                str = str + "Temporal Adicional hasta la Edad de " + termage + " Años:   " + Convert.ToDecimal(termamt).ToString("n2") + "\n";
            }
            if (oir == "Y")
            {
                str = str + "Temporal otro Asegurado hasta la Edad de " + oirage + " Años:   " + Convert.ToDecimal(oiramt).ToString("n2") + "\n";
            }

            return str;
        }

        public static string getsuplementoslineNew(string adb, string term, string oir, string adbamt, string termamt, string oiramt, string termage, string oirage, char classcode)
        {
            string str = "";
            str = "Esta póliza tiene las siguientes coberturas adicionales, o suplementos, sujetos a la aprobación final por Atlántica Seguros, S.A.:\n";
            if (adb != "N")
            {
                str = str + "Cobertura por Muerte Accidental hasta los 65 Años por:   " + Program.getCurrencyString(classcode, double.Parse(adbamt)) + "\n";
            }
            if (term == "Y")
            {
                str = str + "Temporal Adicional hasta la Edad de " + termage + " Años:   " + Program.getCurrencyString(classcode, double.Parse(termamt)) + "\n";
            }
            if (oir == "Y")
            {
                str = str + "Temporal otro Asegurado hasta la Edad de " + oirage + " Años:   " + Program.getCurrencyString(classcode, double.Parse(oiramt)) + "\n";
            }

            return str;
        }

        public static String getLightHouseDescriptionline(String amountofcontribution)
        {
            String str = null;

            str = "Lighthouse es un seguro de vida temporal.";
            str = str + " Este plan tendrá una duración ";
            str = str + "de " + amountofcontribution + " Años y primas niveladas " +
                         "garantizadas pagaderas durante " + amountofcontribution + " Años. Antes de cumplir el Año " + amountofcontribution + " de la Póliza o que Usted cumpla 65 años, lo que ocurra primero, Usted tendrá la opción de convertir su Póliza a un producto de Vida illusdata_universal dentro de una serie de opciones que StateTrust Life and Annuities, Ltd., ofrece para este fin. A destacar que este seguro brinda protección garantizada por un período de tiempo específico sujeto a las condiciones del Contrato.";// +
            //"período de tiempo específico sujeta a las condiciones del Contrato.";
            return str;
        }
        public static String getLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A., Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") + ".  Si desea " +
                        "comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.  Atlántica Seguros, S.A., " +
                        "Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB').  " +
                        "Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getLastlineTerm(String name, int random, char class1)
        {
            string cls = "";
            if (class1 == 'A')
            {
                cls = "USD ($)";
            }
            else if (class1 == 'R')
            {
                cls = "RD$";
            }
            else
            {
                cls = "EUR (€)";
            }



            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A, Operador" +
                        " # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + "." +
                        " Si desea comunicarse con no sotros lo puede hacer a través de nuestro sitio de internet http://atlantica.do/ en la sección 'Centro de Llamadas'." +
                        " Atlántica Seguros, S.A es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD')." +
                        " Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getLastlineTerm(String productcode, String name, int random, char class1)
        {
            string cls = "";
            if (class1 == 'A')
            {
                cls = "USD ($)";
            }
            else if (class1 == 'R')
            {
                cls = "RD$";
            }
            else
            {
                cls = "EUR (€)";
            }
            String str = "";


            if (productcode.Equals("GRD"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A, Operador" +
                        " # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + ".\n" +
                        " Si usted desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet http://www.atlantica.do/ en la sección 'Centro de Llamadas'." +
                        " Atlántica Seguros, S.A es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD')." +
                        " Favor leer con detenimiento todas las páginas de la ilustración.";
            }
            else if (productcode.Equals("GRP"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A, Operador" +
                        " # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + ".\n" +
                        " Si usted desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet http://www.atlantica.do/ en la sección 'Centro de Llamadas'." +
                        " Atlántica Seguros, S.A es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD')." +
                        " Favor leer con detenimiento todas las páginas de la ilustración.";
            }
            else if (productcode.Equals("ORN"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A, Operador" +
                        " # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + ".\n" +
                        " Si usted desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet http://www.atlantica.do/ en la sección 'Centro de Llamadas'." +
                        " Atlántica Seguros, S.A es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD')." +
                        " Favor leer con detenimiento todas las páginas de la ilustración.";
            }
            if (productcode.Equals("ORP"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A, Operador" +
                        " # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + ".\n" +
                        " Si usted desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet http://www.atlantica.do/ en la sección 'Centro de Llamadas'." +
                        " Atlántica Seguros, S.A es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD')." +
                        " Favor leer con detenimiento todas las páginas de la ilustración.";
            }




            return str;
        }
        public static String getcompassLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de atlántica del seguro, Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") + ".  Si desea " +
                        "comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.  StateTrust Life and Annuities, " +
                        "Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas.  " +
                        "Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getLightHouseDescriptionline(String amountofcontribution, string name)
        {
            String str = null;

            str = name + " es un seguro de vida temporal.";
            str = str + " Este plan tendrá una duración ";
            str = str + "de " + amountofcontribution + " Años y primas niveladas " +
                         "garantizadas pagaderas durante " + amountofcontribution + " Años.  Antes de cumplir el Año " + amountofcontribution + " del Plan o que Usted cumpla 65 años, lo que ocurra primero, Usted tendrá la opción de convertir su Plan a un producto de Vida illusdata_universal dentro de una serie de opciones que Atlántica Seguros, S.A., Ltd., ofrece para este fin. A destacar que este seguro brinda protección garantizada por un período de tiempo específico sujeto a las condiciones del Contrato.La prima Periódica no incluye el Impuesto Selectivo a los Seguros.";// +
            //"período de tiempo específico sujeta a las condiciones del Contrato.";
            return str;
        }

        public static String getDescriptionline(String productcode, int noofyears)
        {
            String str = null;

            if (productcode.Equals("GRD"))
            {
                str = "Guardián es un seguro de vida temporal con Devolución" + ((noofyears < 20) ? " Parcial" : "") + " de Prima.";
                str = str + " Esta póliza tendrá una duración inicial  de " + (noofyears.ToString()) + "  años y primas niveladas garantizadas pagaderas durante " + (noofyears.ToString()) + " Años.";
                str = str + " Antes de cumplir el año " + (noofyears.ToString()) + "  de la Póliza  o que usted cumpla 65 años, lo que ocurra primero, usted tendrá la opción de convertir su póliza a un producto de Vida Permanente sujeto a suscripción, dentro de una serie de opciones que Atlántica Seguros, S.A., pudiera ofrecer  para este fin, en caso que esta opción de producto se encuentre disponible. Cabe destacar que este seguro brinda  protección garantizada  por un período de tiempo específico sujeto a las condiciones del Contrato. La prima periódica  no incluye el impuesto selectivo a los seguros.   ";
                //str = str + " Este plan tendrá una duración ";
                //str = str + "de " + amountofcontribution + " Años y primas niveladas " +
                //             "garantizadas pagaderas durante " + amountofcontribution + " Años.  Antes de cumplir el Año " + amountofcontribution + " del Plan o que Usted cumpla 65 años, lo que ocurra primero, Usted tendrá la opción de convertir su Plan a un producto de Vida illusdata_universal dentro de una serie de opciones que Atlántica Seguros, S.A., Ltd., ofrece para este fin. A destacar que este seguro brinda protección garantizada por un período de tiempo específico sujeto a las condiciones del Contrato.La prima Periódica no incluye el Impuesto Selectivo a los Seguros.";// +
                //"período de tiempo específico sujeta a las condiciones del Contrato.";
            }
            else if (productcode.Equals("GRP"))
            {
                /*str = "Guardián Plus es un seguro de vida temporal con Devolución" + ((noofyears < 20) ? " Parcial" : "") + " de Prima.";
                str = str + " Esta póliza tendrá una duración inicial  de " + (noofyears.ToString()) + "  años y primas niveladas garantizadas pagaderas durante " + (noofyears.ToString()) + " Años.";
                str = str + " Antes de cumplir el año " + (noofyears.ToString()) + "  de la Póliza  o que usted cumpla 65 años, lo que ocurra primero, usted tendrá la opción de convertir su póliza a un producto de Vida Permanente sujeto a suscripción, dentro de una serie de opciones que Statetrust Life El Salvador, S.A. Seguros De Personas., pudiera ofrecer  para este fin, en caso que esta opción de producto se encuentre disponible. Cabe destacar que este seguro brinda  protección garantizada  por un período de tiempo específico sujeto a las condiciones del Contrato.   ";
                */
                str = "Guardián Plus es un seguro de vida a término con devolución de prima, se utiliza para cubrir las necesidades de protección financiera de su familia durante un periodo de tiempo específico sujeto a las condiciones ";
                str += "del contrato. Las primas se fijan y deben ser pagadas dentro de un periodo de tiempo específico o la póliza es cancelada. Este producto ofrece una cobertura con primas niveladas durante la vigencia de la póliza que ";
                str += "maximiza la relación costo / protección.Esta póliza no solo proveerá recursos financieros a su familia en caso de muerte prematura, sino que, además, al final del periodo contatado se reembolsara las primas pagadas ";
                str += "de acuerdo a las condiciones del contrato.";
                //str = str + " Este plan tendrá una duración ";
                //str = str + "de " + amountofcontribution + " Años y primas niveladas " +
                //             "garantizadas pagaderas durante " + amountofcontribution + " Años.  Antes de cumplir el Año " + amountofcontribution + " del Plan o que Usted cumpla 65 años, lo que ocurra primero, Usted tendrá la opción de convertir su Plan a un producto de Vida illusdata_universal dentro de una serie de opciones que Atlántica Seguros, S.A., Ltd., ofrece para este fin. A destacar que este seguro brinda protección garantizada por un período de tiempo específico sujeto a las condiciones del Contrato.La prima Periódica no incluye el Impuesto Selectivo a los Seguros.";// +
                //"período de tiempo específico sujeta a las condiciones del Contrato.";
            }
            else if (productcode.Equals("ORN"))
            {
                str = "Orión es un seguro de vida temporal. Esta póliza tendrá una duración inicial de {0} años y primas niveladas garantizadas pagaderas durante {0} Años. Antes de cumplir el año";
                str += "{0} de la Póliza o que usted cumpla 65 años, lo que ocurra primero, usted tendrá la opción de convertir su póliza a un producto de Vida Permanente sujeto a suscripción, dentro de una serie de opciones que";
                str += "Atlántica Seguros, S.A., pudiera ofrecer para este fin, en caso que esta opción de producto se encuentre disponible. Cabe destacar que este seguro brinda protección garantizada por un período de tiempo";
                str += "específico sujeto a las condiciones del Contrato. La prima periódica no incluye el impuesto selectivo a los seguros.";
                str = String.Format(str, noofyears);
            }
            if (productcode.Equals("ORP"))
            {
                /* str = "Orión Plus es un seguro de vida temporal. Esta póliza tendrá una duración inicial de {0} años y primas niveladas garantizadas pagaderas durante {0} Años. Antes de cumplir el año {0}";
                str += " de la Póliza o que usted cumpla 65 años, lo que ocurra primero, usted tendrá la opción de convertir su póliza a un producto de Vida Permanente sujeto a suscripción, dentro de una serie de opciones que";
                str += " Statetrust Life El Salvador, S.A. Seguros De Personas., pudiera ofrecer para este fin, en caso que esta opción de producto se encuentre disponible. Cabe destacar que este seguro brinda protección garantizada por un período de tiempo";
                str += "específico sujeto a las condiciones del Contrato. ";
                str = String.Format(str, noofyears);
                */
                str = "Orión Plus es un seguro de vida a término, se utiliza para cubrir las necesidades de protección financiera de su familia durante un periodo de tiempo específico sujeto a las condiciones del contrato. ";
                str += "Las primas se fijan y deben ser pagadas dentro de un periodo de tiempo específico o la póliza es cancelada. Este producto ofrece una cobertura con primas niveladas durante la vigencia de la póliza que ";
                str += "maximiza la relación costo / protección.";
            }
            return str;
        }


        public static String getReportstringlastline(String productcode, String name, String contributionperiod, char class1)
        {
            String str = "";

            if (productcode.Equals("GRD"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                " Operador #" + contributionperiod + " en nuestra sede principal. Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") +
     " Si desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.StateTrust Life and " +
 " Annuities, Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB')" +
 " Favor leer con detenimiento todas las páginas de la ilustración ";
            }
            else if (productcode.Equals("GRP"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                " Operador #" + contributionperiod + " en nuestra sede principal. Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") +
     " Si desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.StateTrust Life and " +
 " Annuities, Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB')" +
 " Favor leer con detenimiento todas las páginas de la ilustración ";
            }
            else if (productcode.Equals("ORN"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                " Operador #" + contributionperiod + " en nuestra sede principal. Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") +
     " Si desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.StateTrust Life and " +
 " Annuities, Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB')" +
 " Favor leer con detenimiento todas las páginas de la ilustración ";
            }
            else if (productcode.Equals("ORP"))
            {
                str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                " Operador #" + contributionperiod + " en nuestra sede principal. Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") +
     " Si desea comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.StateTrust Life and " +
 " Annuities, Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas ('IVB')" +
 " Favor leer con detenimiento todas las páginas de la ilustración ";
            }

            return str;
        }

        public static String getSentinalDescriptionline(String amountofcontribution)
        {
            String str = null;
            str = "Sentinel es un seguro de vida temporalcon devolución de prima.";

            str = str + " Este plan tendrá una duración ";

            str = str + "inicial ";

            str = str + "de " + amountofcontribution + " Años y primas niveladas " +
                         "garantizadas pagaderas durante " + amountofcontribution + " Años.  Antes de cumplir el Año " + amountofcontribution + " del Plan o que Ud cumpla 65 Años, lo que ocurra primero, Ud. tendrá la opción de convertir su Plan a un producto de Vida illusdata_universal dentro de una serie de opciones que StateTrust Life and Annuities, Ltd. ofrece para este fin.    A destacar que este seguro brinda protección garantizada por un período de tiempo específico sujeta a las condiciones del Contrato.";
            return str;
        }

        public static String getReturnofpremium(String amountofcontribution)
        {
            String str = "Una vez hayan transcurrido los " + amountofcontribution + " Años de Duración de este Plan y siempre y cuando todas" +
                        "las primas adeudas hayan sido pagadas y el Plan se encuentre efectivo y no haya sido cancelado, StateTrust Life  procederá a devolver las primas " +
                        "pagadas por Ud. dentro de los 90 días siguientes a la ,terminación del Plan.";
            return str;
        }

        public static String getHorizonLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.Si desea comunicarse con nosotros lo puede hacer a través de nuestro " +
                        "sitio de internet en la sección 'Contact us'.  StateTrust Life and Annuities,Ltd. es una compañía registrada y regulada exclusivamente por la Comisión " +
                        "de Servicios Financieros en las Islas Vírgenes Británicas (IVB).Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String geteduplanLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                       "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.Si desea comunicarse con nosotros lo puede hacer a través de nuestro " +
                       "sitio de internet en la sección 'Contact us'.  StateTrust Life and Annuities,Ltd. es una compañía registrada y regulada exclusivamente por la Comisión " +
                       "de Servicios Financieros en las Islas Vírgenes Británicas (IVB).Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }

        public static String getScholarLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + (class1 == 'A' ? "USD ($)" : "EUR (€)") + ".  Si desea " +
                        "comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet en la sección 'Contact us'.  StateTrust Life and Annuities, " +
                        "Ltd. es una compañía registrada y regulada exclusivamente por la Comisión de Servicios Financieros en las Islas Vírgenes Británicas (IVB).  " +
                        "Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getHorizongrowthLastline(String name, int random, char class1)
        {

            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de StateTrust Life and Annuities, Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.Si desea comunicarse con nosotros lo puede hacer a través de nuestro " +
                        "sitio de internet en la sección 'Contact us'.  StateTrust Life and Annuities,Ltd. es una compañía registrada y regulada exclusivamente por la Comisión " +
                        "de Servicios Financieros en las Islas Vírgenes Británicas.Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getLastlineFuneral(String name, int random, char class1)
        {
            string cls = "";
            if (class1 == 'A')
            {
                cls = "USD ($)";
            }
            else if (class1 == 'R')
            {
                cls = "RD$";
            }
            else if (class1 == 'E')
            {
                cls = "EUR (€)";
            }
            String str = "Esta presentación ha sido preparada a solicitud de " + name + " por el departamento de nuevos negocios de Atlántica Seguros, S.A., Ltd.," +
                        "Operador # " + String.Format("{0:00}", random) + " en nuestra sede principal.  Los Valores en esta ilustración están expresados en " + cls + ".  Si desea " +
                        "comunicarse con nosotros lo puede hacer a través de nuestro sitio de internet http://www.atlantica.do/ en la sección 'Centro de Llamadas'.  Atlántica Seguros, S.A., " +
                        "Ltd. es una compañía registrada y regulada exclusivamente por la Superintendencia de Seguros de la República Dominicana  (RD').  " +
                        "Favor leer con detenimiento todas las páginas de la ilustración.";
            return str;
        }
        public static String getFuneralDescriptionline(String amountofcontribution, string name, string productcode)
        {
            String str = null;
            if (productcode == "LUM")
            {
                str = "Ultimos Gastos-" + name + " es un plan funerario que le brinda la opción de recibir su indemnización de dos formas: ";
                str = str + "(1) Atlántica emitirá un pago único hasta la cantidad contratada. Bajo esta opción la única responsabilidad";
                str = str + " de la compañía es la emisión del  pago sin consideración de los gastos actuales del proceso funerario; (2) Atlántica brindará todos";
                str = str + " los servicios funerarios, incluyendo gestiones a través de terceros, hasta el monto determinado en el contrato. Estos servicios  incluyen: (i) Servicios Funerarios: ";
                str = str + "(Recogido del fallecido en hospital, clínica o casa, Ataúd, Sala funeraria por dos días y oficio religioso, Cosmetización, Embalsamamiento, Traslado de restos a nivel nacional, ";
                str = str + "Flores y recordatorios, Libro de firmas, Esquela de prensa, Carroza fúnebre); (ii) Servicios de Inhumación: (Alquiler de lote público por 5 años, Inhumación ";
                str = str + "en nicho o sarcófago, Lápida o Cruz, Carpa); (iii) Servicios de Apoyo Familiar: (Asistente familiar y Asistencia en cuidados infantiles). La prima periódica no incluye el Impuesto Selectivo ";
                str = str + "a los Seguros.El Plan proveerá una cobertura máxima, sin incluir las coberturas adicionales de hasta " + amountofcontribution;

            }
            else if (productcode == "LUV")
            {
                str = "Ultimos Gastos-" + name + " es un plan funerario que le brinda la opción de recibir su indemnización de dos forma:";
                str = str + "(1) Atlántica emitirá un pago único hasta la cantidad contratada. Bajo esta opción la única responsabilidad";
                str = str + " de la compañía es la emisión del  pago sin consideración de los gastos actuales del proceso funerario; (2) Atlántica brindará todos";
                str = str + " los servicios funerarios, incluyendo gestiones a través de terceros, hasta el monto determinado en el contrato. Estos servicios  incluyen: (i) Servicios Funerarios: ";
                str = str + "(Recogido del fallecido en hospital, clínica o casa, Ataúd, Sala funeraria por dos días y oficio religioso, Cosmetización, Embalsamamiento, Traslado de restos a nivel nacional, ";
                str = str + "Flores y recordatorios, Libro de firmas, Esquela de prensa, Carroza fúnebre, Vehículo Familiar y Autobús); (ii) Servicios de Inhumación: (Alquiler de lote público por 5 años, Inhumación";
                str = str + "en nicho o sarcófago, Lápida o Cruz, Carpa, Descensor Automático y Sillas en cementerio privado); (iii) Servicios de Apoyo Familiar: (Asistente familiar, Asistencia en cuidados infantiles, Asistencia emocional y Asistencia legal).La prima periódica no incluye el Impuesto Selectivo";
                str = str + "a los Seguros.El Plan proveerá una cobertura máxima, sin incluir las coberturas adicionales de hasta " + amountofcontribution;
            }
            else if (productcode == "EXE")
            {
                str = "Ultimos Gastos-" + name + " es un plan funerario que le brinda la opción de recibir su indemnización para gastos de cremación de dos formas:  (1)  Atlántica emitirá un pago único hasta la cantidad contratada. Bajo esta opción la única responsabilidad de la compañía es la emisión de un pago por una suma determinada sin consideración de los gastos actuales del proceso de cremación;.  (2) Atlántica brindará los siguientes servicios de cremación hasta el monto determinado en el contrato: (i) Servicios Funerarios: (Recogido del fallecido en hospital, clínica o casa, Traslado de restos a nivel nacional, Urna básica y Esquela de prensa); (ii) Servicios de Apoyo Familiar: (Asistente familiar y Asistencia en cuidados infantiles). Los precios incluyen el Impuesto Selectivo a los Seguros. Este plan no incluye ningún servicio relacionado a Sala Funeraria. La prima periódica no incluye el Impuesto Selectivo a los Seguros.";
                str = str + " El Plan proveerá una cobertura máxima, sin incluir las coberturas adicionales de hasta " + amountofcontribution;
            }
            else if (productcode == "EXV")
            {
                str = "Ultimos Gastos-" + name + " es un plan funerario que le brinda la opción de recibir su indemnización para gastos de cremación de dos formas:  (1)  Atlántica emitirá un pago único hasta la cantidad contratada. Bajo esta opción la única responsabilidad de la compañía es la emisión de un pago por una suma determinada sin consideración de los gastos actuales del proceso de cremación;  (2) Atlántica brindará los siguientes servicios de cremación hasta el monto determinado en el contrato: (i) Servicios Funerarios: (Recogido del fallecido en hospital, clínica o casa, Ataúd, Sala Funeraria y Oficio Religioso, Cosmetización, Traslado de restos a nivel nacional, Flores y recordatorios, Libro de firmas, Urna a selección y Esquela de prensa); (ii) Servicios de Apoyo Familiar: (Asistente familiar, Asistencia en cuidados infantiles, Asistencia emocional y Asistencia legal).  La prima periódica no incluye el Impuesto Selectivo a los Seguros.";
                str = str + " El Plan proveerá una cobertura máxima, sin incluir las coberturas adicionales de hasta " + amountofcontribution;
            }
            return str;
        }
        public static string getsuplementoslineFuneral(string adb, string term, string oir)
        {
            string str = "";
            str = "Este Plan tiene las siguientes coberturas adicionales sujetas a la aprobación final por Atlántica Seguros, S.A.:\n";
            if (adb != "N")
            {
                str = str + "Cobertura Familiar - incluye cónyugue (debe ser menor a 65 años y menor al Titular) e hijos con el mismo límite de la cobertura principal del Titular\n";
            }
            if (term == "Y")
            {
                str = str + "Cobertura reembolso gastos de repatriación hasta por un monto de $RD 200000\n";
            }
            if (oir == "P")
            {
                str = str + "Cobertura de inclusión de Lote en Cementerio hasta por un monto de $RD 65000";
            }
            if (oir == "R")
            {
                str = str + "Cobertura de inclusión de Lote en Cementerio hasta por un monto de $RD 200000";
            }
            return str;
        }
    }
}
