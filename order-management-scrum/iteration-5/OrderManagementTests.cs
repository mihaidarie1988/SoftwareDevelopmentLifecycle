using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrderManagementTests;

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
    public void ModifyOrder_OrderExists_OrderModifiedSuccessfully()
    {
        // Arrange
        var orderManagement = new OrderManagement();
        orderManagement.PlaceOrder(1, "Item1", 10);

        // Act
        orderManagement.ModifyOrder(1, "NewItem", 20);

        // Assert
        var orders = orderManagement.ViewOrderHistory();
        var modifiedOrder = orders.Find(o => o.OrderId == 1);
        Assert.IsNotNull(modifiedOrder);
        Assert.AreEqual("NewItem", modifiedOrder.Item);
        Assert.AreEqual(20, modifiedOrder.Quantity);
    }

    [TestMethod]
    public void ModifyOrder_OrderDoesNotExist_OrderNotFound()
    {
        // Arrange
        var orderManagement = new OrderManagement();

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            orderManagement.ModifyOrder(1, "NewItem", 20);

            // Assert
            var result = sw.ToString().Trim();
            Assert.AreEqual("Order not found.", result);
        }
    }
}