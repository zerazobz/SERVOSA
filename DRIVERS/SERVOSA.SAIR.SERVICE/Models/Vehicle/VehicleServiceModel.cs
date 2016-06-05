using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public class VehicleServiceModel : IVehicleServiceModel
    {
        public VehicleServiceModel()
        {
            TablaMarca = "BRND";
            TablaEstado = "VSTA";
        }

        public int Item { get; set; }
        [Display(Name = "Cod.")]
        public int Codigo { get; set; }
        [Display(Name = "Remove")]
        public string Marca { get; set; }
        [Display(Name = "Remove")]
        public string Estado { get; set; }

        public int RowNumber { get; set; }
        public int TotalRows { get; set; }

        public string TablaMarca { get; set; }
        public string CodigoMarca { get; set; }
        public string MarcaConcatenada { get; set; }
        public string TablaEstado { get; set; }
        public string CodigoEstado { get; set; }
        public string EstadoConcatenado { get; set; }
        public string CodigoTipoUnidad { get; set; }
        [Display(Name = "Remove")]
        public string DescripcionTipoUnidad { get; set; }
        [Display(Name = "Nombres y Apellidos")]
        public string Placa { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        //[DisplayFormat(DataFormatString = "{0:dd/mm/yyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        public static void ToViewModel(VehicleModel model, ref VehicleServiceModel viewModel)
        {
            if (model != null)
                viewModel = new VehicleServiceModel()
                {
                    Codigo = model.Codigo,
                    TablaEstado = model.TYPE_cTABVSTA,
                    CodigoEstado = model.TYPE_cCODVSTA,
                    EstadoConcatenado = String.Format("{0}|@|{1}", model.TYPE_cTABVSTA, model.TYPE_cCODVSTA),
                    TablaMarca = model.TYPE_cTABBRND,
                    CodigoMarca = model.TYPE_cCODBRND,
                    MarcaConcatenada = String.Format("{0}|@|{1}", model.TYPE_cTABBRND, model.TYPE_cCODBRND),
                    Item = model.Item,
                    Marca = model.Marca,
                    Estado = model.Estado,
                    Placa = model.VEHI_VehiclePlate,
                    CodigoTipoUnidad = model.VEHI_UnitType,
                    //DescripcionTipoUnidad = model.VEHI_UnitType == "R"? "Remolque" : "Semiremolque",
                    DescripcionTipoUnidad = model.VEHI_DescriptionUnitType,
                    RowNumber = model.RowNumber,
                    TotalRows = model.TotalRows,
                    BirthDate = model.DRIV_dBirthDate,
                    Address = model.DRIV_cAddress
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
                    //TYPE_cTABVSTA = viewModel.EstadoConcatenado.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(),
                    //TYPE_cCODVSTA = viewModel.EstadoConcatenado.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault(),
                    //TYPE_cTABBRND = viewModel.MarcaConcatenada.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(),
                    //TYPE_cCODBRND = viewModel.MarcaConcatenada.Split(new string[] { "|@|" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault(),
                    Item = viewModel.Item,
                    Marca = viewModel.Marca,
                    Estado = viewModel.Estado,
                    VEHI_VehiclePlate = viewModel.Placa,
                    VEHI_UnitType = viewModel.CodigoTipoUnidad,
                    RowNumber = viewModel.RowNumber,
                    TotalRows = viewModel.TotalRows,
                    DRIV_dBirthDate = viewModel.BirthDate,
                    DRIV_cAddress = viewModel.Address
                };
            else
                model = null;
        }
    }
}
