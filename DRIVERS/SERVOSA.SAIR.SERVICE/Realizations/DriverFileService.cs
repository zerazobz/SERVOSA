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
    public class DriverFileService : IDriverFileService
    {
        private IDriverFilesRepository _vehicleFileRepository;

        public DriverFileService(IDriverFilesRepository injectedVehicleRepo)
        {
            _vehicleFileRepository = injectedVehicleRepo;
        }

        public Tuple<bool, int, string> DeleteVehicleFile(DriverFileServiceModel model)
        {
            bool resultExecution;
            string messageResult;
            DriverFileModel modelToDelete = null;
            DriverFileServiceModel.ToDataModel(model, ref modelToDelete);
            var rowsAffected = _vehicleFileRepository.DeleteDriver(modelToDelete);
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

        public IList<DriverFileServiceModel> GetFilesByTableNameAndVehicleId(string tableName, int vehicleId)
        {
            DriverFileServiceModel modelForList = null;
            var filesCollection = _vehicleFileRepository.GetListDrivers(tableName, vehicleId).Select(fI =>
            {
                DriverFileServiceModel.ToServiceModel(fI, ref modelForList);
                return modelForList;
            }).ToList();
            return filesCollection;
        }

        public Tuple<bool, int, string> InsertVehicleFile(DriverFileServiceModel model)
        {
            bool resultExecution;
            string messageResult;
            DriverFileModel modelToInsert = null;
            DriverFileServiceModel.ToDataModel(model, ref modelToInsert);
            var rowsAffected = _vehicleFileRepository.InsertDriver(modelToInsert);
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
