using Projekt_Abschluss.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Projekt_Abschluss.Repositories
{
    public class UserRepository
    {
        public bool UserExists(User user)
        {
            try
            {
                string stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(stringConnection);

                connection.Open();

                var query = @"SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password";
                var userCount = connection.ExecuteScalar<int>(query, new {user.Name, user.Password});
                return userCount > 0;


            }
            catch
            {
                return false;
            }
        }
    } 


}
