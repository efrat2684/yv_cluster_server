﻿using Data.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Services
{
    public class SystemClusterService: ISystemClusterService
    {
        private readonly ISystemClusterRepository _repository;
        public SystemClusterService(ISystemClusterRepository repository) 
        {

            _repository = repository;
     
}
        public string GetMessageFromService()
        {
            return _repository.GetMessage();
        }

        public RootObjectOfClusterGroupDetails GetClusterGroupDetails()
        {
            return _repository.GetClusterGroupDetails();
        }
        public StatisticData GetStatisticData()
        {
            return _repository.GetStatisticData();
        }
    }
}
