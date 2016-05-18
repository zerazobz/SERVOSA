namespace SERVOSA.SAIR.SERVICE.Models
{
    public interface IVehicleServiceModel
    {
        int Codigo { get; set; }
        string TablaEstado { get; set; }
        string CodigoEstado { get; set; }
        string EstadoConcatenado { get; set; }
        string TablaMarca { get; set; }
        string MarcaConcatenada { get; set; }
        string CodigoMarca { get; set; }
        int Item { get; set; }
        string Marca { get; set; }
        string PlacaTolva { get; set; }
        string PlacaTracto { get; set; }
        int RowNumber { get; set; }
        int TotalRows { get; set; }
    }
}