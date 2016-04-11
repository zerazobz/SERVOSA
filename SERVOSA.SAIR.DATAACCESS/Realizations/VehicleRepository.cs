using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class VehicleRepository : IVehicleRepository
    {
        private Database _servosaDB;

        public VehicleRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }

        public int Create(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.PlacaTracto, entity.PlacaTolva, entity.CodigoMarca, entity.CodigoEstado, null };
            using (var insertCommand = _servosaDB.GetStoredProcCommand("SAIR_VEHII", parameters))
            {
                var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                var vehicleCode = Convert.ToInt32(_servosaDB.GetParameterValue(insertCommand, "Codigo"));
                entity.Codigo = vehicleCode;
                return resultExecution;
            }
        }

        public int Delete(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.Codigo };
            var resultExecution = _servosaDB.ExecuteNonQuery("SAIR_VEHID", parameters);
            return resultExecution;
        }

        public IList<VehicleModel> GetAll()
        {
            object[] parameters = new object[] { };
            IRowMapper<VehicleModel> vehicleRowMapper = GetMapperSimple();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public IList<VehicleModel> GetAllFiltered(int minRow, int maxRow)
        {
            object[] parameters = new object[] { minRow, maxRow };
            IRowMapper<VehicleModel> vehicleRowMapper = MapBuilder<VehicleModel>.MapAllProperties().DoNotMap(prop => prop.Marca).Build();
            var vehicleCollection = _servosaDB.ExecuteSprocAccessor("SAIR_VEHIS_Filtrado", vehicleRowMapper, parameters);
            return vehicleCollection.ToList();
        }

        public VehicleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(VehicleModel entity)
        {
            object[] parameters = new object[] { entity.Codigo, entity.PlacaTracto, entity.PlacaTolva, entity.CodigoMarca, entity.CodigoEstado };
            using (var updateCommand = _servosaDB.GetStoredProcCommand("SAIR_VEHIU", parameters))
            {
                var executionResult = _servosaDB.ExecuteNonQuery(updateCommand);
                return executionResult;
            }
        }

        private IRowMapper<VehicleModel> GetMapperSimple()
        {
            return MapBuilder<VehicleModel>.MapAllProperties().DoNotMap(prop => prop.RowNumber)
                .DoNotMap(prop => prop.TotalRows).DoNotMap(prop => prop.Marca).Build();
        }
    }
}
