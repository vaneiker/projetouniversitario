using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.NegocioDbVentas;

namespace SistemaFacturacion.Formularios
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }
        DocumentValidator d = new DocumentValidator();
        private void button1_Click(object sender, EventArgs e)
            {

  
            string tipo;
          tipo = comboBox1.Text;

            switch(tipo)
                {
                case "RNC":

                    var Rnc = d.IsValidModulo11(textBox1.Text);
                   if(Rnc == true)
                        {
                        MessageBox.Show("El RNC Es Correcta");
                        }
                    else
                        {
                        MessageBox.Show("El RNC Es InCorrecta");
                        }
                    
                    break;

                case "Cedula":
                    var Cedula = d.IsValidModulo10(textBox1.Text);
                    if (Cedula == true)
                        {
                        MessageBox.Show("La Cedula Es Correcta");
                        }
                    else
                        {
                        MessageBox.Show("La Cedula Es InCorrecta");
                        }
                    break;

                }


            //string validarDocumento;
            //if (validarDocumento.Length)
            //    {

            //    }

            //var ver= d.IsValidModulo10(textBox1.Text);
            //if (ver == true)
            //    {
            //    MessageBox.Show("La Cedula Es Correcta");
            //    } else
            //    {
            //    MessageBox.Show("La Cedula Es InCorrecta");
            //    }


            }
        }
    }
