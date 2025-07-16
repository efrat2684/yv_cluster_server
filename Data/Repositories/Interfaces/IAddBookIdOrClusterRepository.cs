namespace Data.Repositories.Interfaces
{
    public interface IAddBookIdOrClusterRepository
    {
        RootObject AddBookId(string bookId);

        RootObject AddBookIdsByClusterId(string clusterId);
    }
}