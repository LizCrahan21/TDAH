using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    public class AdministradorModels
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id_administrador { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        [Unique]
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        [ForeignKey(typeof(UsuariosModels))]
        public int? Id_usuario { get; set; }

        [ForeignKey(typeof(CursosModels))]
        public int? Id_cursos { get; set; }

        [ForeignKey(typeof(TipoPreguntaModels))]
        public int? Id_tipo_pregunta { get; set; }

    }
}
