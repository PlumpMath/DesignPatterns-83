using System.Collections.Generic;
using AbstractFactory.Entity;
using System.Data.SqlClient;

namespace AbstractFactory.Repositories
{
    class SqlPriorityRepository : IPriorityRepository
    {

        #region Queries

        private const string SELECT_SECTIONS = "SELECT [Id] FROM [dbo].[tblVisitors]";

        #endregion

        #region Fileds

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public SqlPriorityRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        public List<Priority> GetAllPriorities()
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
                        List<Priority> listOfPriorities = new List<Priority>();
                        while (reader.Read())
                        {
                            Priority myTask = new Priority();
                            myTask.PriorityId = (int)reader["Id"];
                            listOfPriorities.Add(myTask);
                        }
                        return listOfPriorities;
                    }
                }
            }
        }
    }
}
