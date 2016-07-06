namespace SERVOSA.SAIR.SERVICE.Models
{
    public interface IDriverTableServiceModel
    {
        int ObjectId { get; set; }
        string TableName { get; set; }
        string TableNormalizedName { get; set; }
    }
}