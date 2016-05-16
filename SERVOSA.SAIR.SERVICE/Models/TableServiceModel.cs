using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class TableServiceModel : MessageViewModel, ITableServiceModel
    {
        public int ObjectId { get; set; }
        [Display(Name = "Nombre de la Variable")]
        public string TableName { get; set; }
        [Display(Name = "Nombre Minificado")]
        public string TableNormalizedName { get; set; }

        public static void ToViewModel(TableModel model, ref ITableServiceModel viewModel)
        {
            if (model != null)
                viewModel = new TableServiceModel()
                {
                    TableName = model.TableName,
                    TableNormalizedName = model.TableNormalizedName,
                    ObjectId = model.ObjectId
                };
            else
                viewModel = null;
        }

        public static void ToModel(ITableServiceModel viewModel, ref TableModel model)
        {
            if (viewModel != null)
                model = new TableModel()
                {
                    TableName = viewModel.TableName,
                    TableNormalizedName = viewModel.TableNormalizedName,
                    ObjectId = viewModel.ObjectId
                };
            else
                model = null;
        }
    }
}
