namespace Autumn.Wasm.Interfaces
{
    public interface IDataSourceService
    {
        Task<TModel?> DownloadDataSourceAsync<TModel>(string content);
    }
}
