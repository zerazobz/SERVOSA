using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class VehicleFileService : IVehicleFileService
    {
        private IDriverVehicleFilesRepository _vehicleFileRepository;

        public VehicleFileService(IDriverVehicleFilesRepository injectedVehicleRepo)
        {
            _vehicleFileRepository = injectedVehicleRepo;
        }

        public Tuple<bool, int, string> DeleteVehicleFile(VehicleFileServiceModel model)
        {
            bool resultExecution;
            string messageResult;
            DriverFileModel modelToDelete = null;
            VehicleFileServiceModel.ToDataModel(model, ref modelToDelete);
            var rowsAffected = _vehicleFileRepository.DeleteVehicle(modelToDelete);
            if(rowsAffected > 0)
            {
                resultExecution = true;
                messageResult = "Se elimino correctamente el Archivo";
            }
            else
            {
                resultExecution = false;
                messageResult = "No se pudo eliminar el Archivo";
            }
            return new Tuple<bool, int, string>(resultExecution, rowsAffected, messageResult);
        }

        public IList<VehicleFileServiceModel> GetFilesByTableNameAndVehicleId(string tableName, int vehicleId)
        {
            VehicleFileServiceModel modelForList = null;
            var filesCollection = _vehicleFileRepository.GetListVehicles(tableName, vehicleId).Select(fI =>
            {
                VehicleFileServiceModel.ToServiceModel(fI, ref modelForList);
                return modelForList;
            }).ToList();
            return filesCollection;
        }

        public Tuple<bool, int, string> InsertVehicleFile(VehicleFileServiceModel model)
        {
            bool resultExecution;
            string messageResult;
            DriverFileModel modelToInsert = null;
            VehicleFileServiceModel.ToDataModel(model, ref modelToInsert);
            var rowsAffected = _vehicleFileRepository.InsertVehicle(modelToInsert);
            if(rowsAffected > 0)
            {
                resultExecution = true;
                messageResult = "Se inserto correctamente el vehiculo.";
            }
            else
            {
                resultExecution = false;
                messageResult = "No se pudo insertar el vehiculo.";

            }
            return new Tuple<bool, int, string>(resultExecution, rowsAffected, messageResult);
        }
    }
}
