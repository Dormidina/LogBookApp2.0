﻿using Dapper;
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
    public class TaskRepository
    {
        private readonly string _stringConnection;
        public TaskRepository()
        {
            _stringConnection = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }
        public async Task<List<TaskModel>> GetAllTaskAsync(int projectID)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_stringConnection);
                connection.Open();

                var query = @"SELECT Task_ID AS TaskID, 
                            Name, Description, Estimated_Time AS EstimatedTime, Real_Time AS RealTime, 
                            Priority, Date_Start AS DateStart, Date_End AS DateEnd , UserName, Status FROM Tasks WHERE Project_ID = @projectID";

                var tasks = await connection.QueryAsync<TaskModel>(query, new { projectID });
                return tasks.ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
