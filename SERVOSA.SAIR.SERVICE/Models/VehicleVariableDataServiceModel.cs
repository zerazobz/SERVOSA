using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class VehicleVariableDataServiceModel
    {
        public string TableName { get; set; }
        public int ObjectId { get; set; }
        public string ColumnName { get; set; }
        public int ColumnId { get; set; }
        public string TableValue { get; set; }
        public string ColumnType { get; set; }

        public static void ToServiceModel(VehicleVariableTableDataModel dataModel, ref VehicleVariableDataServiceModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new VehicleVariableDataServiceModel()
                {
                    ColumnId = dataModel.ColumnId,
                    ColumnName = dataModel.ColumnName,
                    ColumnType = dataModel.ColumnType,
                    ObjectId = dataModel.ObjectId,
                    TableName = dataModel.TableName,
                    TableValue = dataModel.TableValue
                };
            else
                serviceModel = null;
        }

        public static void ToDataModel(VehicleVariableDataServiceModel serviceModel, ref VehicleVariableTableDataModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new VehicleVariableTableDataModel()
                {
                    ColumnId = serviceModel.ColumnId,
                    ColumnName = serviceModel.ColumnName,
                    ColumnType = serviceModel.ColumnType,
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName,
                    TableValue = serviceModel.TableValue
                };
            else
                dataModel = null;
        }
    }
}
