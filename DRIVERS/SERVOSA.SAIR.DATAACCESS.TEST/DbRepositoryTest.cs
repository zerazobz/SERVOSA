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
        private IDriverDBColumnsRepository _columnsRepository;
        private IDriverDBTablesRepository _tableRepository;

        public DbRepositoryTest()
        {
            _columnsRepository = new DriverDBRepository();
            _tableRepository = new DriverDBRepository();
        }

        [TestMethod]
        public void CreateANewTable()
        {
            string tableName = "Revision Tecnica Tracto";

            var creationResult = _tableRepository.Create(new DriverTableModel()
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

            var creationResult = _columnsRepository.Create(new DriverColumnModel()
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

            var creationResult = _columnsRepository.Create(new DriverColumnModel()
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
