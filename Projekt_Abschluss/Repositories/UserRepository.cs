using Projekt_Abschluss.Models;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Projekt_Abschluss.Repositories
{
    public class UserRepository
    {
        public async Task<bool> UserExistsAsync(UserModel user)
        {
            try
            {
                string stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(stringConnection);

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
    } 


}
