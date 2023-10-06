using Projekt_Abschluss.Models;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace Projekt_Abschluss.Repositories
{
    public class UserRepository
    {
        private readonly string _stringConnection;
        public UserRepository()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public async Task<bool> LogInAsync(UserLogInModel user)
        {
            try
            {                
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password";
                var userCount = await connection.ExecuteScalarAsync<int>(query, new {user.Name, user.Password});
                return userCount > 0;               

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> ExistsAsync(string userName)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT COUNT(*) FROM Users WHERE Name = @Name";
                var userCount = await connection.ExecuteScalarAsync<int>(query, new { Name = userName });
                return userCount > 0;

            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> CreateAsync(UserCreateUpdateModel user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"INSERT INTO Users (Name, Password) VALUES(@Name, @Password)";
                var affectedRows = await connection.ExecuteAsync(query, new { user.Name, user.Password });
                return affectedRows > 0;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<List<UserDataGridModel>> GetAllAsync()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT Name, IsAdmin FROM Users";
                var users = await connection.QueryAsync<UserDataGridModel>(query);
                return users.ToList();

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UserCreateUpdateModel user)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"UPDATE Users SET IsAdmin = @IsAdmin WHERE Name = @Name;";
                var affectedRows = await connection.ExecuteAsync(query, new { user.Name, user.IsAdmin });
                return affectedRows > 0;
            }

            catch

            {
                throw;
            }
        }
    } 
}
