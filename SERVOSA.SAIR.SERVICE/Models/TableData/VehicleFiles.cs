﻿using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.TableData
{
    public class VehicleFiles : MessageViewModel, ITableServiceModel, IVehicleServiceModel
    {
        #region DatosVehiculo

        public int Codigo { get; set; }
        public string PlacaTracto { get; set; }
        public string PlacaTolva { get; set; }
        public int CodigoMarca { get; set; }
        public string Marca { get; set; }
        public int CodigoEstado { get; set; }
        public int Item { get; set; }
        public int RowNumber { get; set; }
        public int TotalRows { get; set; }

        #endregion

        #region DatosVariable

        [Display(Name = "Nombre de Variable")]
        public string TableName { get; set; }
        public string TableNormalizedName { get; set; }
        public int ObjectId { get; set; }

        #endregion
    }
}