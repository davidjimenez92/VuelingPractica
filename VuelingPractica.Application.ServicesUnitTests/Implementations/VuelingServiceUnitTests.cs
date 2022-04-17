using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Extras.Moq;
using VuelingPractica.Applications.Dtos;
using VuelingPractica.Application.Services.Contracts;

namespace VuelingPractica.Application.Services.Implementations.UnitTests
{
    [TestClass()]
    public class VuelingServiceUnitTests
    {
        private RegistryDto registryDto;

        [TestInitialize]
        public void Setup()
        {
            registryDto = new RegistryDto()
            {
                Rebeld = "David",
                Planet = "Tierra"
            };
        }


        [TestMethod()]
        public void AddTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IVuelingService<RegistryDto>>()
                    .Setup(service => service.Add(registryDto))
                    .Returns(registryDto);

                var mockedService = mock.Create<IVuelingService<RegistryDto>>();

                var expectedRegistry = mockedService.Add(registryDto);

                mock.Mock<IVuelingService<RegistryDto>>()
                    .Verify(service => service.Add(registryDto));

                Assert.IsTrue(registryDto.Equals(expectedRegistry));
            }
        }
    }
}