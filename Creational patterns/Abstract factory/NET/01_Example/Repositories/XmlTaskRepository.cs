using AbstractFactory.Entity;
using System;
using System.Collections.Generic;
using System.Xml;

namespace AbstractFactory.Repositories
{
    class XmlTaskRepository : ITaskRepository
    {

        #region Fileds

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public XmlTaskRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        public List<MyTask> GetAllTasks()
        {
            using (XmlReader reader = XmlReader.Create(_connectionString))
            {
                List<MyTask> listOfTasks = new List<MyTask>();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            break;
                        case XmlNodeType.Text:
                            MyTask myTask = new MyTask();
                            myTask.TaskId = Convert.ToInt32(reader.Value);
                            listOfTasks.Add(myTask);
                            break;
                        case XmlNodeType.XmlDeclaration:
                        case XmlNodeType.ProcessingInstruction:
                            //reader.WriteProcessingInstruction(reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            //reader.WriteComment(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            //reader.WriteFullEndElement();
                            break;
                    }
                }
                return listOfTasks;

            }
        }
    }
}
