using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverDBServices
    {
        Tuple<int, DriverTableServiceModel> CreateTable(DriverTableServiceModel viewModel);
        IList<DriverTableServiceModel> ListAllTables();
        Tuple<int, DriverColumnServiceModel> CreateColumn(DriverColumnServiceModel viewModel);
        IList<DriverTableColumnServiceModel> ListVehicleVarsTablesWithDefinition();
        IList<DriverTableColumnServiceModel> ListDriversVarsTablesWithDefinition();
    }
}
