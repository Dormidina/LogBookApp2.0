using Dapper;
using Microsoft.Data.SqlClient;
using Projekt_Abschluss.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Abschluss.Repositories
{
    class ClientRepository
    {
        private readonly string _stringConnection;

        public ClientRepository()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public async Task<List<ClientModel>> GetAllAsync()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"  SELECT Name, Last_Name AS LastName, Adresse, Telephone, Zip_Code AS ZipCode FROM Clients";
                var projects = await connection.QueryAsync<ClientModel>(query);
                return projects.ToList();

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateAsync(ClientModel clientModel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"INSERT INTO Clients (Name, Last_Name, Adresse, Telephone, Zip_Code) VALUES (@Name, @LastName, @Adresse, @Telephone, @ZipCode)";
                var userCount = await connection.ExecuteScalarAsync<int>(query, new { clientModel.Name, clientModel.LastName, clientModel.Adresse, clientModel.Telephone, clientModel.ZipCode });
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
