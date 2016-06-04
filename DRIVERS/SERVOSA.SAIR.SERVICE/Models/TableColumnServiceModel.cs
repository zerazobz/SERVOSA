using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class TableColumnServiceModel : MessageViewModel
    {
        public int TableId { get; set; }
        public string TableNormalizedName { get; set; }
        public string TableName { get; set; }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }
        public string ColumnNormalizedName { get; set; }
        public string ColumnName { get; set; }
        public int UserType { get; set; }
        public int SystemType { get; set; }
        public string TypeName { get; set; }

        public static void ToServiceModel(TableColumnModel model, ref TableColumnServiceModel viewModel)
        {
            if (model != null)
                viewModel = new TableColumnServiceModel()
                {
                    ColumnName = model.ColumnName,
                    ColumnNormalizedName = model.ColumnNormalizedName,
                    SchemaId = model.SchemaId,
                    SchemaName = model.SchemaName,
                    SystemType = model.SystemType,
                    TableId = model.TableObjectId,
                    TableNormalizedName = model.TableNormalizedName,
                    TableName = model.TableName
                };
            else
                viewModel = null;
        }

        public static void ToDataModel(TableColumnServiceModel viewModel, ref TableColumnModel model)
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
                    UserType = viewModel.UserType,
                    TableName = viewModel.TableName
                };
            else
                model = null;
        }
    }
}
