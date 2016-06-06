using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Realizations;

namespace SERVOSA.SAIR.DATAACCESS.TEST.VehicleRepositoryTest
{
    [TestClass]
    public class VehicleRepositoryTest
    {
        private IDriverRepository _vehicleRepository;

        [TestInitialize]
        public void TestClassInitiliaze()
        {
            _vehicleRepository = new VehicleRepository();
        }

        [TestMethod]
        public void TestGetDataForTable()
        {
            var dataForTable = _vehicleRepository.GetRowDataForTable("DocumentosSunat");
            Console.WriteLine("La cantidad te registros es: {0}", dataForTable.Count);
            Assert.AreNotEqual(0, dataForTable.Count);
        }
    }
}
