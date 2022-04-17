using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VuelingPractica.Domain.Entities;
using Autofac.Extras.Moq;
using VuelingPractica.Infrastructure.Repositories.Contracts;

namespace VuelingPractica.Infrastructure.RepositoriesUnitTests.Implementations
{
    [TestClass()]
    public class TextFileRepositoryUnitTests
    {
        private Registry registryToSave;

        [TestInitialize]
        public void Setup()
        {
            registryToSave = new Registry()
            {
                Rebeld = "David",
                Planet = "Tierra",
                RegisterDate = DateTime.Now
            };
        }

        [TestMethod()]
        public void AddTest()
        {
            using(var mock = AutoMock.GetLoose())
            {
                mock.Mock<IFileRepository<Registry>>()
                    .Setup(repository => repository.Add(registryToSave))
                    .Returns(registryToSave);

                var mockedRepository = mock.Create<IFileRepository<Registry>>();

                var expectedRegistry = mockedRepository.Add(registryToSave);

                mock.Mock<IFileRepository<Registry>>()
                    .Verify(repository => repository.Add(expectedRegistry));

                Assert.IsTrue(registryToSave.Equals(expectedRegistry));
            }
        }
    }
}