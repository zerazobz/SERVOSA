using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class DriverServiceModel
    {
        public int CodigoOperario { get; set; }
        public string NombreOperario { get; set; }
        public string ApellidoPaternoOperario { get; set; }
        public string ApellidoMaternoOperario { get; set; }
        public string CorreoOperario { get; set; }
        public int CodigoVehiculo { get; set; }
        public string DescripcionVehiculo { get; set; }
        public int CodigoPuesto { get; set; }
        public int RowNumber { get; set; }
        public int TotalRows { get; set; }
        public int RowsAffected { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public static void ToViewModel(DriverModel model, ref DriverServiceModel viewModel)
        {
            if (model != null)
                viewModel = new DriverServiceModel()
                {
                    CodigoOperario = model.OPER_Id,
                    ApellidoPaternoOperario = model.OPER_cApellidoPaterno,
                    ApellidoMaternoOperario = model.OPER_cApellidoPaterno,
                    NombreOperario = model.OPER_cNombre,
                    CorreoOperario = model.OPER_cCorreo,
                    CodigoVehiculo = model.VEHI_Id,
                    CodigoPuesto = model.PUES_Id,
                    RowNumber = model.RowNumber,
                    TotalRows = model.TotalRows,
                    DescripcionVehiculo=model.VEHI_cDescripcion
                };
            else
                viewModel = null;
        }

        public static void ToModel(DriverServiceModel viewModel, ref DriverModel model)
        {
            if (viewModel != null)
                model = new DriverModel()
                {
                    OPER_Id = viewModel.CodigoOperario,
                    OPER_cApellidoPaterno = viewModel.ApellidoPaternoOperario,
                    OPER_cApellidoMaterno = viewModel.ApellidoMaternoOperario,
                    OPER_cNombre = viewModel.NombreOperario,
                    OPER_cCorreo = viewModel.CorreoOperario,
                    VEHI_Id = viewModel.CodigoVehiculo,
                    PUES_Id = viewModel.CodigoPuesto,
                    RowNumber = viewModel.RowNumber,
                    TotalRows = viewModel.TotalRows
                };
            else
                model = null;
        }
    }
}
