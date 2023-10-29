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

        public async Task<List<CompanyDataModel>> GetAllDataCompaniesAsync()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT Name, Adresse, Zip_Code, Telephone, Email FROM Companies";
                var companies = await connection.QueryAsync<CompanyDataModel>(query);
                return companies.ToList();

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateCompanyAsync(CompanyDataModel companyDataModel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"INSERT INTO Companies (Name, Adresse, Zip_Code, Telephone, Email) VALUES (@Name, @Adresse, @ZipCode, @Telephone, @Email)";
                var userCount = await connection.ExecuteScalarAsync<int>(query, new { companyDataModel.Name, companyDataModel.Adresse, companyDataModel.ZipCode, companyDataModel.Telephone, companyDataModel.Email });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
