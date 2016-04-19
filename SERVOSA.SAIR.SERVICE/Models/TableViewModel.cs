using SERVOSA.SAIR.DATAACCESS.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class TableViewModel
    {
        public string TableName { get; set; }
        public string TableNormalizedName { get; set; }

        public static void ToViewModel(TableModel model, ref TableViewModel viewModel)
        {
            if (model != null)
                viewModel = new TableViewModel()
                {
                    TableName = model.TableName,
                    TableNormalizedName = model.TableNormalizedName
                };
            else
                viewModel = null;
        }

        public static void ToModel(TableViewModel viewModel, ref TableModel model)
        {
            if (viewModel != null)
                model = new TableModel()
                {
                    TableName = viewModel.TableName,
                    TableNormalizedName = viewModel.TableNormalizedName
                };
            else
                model = null;
        }
    }
}
