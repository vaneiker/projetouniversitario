using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad.DbVentas;

namespace CapaDatos.RepocitoryDbVentas
    {
    public class ComboBoxTools
        {


        public DataTable GetProveedor()
            {
            using (dbventasEntity context = new dbventasEntity())
                {
                var connection = context.Database.Connection as SqlConnection;
                string Qry = "SP_GET_COMBOBOX_PROVEEDOR";
                using (SqlDataAdapter sda = new SqlDataAdapter(Qry, connection))

                    {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "---Seleccione---";
                    dt.Rows.InsertAt(row, 0);

                    return dt;


                    }
                }
            }

        public DataTable GetCategotia()
        {
        using (dbventasEntity context = new dbventasEntity())
            {
            var connection = context.Database.Connection as SqlConnection;
            string Qry = "SP_GET_COMBOBOX_CATEGORIA";
            using (SqlDataAdapter sda = new SqlDataAdapter(Qry, connection))

                {
                //Fill the DataTable with records from Table.
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Insert the Default Item to DataTable.
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "---Seleccione---";
                dt.Rows.InsertAt(row, 0);

                return dt;


                }
            }
        }


        public DataTable TipoDeFactura()
        {
            using (dbventasEntity context = new dbventasEntity())
            {
                var connection = context.Database.Connection as SqlConnection;
                string Qry = "SP_TIPO_FACTURA";
                using (SqlDataAdapter sda = new SqlDataAdapter(Qry, connection))

                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "---Seleccione---";
                    dt.Rows.InsertAt(row, 0);

                    return dt;


                }
            }
        }

  public DataTable GetRollD()
        {
            using (dbventasEntity context = new dbventasEntity())
            {
                var connection = context.Database.Connection as SqlConnection;
                string Qry = "SP_GET_ROLL_DROP";
                using (SqlDataAdapter sda = new SqlDataAdapter(Qry, connection))

                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "---Seleccione---";
                    dt.Rows.InsertAt(row, 0);

                    return dt;


                }
            }
        }

    }
    }
