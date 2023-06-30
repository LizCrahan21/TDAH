using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    public class UsuariosModels
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        public int Telefono { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_n { get; set; }
        [Unique]
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        [ForeignKey(typeof(PreguntasModels))]
        public int? Id_pregunta { get; set; }

        [ForeignKey(typeof(CursosModels))]
        public int? Id_curso { get; set; }

    }
}
