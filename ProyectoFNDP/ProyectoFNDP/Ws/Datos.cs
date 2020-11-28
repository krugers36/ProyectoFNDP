using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFNDP.Ws
{
    class Datos
    {
        public int idpersona { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public  DateTime fechanaci { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string estadop { get; set; }

        public int idficha { get; set; }
        public int idpersonaf { get; set; }
        public string resultado { get; set; }
        public string enfermedad { get; set; }
        public string medicamentos { get; set; }
        public string alergias { get; set; }
        public string antecedentes { get; set; }
        public string estadof { get; set; }

        public int idcatalogo { get; set; }
        public int idhijo { get; set; }
        public string nombrec { get; set; }
        public string valor { get; set; }
        public string estadoc { get; set; }
    }
}
