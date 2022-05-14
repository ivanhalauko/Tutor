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
    class EfGenRepositoryPositionTest
    {

        private EfGenRepository<Position> _entityRepository;
        private WiDbContext _tmContext;

        [SetUp]
        public void InitializeTestsEntities()
        {
            string _connectionString = "Data Source=SEREGIN;Initial Catalog=AccountingWorksIinstruments.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _tmContext = new WiDbContext(_connectionString);
            _entityRepository = new EfGenRepository<Position>(_tmContext);
            var firstEntity = new Position(name:"master");
            var ent = _entityRepository.ReadAllAsync().Result;
            if (ent.FirstOrDefault() == null)
            {
                _entityRepository.AddAsync(firstEntity).Wait();
            }
            //"Initial Catalog=AccountingWorksIinstruments.Database"
        }

        [TearDown]
        public void BackUpDataBase()
        {
            var firstEntity = new Position(id: 1, name: "master");
            _entityRepository.UpdateAsync(firstEntity);
        }

        [Test]
        public void ReadAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new List<Position>
            {
               new Position(id:1, name:"master")
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
            var expected = new Position(id: 3, name: "director");
            var updatedEntity = new Position(id: 3,  name:"director");

            // Act
            var actualResult = _entityRepository.UpdateAsync(updatedEntity).Result;

            // Assert
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void DeleteAllAsyncObjects_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            List<Position> expected = null;
            var deletedEntity = new Position(id: 2, name:"director");
            // Act
            _entityRepository.DeleteAsync(deletedEntity).Wait();
            var actualResult = _entityRepository.ReadAllAsync().Result;
            //List<Location> actualResult = null;

            // Assert
            actualResult.Should().BeEquivalentTo(expected);
        }

        [Test]

        public void AddAsync_WhenPropertiesIsNotNull_ThenOutUsListOfEntitiesFromDatabase()
        {
            // Arrange
            var expected = new Position(name: "master");
            // Act
            var actualResult = _entityRepository.AddAsync(expected);
            // Assert
            actualResult.Should().BeEquivalentTo(1);
        }
    }
}
