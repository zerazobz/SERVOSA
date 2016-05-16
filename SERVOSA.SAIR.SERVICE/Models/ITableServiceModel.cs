namespace SERVOSA.SAIR.SERVICE.Models
{
    public interface ITableServiceModel
    {
        int ObjectId { get; set; }
        string TableName { get; set; }
        string TableNormalizedName { get; set; }
    }
}