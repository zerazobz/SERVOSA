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
        public VehicleVariableDataServiceModel()
        {
            ColumnsCollection = new List<ColumnDataModel>();
        }

        public string TableName { get; set; }
        public int ObjectId { get; set; }
        //public string ColumnName { get; set; }
        //public int ColumnId { get; set; }
        //public string TableValue { get; set; }
        //public string ColumnType { get; set; }

        public List<ColumnDataModel> ColumnsCollection { get; set; }

        public static void ToServiceModel(IList<VehicleVariableTableDataModel> dataModel, ref VehicleVariableDataServiceModel serviceModel)
        {
            if (dataModel != null && dataModel.Count > 0)
            {
                serviceModel = new VehicleVariableDataServiceModel();
                serviceModel.TableName = dataModel.First().TableName;
                serviceModel.ObjectId = dataModel.First().ObjectId;
                serviceModel.ColumnsCollection = dataModel.Select(e => new ColumnDataModel()
                {
                    ColumnId = e.ColumnId,
                    ColumnName = e.ColumnName,
                    ColumnType = e.ColumnType,
                    TableValue = e.TableValue
                }).ToList();
                //serviceModel = new VehicleVariableDataServiceModel()
                //{
                //    ColumnId = e.ColumnId,
                //    ColumnName = e.ColumnName,
                //    ColumnType = e.ColumnType,
                //    ObjectId = e.ObjectId,
                //    TableName = e.TableName,
                //    TableValue = e.TableValue
                //};
            }
            else
                serviceModel = null;
        }

        public static void ToDataModel(VehicleVariableDataServiceModel serviceModel, ref VehicleVariableTableDataModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new VehicleVariableTableDataModel()
                {
                    //ColumnId = serviceModel.ColumnId,
                    //ColumnName = serviceModel.ColumnName,
                    //ColumnType = serviceModel.ColumnType,
                    ObjectId = serviceModel.ObjectId,
                    TableName = serviceModel.TableName
                    //,
                    //TableValue = serviceModel.TableValue
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
    }
}
