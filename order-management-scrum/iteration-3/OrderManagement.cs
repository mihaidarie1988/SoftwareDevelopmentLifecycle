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
        List<Order> orders = orderHistory.GetOrderHistory();
        Order order = orders.FirstOrDefault(o => o.OrderId == orderId);

        if (order != null)
        {
            order.Item = newItem;
            order.Quantity = newQuantity;
            Console.WriteLine("Order modified successfully.");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }
}