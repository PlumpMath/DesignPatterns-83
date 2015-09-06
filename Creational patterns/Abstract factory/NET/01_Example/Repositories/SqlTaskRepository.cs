using System.Collections.Generic;
using System.Data.SqlClient;
using AbstractFactory.Entity;

namespace AbstractFactory.Repositories
{
    class SqlTaskRepository : ITaskRepository
    {

        #region Queries

        private const string SELECT_SECTIONS = "SELECT [Id] FROM [dbo].[tblVisitors]";

        #endregion

        #region Fileds

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public SqlTaskRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        public List<MyTask> GetAllTasks()
        {
            using (var connection = new SqlConnection(this._connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = SELECT_SECTIONS;
                    command.CommandType = System.Data.CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        List<MyTask> listOfTasks = new List<MyTask>();
                        while (reader.Read())
                        {
                            MyTask myTask = new MyTask();
                            myTask.TaskId = (int)reader["Id"];
                            listOfTasks.Add(myTask);
                        }
                        return listOfTasks;
                    }
                }
            }
        }
    }
}
