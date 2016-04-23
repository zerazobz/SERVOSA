﻿using SERVOSA.SAIR.DATAACCESS.Models.DB;
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

        [Display(Name = "Nombre de la Tabla")]
        public string TableName { get; set; }
        public string TableNormalizedName { get; set; }
        [Required]
        public int CodigoTipoSeleccionado { get; set; }

        public SelectList ListaTipos { get; set; }

        public static void ToViewModel(ColumnModel model, ref ColumnViewModel viewModelResult)
        {
            if (model != null)
                viewModelResult = new ColumnViewModel()
                {
                    CodigoTipoSeleccionado = viewModelResult.CodigoTipoSeleccionado,
                    ColumnName = viewModelResult.ColumnName,
                    ColumnNormalizedName = viewModelResult.ColumnNormalizedName,
                    TableName = viewModelResult.TableName,
                    TableNormalizedName = viewModelResult.TableNormalizedName
                };
            else
                viewModelResult = null;
        }

        public static void ToModel(ColumnViewModel viewModel, ref ColumnModel modelResult)
        {
            if (viewModel != null)
                modelResult = new ColumnModel()
                {
                    ColumnName = viewModel.ColumnName,
                    TableName = viewModel.TableName,
                    DataType = GetTypeDescription(viewModel.CodigoTipoSeleccionado)
                };
            else
                modelResult = null;
        }

        private static string GetTypeDescription(int codeDescription)
        {
            var typeDescription = String.Empty;

            switch (codeDescription)
            {
                case 1:
                    typeDescription = " int";
                    break;
                case 2:
                    typeDescription = " nvarchar(80)";
                    break;
                case 3:
                    typeDescription = " datetime";
                    break;
                default:
                    typeDescription = " nvarchar(40)";
                    break;
            }

            return typeDescription;
        }
    }
}
