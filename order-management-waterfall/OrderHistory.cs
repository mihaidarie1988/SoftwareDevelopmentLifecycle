namespace order_management_scrum;

internal class OrderHistory
{
    private readonly List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        orders.Add(order);
    }
    
    public void RemoveOrder(int orderId)
    {
        orders.RemoveAll(o => o.OrderId == orderId);
    }
    
    public List<Order> GetOrderHistory()
    {
        return orders;
    }
}