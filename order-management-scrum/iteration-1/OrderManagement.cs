using order_management_scrum;

internal class OrderManagement
{
    private readonly OrderHistory orderHistory = new OrderHistory();
    
    public void PlaceOrder(int orderId, string item, int quantity)
    {
        Order order = new Order { OrderId = orderId, Item = item, Quantity = quantity };

        orderHistory.AddOrder(order);

        Console.WriteLine("Order placed successfully.");
    }

    public void ViewOrderHistory()
    {
        List<Order> orders = orderHistory.GetOrderHistory();

        foreach (var order in orders)
        {
            Console.WriteLine($"OrderId: {order.OrderId}, Item: {order.Item}, Quantity: {order.Quantity}");
        }
    }

    public void ModifyOrder(int orderId, string newItem, int newQuantity)
    {
        RemoveOrder(orderId);

        PlaceOrder(orderId, newItem, newQuantity);

        Console.WriteLine("Order modified successfully.");
    }

    public void RemoveOrder(int orderId)
    {
        orderHistory.RemoveOrder(orderId);

        Console.WriteLine("Order removed successfully.");
    }
}