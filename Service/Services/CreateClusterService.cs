using Data.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateClusterService : ICreateClusterService
    {
        private readonly ICreateClusterRepository _repository;

        public CreateClusterService(ICreateClusterRepository repository)
        {
            _repository = repository;
        }



        public SapirClusterModel GetCreateClusterData()
        {
            return _repository.GetCreateClusterData();
        }

        public SapirClusterModel CreateNewCluster(SapirClusterModel sapirClusterModel)
        {
            return _repository.CreateNewCluster(sapirClusterModel);
        }
    }
}
