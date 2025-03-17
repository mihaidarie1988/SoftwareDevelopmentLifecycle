OrderManagement orderManagement = new OrderManagement();

// PlaceOrder - 2 times
orderManagement.PlaceOrder(1, "Laptop", 2);
orderManagement.PlaceOrder(2, "Mouse", 5);

// ViewOrderHistory
orderManagement.ViewOrderHistory();

// ModifyOrder
orderManagement.ModifyOrder(1, "Gaming Laptop", 1);

// ViewOrderHistory again to see the changes
orderManagement.ViewOrderHistory();

// RemoveOrder
orderManagement.RemoveOrder(2);

// ViewOrderHistory again to see the changes
orderManagement.ViewOrderHistory();