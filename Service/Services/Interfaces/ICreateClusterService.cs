namespace Service.Services.Interfaces
{
    public interface ICreateClusterService
    {
        SapirClusterModel GetCreateClusterData();

        SapirClusterModel CreateNewCluster(SapirClusterModel sapirClusterModel);
    }
}