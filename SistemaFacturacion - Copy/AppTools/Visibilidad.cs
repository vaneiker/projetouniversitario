using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.AppTools
{
    class Visibilidad
    {
            public static void MenuPrincipal(int rolid, Form formulario)
            {
                List<Control> controles = new List<Control>();
                GetControls(formulario, controles);
                List<Button> botones = new List<Button>();
                
                foreach(Control c in controles)
                {
                    if(c.GetType() == typeof(Button))
                    {
                        string name = c.Name.ToLower();
                        if (name.StartsWith("btn"))
                            botones.Add(c as Button);
                    }
                }
                //comparamos el rolid
                // para esconder o ver BtnArticulos, BtnCategoria, BtnCliente, btnCxc, btnCuentaPxp, BtnIngreso, BtnProveedor, btnEmpleado, btnCotizacion
                switch (rolid)
                {
                    case 1:
                        break;
                    case 2:
                        foreach(Button btn in botones)
                        {
                        if (btn.Name.Equals("BtnIngreso") || btn.Name.Equals("BtnProveedor"))
                            continue;
                        else
                            btn.Visible = false;
                        }
                        break;
                    case 3:
                    foreach (Button btn in botones)
                    {
                        if (btn.Name.Equals("BtnCliente") || btn.Name.Equals("btnCotizacion"))
                            continue;
                        else
                            btn.Visible = false;
                    }
                    break;
                    case 4:
                    foreach (Button btn in botones)
                    {
                        if (btn.Name.Equals("btnCuentaPxp") || btn.Name.Equals("BtnIngreso") || btn.Name.Equals("BtnProveedor") || btn.Name.Equals("BtnCategoria") || btn.Name.Equals("BtnArticulos"))
                            continue;
                        else
                            btn.Visible = false;
                    }
                    break;
                    case 5:
                    foreach (Button btn in botones)
                    {
                        if (btn.Name.Equals("BtnCliente") || btn.Name.Equals("btnCxc") || btn.Name.Equals("btnCotizacion"))
                            continue;
                        else
                            btn.Visible = false;
                    }
                    break;
                    case 6:
                      //solo puede ver reportes
                        break;
                    case 7:
                    foreach (Button btn in botones)
                    {
                        if (btn.Name.Equals("BtnEmpleado"))
                            continue;
                        else
                            btn.Visible = false;
                    }
                    break;
                }
            }

            private static void GetControls(Control control, List<Control> list)
            {
                foreach(Control c in control.Controls)
                {
                    list.Add(c);
                    if (c.GetType() == typeof(Panel))
                        GetControls(c, list);
                }
            }
        }
    }