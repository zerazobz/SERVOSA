using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Realizations;

namespace SERVOSA.SAIR.DATAACCESS.TEST.Temp
{
    [TestClass]
    public class TableDataRepositoryTest
    {
        private IDriverTableDataRepository _tableDataRepository;

        [TestInitialize]
        public void InitializeTest()
        {
            _tableDataRepository = new DriverTableDataRepository();
        }

        [TestMethod]
        public void TestQueryWithStructuredData()
        {
            var resultExecution = _tableDataRepository.TestDataStructured();

            Assert.AreNotEqual(0, resultExecution.Count);
        }
    }
}
