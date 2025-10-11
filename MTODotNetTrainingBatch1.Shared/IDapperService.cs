
namespace MTODotNetTrainingBatch1.Shared
{
    public interface IDapperService
    {
        int Execute(string query, object? param = null);
        List<T> Query<T>(string query, object? param = null);
    }
}