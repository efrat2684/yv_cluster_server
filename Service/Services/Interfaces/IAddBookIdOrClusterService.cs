namespace Service.Services.Interfaces
{
    public interface IAddBookIdOrClusterService
    {
        RootObject AddBookId(string bookId);

        RootObject AddBookIdsByClusterId(string clusterId);

    }
}