﻿using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDBColumnsRepository : IRepository<ColumnModel>
    {
        Tuple<int, ColumnModel> CreateColumnAndReturnNormalizedName(ColumnModel model);
    }
}
