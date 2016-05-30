using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class TableDataRepository : ITableDataRepository
    {
        private readonly Database _servosaDB;
        public TableDataRepository()
        {
            DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
            _servosaDB = _databaseFactory.CreateDefault();
        }
        
        public int InsertDataToTable(string tableName, Dictionary<string, string> dataPrepared, bool variableData)
        {
            try
            {
                DataTable columnsDeclaration;
                using (columnsDeclaration = new DataTable())
                {
                    columnsDeclaration.Columns.Add("ColumnName", typeof(string));
                    dataPrepared.Select(kvp => columnsDeclaration.Rows.Add(kvp.Key)).ToList();
                }

                DataTable columnValues;
                using (columnValues = new DataTable())
                {
                    columnValues.Columns.Add("ColumnValue", typeof(string));
                    dataPrepared.Select(kvp => columnValues.Rows.Add(kvp.Value)).ToList();
                }

                using (var insertCommand = _servosaDB.GetStoredProcCommand(variableData? "SAIR_InsertVariableDataToTable" : "SAIR_InsertConstantDataToTable"))
                {
                    insertCommand.Parameters.Add(new SqlParameter("columnsDeclaration", columnsDeclaration) { SqlDbType = SqlDbType.Structured });
                    insertCommand.Parameters.Add(new SqlParameter("columnsValues", columnValues) { SqlDbType = SqlDbType.Structured });
                    _servosaDB.AddInParameter(insertCommand, "tableName", DbType.String, tableName);
                    var resultExecution = _servosaDB.ExecuteNonQuery(insertCommand);
                    return resultExecution;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<int> TestDataStructured()
        {
            List<int> resultExecution = new List<int>();
            DataTable columns;
            using (columns = new DataTable())
            {
                columns.Columns.Add("EmployeeID", typeof(int));
                columns.Rows.Add(2);
                columns.Rows.Add(3);
                columns.Rows.Add(4);
            }
            
            using (var testCommand = _servosaDB.GetStoredProcCommand("tmp_DoSomethingWithEmployees"))
            {
                testCommand.Parameters.Add(new SqlParameter("List", columns) { SqlDbType = SqlDbType.Structured });
                using (var queryReader = _servosaDB.ExecuteReader(testCommand))
                {
                    while (queryReader.Read())
                    {
                        int employeId = queryReader.GetInt32(0);
                        resultExecution.Add(employeId);
                        if (employeId > 0)
                            Debug.WriteLine("El id del Empleado: " + employeId);
                    }
                }
            }
            return resultExecution;
        }

        public int UpdateDataToTable(string tableName, int vehicleId, Dictionary<string, string> dataPrepared, bool variableData)
        {
            DataTable columnsDictionaryDeclaration;
            using (columnsDictionaryDeclaration = new DataTable())
            {
                columnsDictionaryDeclaration.Columns.Add("ColumnaName", typeof(string));
                columnsDictionaryDeclaration.Columns.Add("ColumnValue", typeof(string));
                var rawTemp = dataPrepared.Select(kvp => columnsDictionaryDeclaration.Rows.Add(new object[] { kvp.Key, kvp.Value })).ToList();
            }

            using (var updateCommand = _servosaDB.GetStoredProcCommand(variableData? "SAIR_UpdateVariableDataToTable" : "SAIR_UpdateConstantDataToTable"))
            {
                updateCommand.Parameters.Add(new SqlParameter("columnsDictionaryDeclarationAndValue", columnsDictionaryDeclaration) { SqlDbType = SqlDbType.Structured });
                _servosaDB.AddInParameter(updateCommand, "tableName", DbType.String, tableName);
                _servosaDB.AddInParameter(updateCommand, "vehicleId", DbType.Int32, vehicleId);
                var resultExecution = _servosaDB.ExecuteNonQuery(updateCommand);
                return resultExecution;
            }
        }
    }
}
