using AccountingWorkInstruments.DataAccess.EfRepository;
using AccountingWorkInstruments.DataAccess.Models;
using AccountingWorksIinstruments.Database;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWorksIinstruments.IntegrationTests.EfRepository
{
    [TestFixture]
    class EfGenRepositoryLocationTests
    {
        private EfGenRepository<Location> _entityRepository;
        private WiDbContext _tmContext;
        //private double expected;

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
            var firstEntity = new Location(theNameOfTheOrganization: "RKP", warehouse1: "Equipped", warehouse2: "Equipped", warehouse3: "Equipped");
            var ent = _entityRepository.ReadAllAsync().Result;
            if ( ent.FirstOrDefault() == null)
            {
                _entityRepository.AddAsync(firstEntity).Wait();
            }
            //"Initial Catalog=AccountingWorksIinstruments.Database"
        }

        [TearDown]
        public void BackUpDataBase()
        {
            var firstEntity = new Location(id: 1, theNameOfTheOrganization: "RKP", warehouse1: "Equipped", warehouse2: "Equipped", warehouse3: "Equipped");
           _entityRepository.UpdateAsync(firstEntity);
        }

        [Test]
        public void ReadAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<Location> 
            {
               new Location(id:1, theNameOfTheOrganization: "RKP", warehouse1:"Equipped", warehouse2:"Equipped",warehouse3:"Equipped")
            };
            // Act
            var actualResult = _entityRepository.ReadAllAsync().Result;

            // Assert
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void UpdateAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new Location(id: 1, theNameOfTheOrganization: "RKPnew", warehouse1: "Equipped", warehouse2: "Equipped", warehouse3: "Equipped");
            var updatedEntity = new Location(id: 1, theNameOfTheOrganization: "RKPnew", warehouse1: "Equipped", warehouse2: "Equipped", warehouse3: "Equipped");

            // Act
            var actualResult = _entityRepository.UpdateAsync(updatedEntity).Result;

            // Assert
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void DeleteAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            List<Location> expected = null;
            var deletedEntity = new Location(id: 1, theNameOfTheOrganization: "RKP", warehouse1: "Equipped", warehouse2: "Equipped", warehouse3: "Equipped");
            // Act
            _entityRepository.DeleteAsync(deletedEntity).Wait();
            var actualResult = _entityRepository.ReadAllAsync().Result;
            //List<Location> actualResult = null;

            // Assert
            actualResult.Should().BeEquivalentTo(expected);
        }
    }

}
