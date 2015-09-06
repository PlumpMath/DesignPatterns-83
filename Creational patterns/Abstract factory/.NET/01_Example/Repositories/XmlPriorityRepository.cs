using System;
using System.Collections.Generic;
using AbstractFactory.Entity;
using System.Xml;

namespace AbstractFactory.Repositories
{
    class XmlPriorityRepository : IPriorityRepository
    {

        #region Fileds

        private readonly string _connectionString;

        #endregion

        #region Constructors

        public XmlPriorityRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        public List<Priority> GetAllPriorities()
        {
            using (XmlReader reader = XmlReader.Create(_connectionString))
            {
                List<Priority> listOfPriorities = new List<Priority>();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            break;
                        case XmlNodeType.Text:
                            Priority myTask = new Priority();
                            myTask.PriorityId = Convert.ToInt32(reader.Value);
                            listOfPriorities.Add(myTask);
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
                return listOfPriorities;
            }
        }
    }
}
