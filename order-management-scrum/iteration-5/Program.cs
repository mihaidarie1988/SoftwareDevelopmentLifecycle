﻿OrderManagement orderManagement = new OrderManagement();

// PlaceOrder - 2 times
orderManagement.PlaceOrder(1, "Laptop", 2);
orderManagement.PlaceOrder(2, "Mouse", 5);

// ModifyOrder
orderManagement.ModifyOrder(1, "Gaming Laptop", 1);

// RemoveOrder
orderManagement.RemoveOrder(2);