using AccountingWorkInstruments.DataAccess.EfRepository;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Database;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingWorksIinstruments.IntegrationTests.EfRepository
{
    [TestFixture]
    class EfGenRepositoryLocationTests
    {
        private EfGenRepository<Location> _entityRepository;
        private WiDbContext _tmContext;
        private double expected;

        //private string _connectionString = "Data Source=SEREGIN;Initial Catalog=AccountingWorksIinstruments.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        ////[OneTimeSetUp]
        ////public void CreateDb()
        ////{
        ////    _tmContext = new WiDbContext(_connectionString);
        ////}
        [SetUp]
        public void InitializeTestsEntities()
        {
            string _connectionString = "Data Source=SEREGIN;Initial Catalog=AccountingWorksIinstruments.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _tmContext = new WiDbContext(_connectionString);
            _entityRepository = new EfGenRepository<Location>(_tmContext);
            //"Initial Catalog=AccountingWorksIinstruments.Database"
        }

        [Test]
        //[TestCase(1, "Alcopuck", "Equipped", "Not found", "Not found")]
        //[TestCase(2, "NoWhere", "Not found", "Not found", "Not found")]
        //[TestCase(3, "NoWhere", "Not found", "Equipped", "Not found")]
        public void ReadAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<Location> 
            {
               
            }; 
            // Act
            var actualResult = _entityRepository.ReadAllAsync().Result;
            // Assert
            Assert.AreEqual(expected, actualResult);
        }
    }

}
