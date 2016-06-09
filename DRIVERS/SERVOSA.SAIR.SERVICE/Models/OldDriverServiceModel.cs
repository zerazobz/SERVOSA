using SERVOSA.SAIR.DATAACCESS.Models.OldDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class OldDriverServiceModel
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
        public static void ToViewModel(DriverOldModel model, ref OldDriverServiceModel viewModel)
        {
            if (model != null)
                viewModel = new OldDriverServiceModel()
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

        public static void ToModel(OldDriverServiceModel viewModel, ref DriverOldModel model)
        {
            if (viewModel != null)
                model = new DriverOldModel()
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
