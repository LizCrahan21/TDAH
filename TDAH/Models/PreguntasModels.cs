using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    public class PreguntasModels
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id_pregunta { get; set; }
        public string Imagen { get; set; }

        [ForeignKey(typeof(TipoPreguntaModels))]
        public int? Id_tipo_pregunta { get; set; }

    }
}
