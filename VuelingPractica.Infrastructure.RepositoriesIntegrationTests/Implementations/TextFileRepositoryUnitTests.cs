using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingPractica.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingPractica.Domain.Entities;

namespace VuelingPractica.Infrastructure.RepositoriesIntegrationTests.Implementations
{
    [TestClass()]
    public class TextFileRepositoryUnitTests
    {
        private TextFileRepository repository;
        private Registry registry;

        [TestInitialize]
        public void Setup()
        {
            repository = new TextFileRepository();
            registry = new Registry()
            {
                Rebeld = "David",
                Planet = "Tierra",
                RegisterDate = DateTime.Now
            };
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.IsTrue(repository.Add(registry) != null);
        }
    }
}