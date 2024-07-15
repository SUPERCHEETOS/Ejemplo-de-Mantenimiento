using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidades;
using System.Data;

namespace Capa_Entidades
{
    public class Paciente
    {
        public string DNI { get; set; }
        public string Nombre_Completo { get; set; }
        public int Fecha_de_nacimiento { get; set; }
        public string Sexo { get; set; }
        public string Numero_de_celular { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }

    }
}
