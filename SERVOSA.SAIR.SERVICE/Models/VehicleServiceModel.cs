using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class VehicleServiceModel
    {
        public int Item { get; set; }
        public int Codigo { get; set; }
        public string PlacaTracto { get; set; }
        public string PlacaTolva { get; set; }
        public int CodigoMarca { get; set; }
        public string Marca { get; set; }
        public int CodigoEstado { get; set; }

        public int RowNumber { get; set; }
        public int TotalRows { get; set; }

        public static void ToViewModel(VehicleModel model, ref VehicleServiceModel viewModel)
        {
            if (model != null)
                viewModel = new VehicleServiceModel()
                {
                    Codigo = model.Codigo,
                    CodigoEstado = model.CodigoEstado,
                    CodigoMarca = model.CodigoMarca,
                    Item = model.Item,
                    Marca = model.Marca,
                    PlacaTolva = model.PlacaTolva,
                    PlacaTracto = model.PlacaTracto,
                    RowNumber = model.RowNumber,
                    TotalRows = model.TotalRows
                };
            else
                viewModel = null;
        }

        public static void ToModel(VehicleServiceModel viewModel, ref VehicleModel model)
        {
            if (viewModel != null)
                model = new VehicleModel()
                {
                    Codigo = viewModel.Codigo,
                    CodigoEstado = viewModel.CodigoEstado,
                    CodigoMarca = viewModel.CodigoMarca,
                    Item = viewModel.Item,
                    Marca = viewModel.Marca,
                    PlacaTolva = viewModel.PlacaTolva,
                    PlacaTracto = viewModel.PlacaTracto,
                    RowNumber = viewModel.RowNumber,
                    TotalRows = viewModel.TotalRows
                };
            else
                model = null;
        }
    }
}
