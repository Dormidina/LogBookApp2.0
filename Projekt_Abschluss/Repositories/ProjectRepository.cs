using Dapper;
using Microsoft.Data.SqlClient;
using Projekt_Abschluss.Models;
using System.Configuration;
using System.Threading.Tasks;

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
    }
}
