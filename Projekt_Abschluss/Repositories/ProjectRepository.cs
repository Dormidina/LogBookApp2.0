using Dapper;
using Microsoft.Data.SqlClient;
using Projekt_Abschluss.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_Abschluss.Repositories
{
    public class ProjectRepository
    {
        private readonly string _stringConnection;
        public ProjectRepository()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;            
        }
        public async Task<bool> CreateAsync(ProjectModel projectModel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"INSERT INTO Projects (Name, Description, Company_ID) VALUES (@Name, @Description, @Company)";
                var userCount = await connection.ExecuteScalarAsync<int>(query, new { projectModel.Name, projectModel.Description, projectModel.Company });
                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ProjectModel>> GetAllAsync()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT * FROM Projects";
                var projects = await connection.QueryAsync<ProjectModel>(query);
                return projects.ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
