using Data.Models.DTO;
using Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryBase
    {
        private readonly IConnectionFactory _factory;
        private readonly string _dbKey;

        protected RepositoryBase(IConnectionFactory factory, string dbKey)
        {
            _factory = factory;
            _dbKey = dbKey;
        }

        protected  ChunkResult<T> Query<T>(string sql, Func<IDataReader, T> mapper,
            SqlParameter[] parameters,int chunkNumber,int chunkSize)
        {
            using var conn = _factory.Create(_dbKey);
            using var cmd = new SqlCommand(sql, (SqlConnection)conn);

            cmd.Parameters.AddRange(parameters);

            using var reader =  cmd.ExecuteReader();
            var list = new List<T>();

            while ( reader.Read()) list.Add(mapper(reader));

            reader.NextResult();
            int total = reader.Read() ? reader.GetInt32(0) : 0;

            return new ChunkResult<T>
            {
                Items = list,
                TotalCount = total,
                Chunk = chunkNumber,
                ChunkSize = chunkSize
            };
        }

        public  int ExecuteAsync(string sql, SqlParameter[]? param = null)
        {
            using var conn = _factory.Create(_dbKey);
            using var cmd = new SqlCommand(sql, (SqlConnection)conn);
            if (param is not null) cmd.Parameters.AddRange(param);
            return  cmd.ExecuteNonQuery();
        }
    }
}
