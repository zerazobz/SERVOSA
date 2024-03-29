﻿using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models.Driver
{
    public class OldDriverRelatedTableServiceModel : VehicleRelatedTableServiceModel
    {
        public static void ToDataModel(OldDriverRelatedTableServiceModel serviceModel, ref RelatedTableToEntityModel dataModel)
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

        public static void ToServiceModel(RelatedTableToEntityModel dataModel, ref OldDriverRelatedTableServiceModel serviceModel)
        {
            if (dataModel != null)
                serviceModel = new OldDriverRelatedTableServiceModel()
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
