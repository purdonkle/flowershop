using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void orderTest()
        {
			/*Arrange*/
			var orderDAO = Substitute.For<IOrderDAO>();
			var client = Substitute.For<IClient>();
			Order order = new Order(orderDAO, client);
			/*Act*/
			order.Deliver();
			/*Assert*/
			orderDAO.Received().SetDelivered(order);
        }

        [Test]
        public void priceTest()
        {
            /*Arrange*/
            var orderDAO = Substitute.For<IOrderDAO>();
			var client = Substitute.For<IClient>();
            Order order = new Order(orderDAO, client);
            var flowerDAO = Substitute.For<IFlowerDAO>();
            var flower = Substitute.For<IFlower>();

            /*Act*/
            order.AddFlowers(flower, 2);

            /*Assert*/
            Assert.AreEqual(order.Price, 12.00);
        }
    }
}
