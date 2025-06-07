namespace Data.Repositories.Interfaces
{
    public interface ICreateClusterRepository
    {
        SapirClusterModel GetCreateClusterData();

        SapirClusterModel CreateNewCluster(SapirClusterModel sapirClusterModel);
    }
}