﻿using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IOldDriverRepository : IRepository<OldDriverModel>
    {
        IList<OldDriverModel> GetAllFiltered(int minRow, int maxRow);
        IList<OldDriverModel> GetRowDataForTable(string tableName);
        IList<RelatedTableToEntityModel> GetRelatedTablesToVehicle();
    }
}
