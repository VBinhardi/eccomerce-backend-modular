namespace Ecommerce.Application.DTOs
{
    public class CreateOrderDto
    {
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
