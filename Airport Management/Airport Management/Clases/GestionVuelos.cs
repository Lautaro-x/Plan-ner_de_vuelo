﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Airport_Management.Clases
{
    class GestionVuelos
    {
        //GESTION CATEGORÍA TRABAJA CON LA CLASE CATEGORÍAS.

        public GestionVuelos()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        //public DataTable listarVuelos(String nombreTabla)
        //{
        //    AccesoDatos ad = new AccesoDatos();
        //    return ad.ObtenerTabla(nombreTabla, "select * from Vuelos");
        //}

        public void listarVuelos(String nombreTabla, ref DataSet ds)
        {
            AccesoDatos ad = new AccesoDatos();
            ad.cargaTabla(nombreTabla, "select codigo_VLO as Código, codigo_RTA as Ruta, fecha_salida_VLO as [Fecha de salida] from vuelos", ref ds);
        }


        public bool eliminarVuelo(String NombreTabla, DataSet ds)
        {
            int FilasEliminadas = 0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
                fila.RejectChanges();
                AccesoDatos ad = new AccesoDatos();
                ArmarParametrosVuelosEliminar(ref Comando, fila);
                FilasEliminadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spEliminarVuelo");
            }
            if (FilasEliminadas >= 1)
                return true;
            else
                return false;
        }


        private void ArmarParametrosVuelosEliminar(ref SqlCommand Comando, DataRow fila)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@codigo_VLO", SqlDbType.VarChar);
            SqlParametros.Value = fila["codigo_vlo"];
            
        }



        public bool modificarVuelo(String NombreTabla, DataSet ds)
        {
            int FilasActualizadas = 0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
                ArmarParametrosVuelos(ref Comando, fila);
                AccesoDatos ad = new AccesoDatos();

                FilasActualizadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spModificarVuelo");
            }
            if (FilasActualizadas >= 1)
                return true;
            else
                return false;
        }

        public void ArmarParametrosVuelos(ref SqlCommand Comando, DataRow fila)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@codigo_VLO", SqlDbType.VarChar, 10);
            SqlParametros.Value = fila["codigo_vlo"];
            SqlParametros = Comando.Parameters.Add("@codigo_RTA", SqlDbType.VarChar, 10);
            SqlParametros.Value = fila["codigo_rta"];
        }

        public Boolean InsertarVuelo(String NombreTabla, DataSet ds)
        {
            int FilasInsertadas=0;
            foreach (DataRow fila in ds.Tables[NombreTabla].Rows)
            {
                SqlCommand Comando = new SqlCommand();
                ArmarParametrosVuelos(ref Comando, fila);
                AccesoDatos ad = new AccesoDatos();
                FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spInsertarVuelo");
            }
            if (FilasInsertadas >= 1)
                return true;
            else
                return false;
        }
    }
}
