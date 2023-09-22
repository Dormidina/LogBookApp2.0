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
    internal class CompanyRepository
    {
        private readonly string _stringConnection;
        public CompanyRepository()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public async Task<List<CompanyModel>> GetAllCompaniesAsync()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT Company_ID, Name FROM Companies";
                var companies = await connection.QueryAsync<CompanyModel>(query);
                return companies.ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
