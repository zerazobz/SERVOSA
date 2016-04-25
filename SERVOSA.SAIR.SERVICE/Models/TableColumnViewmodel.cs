using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class TableColumnViewModel : MessageViewModel
    {
        public int TableId { get; set; }
        public string TableNormalizedName { get; set; }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }
        public string ColumnNormalizedName { get; set; }
        public string ColumnName { get; set; }
        public int UserType { get; set; }
        public int SystemType { get; set; }
        public string TypeName { get; set; }

        public static void ToViewModel(TableColumnModel model, ref TableColumnViewModel viewModel)
        {
            if (model != null)
                viewModel = new TableColumnViewModel()
                {
                    ColumnName = model.ColumnName,
                    ColumnNormalizedName = model.ColumnNormalizedName,
                    SchemaId = model.SchemaId,
                    SchemaName = model.SchemaName,
                    SystemType = model.SystemType,
                    TableId = model.TableObjectId
                };
            else
                viewModel = null;
        }

        public static void ToModel(TableColumnViewModel viewModel, ref TableColumnModel model)
        {
            if (viewModel != null)
                model = new TableColumnModel()
                {
                    ColumnName = viewModel.ColumnName,
                    ColumnNormalizedName = viewModel.ColumnNormalizedName,
                    SchemaId = viewModel.SchemaId,
                    SchemaName = viewModel.SchemaName,
                    SystemType = viewModel.SystemType,
                    TableNormalizedName = viewModel.TableNormalizedName,
                    TableObjectId = viewModel.TableId,
                    TypeName = viewModel.TypeName,
                    UserType = viewModel.UserType
                };
            else
                model = null;
        }
    }
}
