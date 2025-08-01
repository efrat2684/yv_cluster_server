﻿using Data.Models;
using Data.Repositories.Interfaces;
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

        public ClusterGroupWithCrmLinks GetClusterGroupDetails(int groupId)
        {

            return _repository.GetClusterGroupDetails(groupId);
        }
        public StatisticData GetStatisticData()
        {
            return _repository.GetStatisticData();
        }


        public BookIdDetails AddBookId(string bookId)
        {
            return _repository.AddBookId(bookId);
        }

        public List<BookIdDetails> AddBookIdsByClusterId(string clusterId)
        {
            return _repository.AddBookIdsByClusterId(clusterId);
        }

        public void AddNewBookIdToExistCluster(NewClusterFromSystem newClusterFromSystem)
        {
            _repository.AddNewBookIdToExistCluster(newClusterFromSystem);
        }
        public List<BookIdDetails> GetCreateClusterData(List<string> bookIds)
        {
            return _repository.GetCreateClusterData(bookIds);
        }

        public string CreateNewCluster(List<string> bookIds)
        {
            return _repository.CreateNewCluster(bookIds);
        }
    }
}
