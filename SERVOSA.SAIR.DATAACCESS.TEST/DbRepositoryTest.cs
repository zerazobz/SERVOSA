using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Realizations;
using SERVOSA.SAIR.DATAACCESS.Models.DB;

namespace SERVOSA.SAIR.DATAACCESS.TEST
{
    [TestClass]
    public class DbRepositoryTest
    {
        private IDBColumnsRepository _columnsRepository;
        private IDBTablesRepository _tableRepository;

        public DbRepositoryTest()
        {
            _columnsRepository = new DBRepository();
            _tableRepository = new DBRepository();
        }

        [TestMethod]
        public void CreateANewTable()
        {
            string tableName = "Revision Tecnica Tracto";

            var creationResult = _tableRepository.Create(new TableModel()
            {
                TableName = tableName
            });

            Assert.AreNotEqual(0, creationResult);
            Console.WriteLine(creationResult);
        }

        [TestMethod]
        public void CreateColumnFechaVencimiento()
        {
            string tableName = "RevisionTecnicaTracto";
            string columnName = "FechaVencimiento";
            string dataType = "datetime";

            var creationResult = _columnsRepository.Create(new ColumnModel()
            {
                NormalizedTableName = tableName,
                ColumnName = columnName,
                DataType = dataType
            });

            Assert.AreNotEqual(0, creationResult);
            Console.WriteLine(creationResult);
        }

        [TestMethod]
        public void CreateColumnDiasFaltantes()
        {
            string tableName = "RevisionTecnicaTracto";
            string columnName = "DiasFaltantes";
            string dataType = "int";

            var creationResult = _columnsRepository.Create(new ColumnModel()
            {
                NormalizedTableName = tableName,
                ColumnName = columnName,
                DataType = dataType
            });

            Assert.AreNotEqual(0, creationResult);
            Console.WriteLine(creationResult);
        }
    }
}
