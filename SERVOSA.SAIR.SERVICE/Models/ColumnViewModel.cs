using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class ColumnViewModel : MessageViewModel
    {
        [Display(Name = "Nombre de la Columna")]
        [Required]
        public string ColumnName { get; set; }
        [Display(Name = "Nombre Minificado de la Columna")]
        public string ColumnNormalizedName { get; set; }

        public string TableName { get; set; }
        public string TableNormalizedName { get; set; }
        [Required]
        public int CodigoTipoSeleccionado { get; set; }

        public SelectList ListaTipos { get; set; }
    }
}
