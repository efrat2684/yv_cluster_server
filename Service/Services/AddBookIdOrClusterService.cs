﻿using Data.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AddBookIdOrClusterService : IAddBookIdOrClusterService
    {
        private readonly IAddBookIdOrClusterRepository _repository;

        public AddBookIdOrClusterService(IAddBookIdOrClusterRepository repository)
        {
            _repository = repository;
        }

        public RootObject AddBookId(string bookId)
        {
            return _repository.AddBookId(bookId);
        }

        public RootObject AddBookIdsByClusterId(string clusterId)
        {
            return _repository.AddBookIdsByClusterId(clusterId);
        }
    }
}
