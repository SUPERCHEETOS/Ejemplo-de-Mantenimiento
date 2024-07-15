using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Capa_Datos
{
    public class dPaciente
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ConnectionString);

        public DataTable cd_ListarPacientes()
        {
            SqlCommand cmd = new SqlCommand("sp_listaPacientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public string DMantenimientoPaciente(Paciente obj, string accion)
        {
            SqlCommand cmd = new SqlCommand("sp_mantenimiento_paciente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI", obj.DNI);
            cmd.Parameters.AddWithValue("@Nombre_Completo", obj.Nombre_Completo);
            cmd.Parameters.AddWithValue("@Fecha_de_nacimiento", obj.Fecha_de_nacimiento);
            cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
            cmd.Parameters.AddWithValue("@Numero_de_celular", obj.Numero_de_celular);
            cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);
            cmd.Parameters.AddWithValue("@Distrito", obj.Distrito);

            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = accion;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            string Mensaje = "";

            switch (accion)
            {
                case "1": Mensaje = "Paciente Registrado Correctamente"; break;
                case "2": Mensaje = "Paciente Editado Correctamente"; break;
                case "3": Mensaje = "Paciente Eliminado Correctamente"; break;
            }

            return Mensaje;
        }
        public int nValidacionPaciente(Paciente obj)
        {
            SqlCommand cmd = new SqlCommand("logearse", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI", obj.DNI);
            cmd.Parameters.AddWithValue("@Numero_de_celular", obj.Numero_de_celular);

            cmd.Parameters.Add("@admin", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@validacion", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            int validacion = 0;
            int admin = 0;

            validacion = Convert.ToInt32(cmd.Parameters["@validacion"].Value.ToString());
            admin = Convert.ToInt32(cmd.Parameters["@admin"].Value.ToString());

            return admin;
        }
    }
}
