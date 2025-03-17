using order_management_scrum;

internal class OrderManagement
{
    public void PlaceOrder(int orderId, string item, int quantity)
    {
        Order order = new Order { OrderId = orderId, Item = item, Quantity = quantity };

        Console.WriteLine("Order placed successfully.");
    }
}