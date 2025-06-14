using System;
using System.Configuration;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
//using Oracle.ManagedDataAccess.Client;
using NAIMS2.Common.Utils;

namespace NAIMS2.DataManager.Models
{
    public class MainModel
    {
        private readonly string mySqlConnectionString;
        private readonly string oracleConnectionString;
        private readonly string sqlServerConnectionString;

        public MainModel()
        {
            // App.config에서 연결 문자열 로드
            mySqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"]?.ConnectionString
                ?? throw new ConfigurationErrorsException("MySqlConnection string not found");
            oracleConnectionString = ConfigurationManager.ConnectionStrings["OracleConnection"]?.ConnectionString
                ?? throw new ConfigurationErrorsException("OracleConnection string not found");
            sqlServerConnectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"]?.ConnectionString
                ?? throw new ConfigurationErrorsException("SqlServerConnection string not found");

            Logger.Info("MenuModel initialized with connection strings");
        }

        // MySQL Connection
        /*
        public MySqlConnection GetMySqlConnection()
        {
            Logger.Info("Opening MySQL connection");
            try
            {
                var connection = new MySqlConnection(mySqlConnectionString);
                connection.Open();
                Logger.Info("MySQL connection opened successfully");
                return connection;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to open MySQL connection", ex);
                throw;
            }
        }

        // Oracle Connection
        public OracleConnection GetOracleConnection()
        {
            Logger.Info("Opening Oracle connection");
            try
            {
                var connection = new OracleConnection(oracleConnectionString);
                connection.Open();
                Logger.Info("Oracle connection opened successfully");
                return connection;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to open Oracle connection", ex);
                throw;
            }
        }
        */
        // MS SQL Server Connection
        public SqlConnection GetSqlServerConnection()
        {
            Logger.Info("Opening SQL Server connection");
            try
            {
                var connection = new SqlConnection(sqlServerConnectionString);
                connection.Open();
                Logger.Info("SQL Server connection opened successfully");
                return connection;
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to open SQL Server connection", ex);
                throw;
            }
        }
    }
}
