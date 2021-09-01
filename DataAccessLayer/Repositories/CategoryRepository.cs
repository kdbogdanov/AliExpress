using Dapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        public CategoryRepository(IConfiguration configuration) =>
            _configuration = configuration;

        public async Task<int> AddAsync(Category entity)
        {
            var sql = "Insert into Category (Name, ParentId) VALUES (@Name, @ParentId)";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Category WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }
        public async Task<IReadOnlyList<Category>> GetAllAsync()
        {
            var sql = "SELECT * FROM Category";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql);
                return result.ToList();
            }
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Category WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Category>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Category>> GetChildsByIdAsync(int id)
        {
            var sql = "WITH RECURSIVE SearchChilds(Id, Name, ParentId) AS " +
                "(" +
                "SELECT cat1.Id, cat1.Name, cat1.ParentId " +
                "FROM Category cat1 " +
                "WHERE cat1.Id = @Id " +
                "UNION ALL " +
                "SELECT cat2.Id, cat2.Name, cat2.ParentId " +
                "FROM Category cat2 " +
                "INNER JOIN SearchChilds on SearchChilds.Id = cat2.ParentId " +
                ")" +
                "SELECT * FROM SearchChilds";

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Category>(sql, new { Id = id });
                return result.ToList();
            }
        }

        public async Task<int> UpdateAsync(Category entity)
        {
            var sql = "UPDATE Category SET Name = @Name, ParentId = @ParentId  WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
