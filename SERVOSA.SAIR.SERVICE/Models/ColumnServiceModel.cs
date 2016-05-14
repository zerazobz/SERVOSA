using SERVOSA.SAIR.DATAACCESS.Models.DB;
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
    public class ColumnServiceModel : MessageViewModel
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

        public static void ToViewModel(ColumnModel model, ref ColumnServiceModel viewModelResult)
        {
            if (model != null)
                viewModelResult = new ColumnServiceModel()
                {
                    ColumnName = model.ColumnName,
                    CodigoTipoSeleccionado = GetTypeValue(model.DataType),
                    ColumnNormalizedName = model.NormalizedColumnaName,
                    TableNormalizedName = model.NormalizedTableName
                };
            else
                viewModelResult = null;
        }

        public static void ToModel(ColumnServiceModel viewModel, ref ColumnModel modelResult)
        {
            if (viewModel != null)
                modelResult = new ColumnModel()
                {
                    ColumnName = viewModel.ColumnName,
                    NormalizedTableName = viewModel.TableNormalizedName,
                    DataType = GetTypeDescription(viewModel.CodigoTipoSeleccionado)
                };
            else
                modelResult = null;
        }

        private static string GetTypeDescription(int codeValue)
        {
            var typeDescription = String.Empty;

            switch (codeValue)
            {
                case 1:
                    typeDescription = " int";
                    break;
                case 2:
                    typeDescription = " nvarchar(240)";
                    break;
                case 3:
                    typeDescription = " datetime";
                    break;
                default:
                    typeDescription = " nvarchar(120)";
                    break;
            }

            return typeDescription;
        }

        private static int GetTypeValue(string codeDescription)
        {
            int valueReturn = 0;
            switch (codeDescription)
            {
                case "int":
                    valueReturn = 1;
                    break;
                case "nvarchar(80)":
                    valueReturn = 2;
                    break;
                case "datetime":
                    valueReturn = 3;
                    break;
                default:
                    valueReturn = 1;
                    break;
            }
            return valueReturn;
        }
    }
}
