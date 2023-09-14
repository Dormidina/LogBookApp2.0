using Projekt_Abschluss.Models;
using System;
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
                SqlConnection connectionString = new SqlConnection(@"Data Source=(localdb)\LogBookApp;Initial Catalog=LogBookApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

                connectionString.Open();

                var query = @"SELECT COUNT(*) FROM Users WHERE Name = @Name AND Password = @Password";
                var userCount = connectionString.ExecuteScalar<int>(query, new {user.Name, user.Password});
                return userCount > 0;


            }
            catch (Exception ex) 
            {
                MessageBox.Show("Database error" + ex);
                return false;
            }
        }
    } 


}
