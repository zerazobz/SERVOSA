using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.Vehicle
{
    public class VehicleRelatedTableServiceModel
    {
        public string ForeignKeyName { get; set; }
        public string ForeignTable { get; set; }
        public string ForeignColumn { get; set; }
        public string ParentTable { get; set; }
        public string ParentColumn { get; set; }

        public static void ToDataModel(VehicleRelatedTableServiceModel serviceModel, ref RelatedTableToEntityModel dataModel)
        {
            if (serviceModel != null)
                dataModel = new RelatedTableToEntityModel()
                {
                    foreign_column = serviceModel.ForeignColumn,
                    foreign_key_name = serviceModel.ForeignKeyName,
                    foreign_table = serviceModel.ForeignTable,
                    parent_column = serviceModel.ParentColumn,
                    parent_table = serviceModel.ParentTable
                };
            else
                dataModel = null;
        }

        public static void ToServiceModel(RelatedTableToEntityModel dataModel, ref VehicleRelatedTableServiceModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new VehicleRelatedTableServiceModel()
                {
                    ForeignColumn = dataModel.foreign_column,
                    ForeignKeyName = dataModel.foreign_key_name,
                    ForeignTable = dataModel.foreign_table,
                    ParentColumn = dataModel.parent_column,
                    ParentTable = dataModel.parent_table
                };
            else
                serviceModel = null;
        }
    }
}
