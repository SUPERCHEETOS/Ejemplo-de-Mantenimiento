using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Datos;
using Capa_Entidades;
using System.Data;

namespace Capa_Service
{
    public class sPaciente
    {
        dPaciente objdatos = new dPaciente();
        public DataTable n_ListarPacientes()
        {
            return objdatos.cd_ListarPacientes();
        }

        public string dMantenimientoPaciente(Paciente obj, string accion)
        {
            return objdatos.DMantenimientoPaciente(obj, accion);
        }
       
        public int nValidacionPaciente(Paciente obj)
        {
            return objdatos.nValidacionPaciente(obj);
        }
}
}
