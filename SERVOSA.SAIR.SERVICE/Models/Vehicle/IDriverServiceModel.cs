using System;

namespace SERVOSA.SAIR.SERVICE.Models
{
    public interface IDriverServiceModel
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
        int RowNumber { get; set; }
        int TotalRows { get; set; }
        string CodigoTipoUnidad { get; set; }
        string DescripcionTipoUnidad { get; set; }
        string Placa { get; set; }
        DateTime? BirthDate { get; set; }
        string Address { get; set; }
    }
}