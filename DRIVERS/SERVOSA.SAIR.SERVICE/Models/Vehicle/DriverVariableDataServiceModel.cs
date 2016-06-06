using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class DriverVariableDataServiceModel : MessageViewModel
    {
        public DriverVariableDataServiceModel()
        {
            ColumnsCollection = new List<ColumnDataModel>();
            IsSuccessful = true;
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }

        public List<ColumnDataModel> ColumnsCollection { get; set; }

        public static void ToServiceModel(IList<DriverVariableTableDataModel> dataModel, ref DriverVariableDataServiceModel serviceModel)
        {
            if (dataModel != null && dataModel.Count > 0)
            {
                serviceModel = new DriverVariableDataServiceModel();
                serviceModel.TableName = dataModel.First().TableName;
                serviceModel.ObjectId = dataModel.First().ObjectId;
                serviceModel.ColumnsCollection = dataModel.Select(e =>
                {
                    var columnData = new ColumnDataModel()
                    {
                        ColumnId = e.ColumnId,
                        ColumnName = e.ColumnName,
                        ColumnType = e.ColumnType,
                        TableValue = e.TableValue
                    };
                    switch (e.ColumnType)
                    {
                        case "int":
                            columnData.ColumnNamedType = SERVOSASqlTypes.Int;
                            break;
                        case "decimal":
                            columnData.ColumnNamedType = SERVOSASqlTypes.Decimal;
                            break;
                        case "nvarchar":
                            columnData.ColumnNamedType = SERVOSASqlTypes.NVarChar;
                            break;
                        case "datetime":
                            columnData.ColumnNamedType = SERVOSASqlTypes.DateTime;
                            break;
                        default:
                            columnData.ColumnNamedType = SERVOSASqlTypes.NVarChar;
                            break;
                    }
                    return columnData;
                }).ToList();
            }
            else
                serviceModel = null;
        }

        public static void ToDataModel(DriverVariableDataServiceModel serviceModel, ref DriverVariableTableDataModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new DriverVariableTableDataModel()
                {
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName
                };
            else
                dataModel = null;
        }
    }

    public class ColumnDataModel
    {
        public string ColumnName { get; set; }
        public int ColumnId { get; set; }
        public string TableValue { get; set; }
        public string ColumnType { get; set; }
        public object ColumnValue { get; set; }
        public SERVOSASqlTypes ColumnNamedType { get; set; }
    }
}
