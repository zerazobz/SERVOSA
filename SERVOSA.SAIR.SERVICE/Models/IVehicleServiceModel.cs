namespace SERVOSA.SAIR.SERVICE.Models
{
    public interface IVehicleServiceModel
    {
        int Codigo { get; set; }
        int CodigoEstado { get; set; }
        int CodigoMarca { get; set; }
        int Item { get; set; }
        string Marca { get; set; }
        string PlacaTolva { get; set; }
        string PlacaTracto { get; set; }
        int RowNumber { get; set; }
        int TotalRows { get; set; }
    }
}