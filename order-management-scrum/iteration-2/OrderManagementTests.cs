using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderManagementTests;

using order_management_scrum;

[TestClass]
public class OrderManagementTests
{
    [TestMethod]
    public void PlaceOrder_ShouldCreateOrderAndPrintMessage()
    {
        // Arrange
        var orderManagement = new OrderManagement();
        const int orderId = 1;
        const string item = "TestItem";
        const int quantity = 5;

        using var sw = new System.IO.StringWriter();
        Console.SetOut(sw);

        // Act
        orderManagement.PlaceOrder(orderId, item, quantity);

        // Assert
        var expectedMessage = "Order placed successfully." + Environment.NewLine;
        Assert.AreEqual(expectedMessage, sw.ToString());
    }

    [TestMethod]
    public void TestViewOrderHistory()
    {
        // Arrange
        OrderManagement orderManagement = new OrderManagement();
        orderManagement.PlaceOrder(1, "Laptop", 2);
        orderManagement.PlaceOrder(2, "Mouse", 5);

        // Capture the console output
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            List<Order> orders = orderManagement.ViewOrderHistory();

            // Assert
            string expectedOutput = "OrderId: 1, Item: Laptop, Quantity: 2\r\n" +
                                    "OrderId: 2, Item: Mouse, Quantity: 5\r\n";
            Assert.AreEqual(expectedOutput, sw.ToString());

            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual(1, orders[0].OrderId);
            Assert.AreEqual("Laptop", orders[0].Item);
            Assert.AreEqual(2, orders[0].Quantity);
            Assert.AreEqual(2, orders[1].OrderId);
            Assert.AreEqual("Mouse", orders[1].Item);
            Assert.AreEqual(5, orders[1].Quantity);
        }
    }
}