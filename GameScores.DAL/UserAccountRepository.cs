using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GameScores.DAL.Models;
using Microsoft.Extensions.Options;

namespace GameScores.DAL
{
    public interface ISimpleRepo<TEntity, TKey>
    {

        Task<TKey> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(TKey key);
        Task<TEntity> UpdateAsync(TKey key, TEntity entity);
        Task DeleteAsync(TKey key);
    }
    public class UserAccountRepository : BaseRepository, ISimpleRepo<UserAccount, int>
    {
        public UserAccountRepository(IOptions<DatabaseOptions> databaseOptions)
        : base(databaseOptions)
        {

        }

        public async Task<UserAccount> GetUser(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            var output = await connection.QuerySingleOrDefaultAsync<UserAccount>(@"SELECT * FROM UserAccounts WHERE id = @id", new { id });
            return output;           
        }

        public async Task<int> AddUser(UserAccount userAccount)
        {
            using var connection = new SqlConnection(ConnectionString);
            string insertQuery = @"INSERT INTO UserAccounts([FirstName], [LastName], [DateOfBirth], [EmailAddress]) OUTPUT INSERTED.id VALUES (@firstName, @lastName, @dateOfBirth, @emailAddress)";
            return await connection.QuerySingleAsync<int>(insertQuery, userAccount);

        }

        public Task<int> CreateAsync(UserAccount entity) => AddUser(entity);

        public Task<UserAccount> ReadAsync(int key) => GetUser(key);

        public Task<UserAccount> UpdateAsync(int key, UserAccount entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }
    }
}
