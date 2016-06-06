using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.TableData
{
    public class DriverFiles : MessageViewModel, IDriverTableServiceModel, IVehicleServiceModel
    {
        #region DatosVehiculo

        public int Codigo { get; set; }
        public string TablaMarca { get; set; }
        public string CodigoMarca { get; set; }
        public string MarcaConcatenada { get; set; }
        public string Marca { get; set; }
        public string TablaEstado { get; set; }
        public string CodigoEstado { get; set; }
        public string EstadoConcatenado { get; set; }
        public int Item { get; set; }
        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
        public string CodigoTipoUnidad { get; set; }
        public string DescripcionTipoUnidad { get; set; }
        public string Placa { get; set; }

        #endregion

        #region DatosVariable

        [Display(Name = "Nombre de Variable")]
        public string TableName { get; set; }
        public string TableNormalizedName { get; set; }
        public int ObjectId { get; set; }

        #endregion
    }
}
