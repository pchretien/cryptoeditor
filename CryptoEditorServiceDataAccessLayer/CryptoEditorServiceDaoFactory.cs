using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CryptoEditorService
{
    public class CryptoEditorServiceDaoFactory
    {
        public static ICryptoEditorServiceDaoInterface GetDao()
        {
            string databaseConnector = ConfigurationManager.AppSettings["DataBaseConnector"];

            if(databaseConnector.ToLower().IndexOf("mssql") > -1)
                return new CryptoEditorServiceDaoMsSql();

            if (databaseConnector.ToLower().IndexOf("mysql") > -1)
                return new CryptoEditorServiceDaoMySql();

            throw new Exception("Unknown Database Connector");
        }
    }
}
