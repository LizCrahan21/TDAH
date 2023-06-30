using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    public class CursosModels
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id_curso { get; set; }
        public string Materia { get; set; }
        public string Promedio { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey(typeof(UsuariosModels))]
        public int? Id_usuario { get; set; }

    }
}
