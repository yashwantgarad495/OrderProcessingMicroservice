using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderProcessingMicroservice.DataAccess;
using OrderProcessingMicroservice.Models;
using OrderProcessingMicroservice.Repositories;
using System.Threading.Tasks;

namespace OrderProcessingMicroserviceTest
{
    [TestClass]
    public class ProcessOrderRepositoryTest
    {
        private Mock<IDataAccessOrder> mockDal;
        private IProcessOrderRepository _repository;
        private Order order;
        public ProcessOrderRepositoryTest()
        {
            mockDal = new Mock<IDataAccessOrder>();
            order = new Order();
        }
        [TestMethod]
        public async Task AddOrderAsyncTest_Positive()
        {
            order = new Order();
            mockDal.Setup(x => x.Add(order)).ReturnsAsync(true);

            var result = await _repository.Add(order);
   
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task AddOrderAsyncTest_Negative()
        {
            order = new Order();
            mockDal.Setup(x => x.Add(order)).ReturnsAsync(false);

            var result = await _repository.Add(order);

            Assert.AreEqual(false, result);

           
        }
    }
}
