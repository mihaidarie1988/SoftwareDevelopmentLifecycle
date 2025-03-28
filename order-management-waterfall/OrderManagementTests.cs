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
    public void RemoveOrder_OrderExists_OrderRemovedSuccessfully()
    {
        // Arrange
        var orderManagement = new OrderManagement();
        int orderId = 1;
        string item = "TestItem";
        int quantity = 10;

        orderManagement.PlaceOrder(orderId, item, quantity);

        // Act
        orderManagement.RemoveOrder(orderId);
        var orders = orderManagement.ViewOrderHistory();

        // Assert
        Assert.IsFalse(orders.Any(o => o.OrderId == orderId), "Order was not removed successfully.");
    }
}