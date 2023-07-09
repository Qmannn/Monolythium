namespace Monolythium.PublicApi.Dto
{
    public class CreateOrderRequestDto
    {
        public decimal OrderAmount { get; set; }
        public string CustomerFullName { get; set; }
    }
}
