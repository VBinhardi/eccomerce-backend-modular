﻿namespace Ecommerce.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}
