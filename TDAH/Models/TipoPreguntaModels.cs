using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Models
{
    public class TipoPreguntaModels
    {

        [PrimaryKey, AutoIncrement, Unique]
        public int Id_tipo_pregunta { get; set; }
        public string Abierta { get; set; }
        public string Cerrada { get; set; }
        public string Multiple { get; set; }

    }
}
